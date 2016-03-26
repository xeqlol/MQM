using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using HtmlAgilityPack;
using MetroFramework;

namespace MQM
{
    public partial class MainForm : MetroForm
    {
        // Делегаты для возможности записи в консоль из другого потока
        public delegate void AddDataDelegate(String myString, System.Drawing.Color myColor);
        public delegate void StopProgramDelegate();
        public AddDataDelegate WriteConsoleBoxDelegate;
        public StopProgramDelegate StopProgramDelegatee;

        // Массив путей до файлов запросов
        private static string[] textQueries = { };
        // Текущий выбранный запрос
        private static INIFile currentQuery;

        // Поток выполнения запросов
        private static Thread queryThread;
        private static MetroColorStyle mainStyle = MetroColorStyle.Blue;

        // Настройки
        private static string queryURL = @"http://212.193.88.191:8648/cheeck.php";
        private static int webClientTimeout = 1800000;

        // Файл настроек
        private static INIFile settings;

        // Системные цвета
        private static System.Drawing.Color normalMessageColor;
        private static System.Drawing.Color errorMessageColor = System.Drawing.Color.Red;

        // Директория хранения отчетов
        private static string queryReportsDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\reports\";

        // Статус программы (запущена или остановлена)
        bool isStarted = false;

        public string QueryURL
        {
            get { return queryURL; }
            set { queryURL = value; }
        }

        public int WebClientTimeout
        {
            get { return webClientTimeout; }
            set { webClientTimeout = value; }
        }

        public MetroColorStyle MainStyle
        {
            get { return mainStyle; }
            set
            {
                this.Style = mainStyle = value;
                QueryEditButton.Style = QueryComboBox.Style = ArchieveButton.Style = SettingsButton.Style = this.Style;
                normalMessageColor = MetroFramework.Drawing.MetroPaint.GetStyleColor(this.Style);
            }
        }

        // Инициализация формы
        public MainForm()
        {
            InitializeComponent();
             
            WriteConsoleBoxDelegate = new AddDataDelegate(WriteConsoleBox);
            StopProgramDelegatee = new StopProgramDelegate(StopProgram);
        }

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                settings = new INIFile("settings.ini");
                queryURL = settings.Read("queryURL");
                webClientTimeout = Int32.Parse(settings.Read("webClientTimeout"));
                mainStyle = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), settings.Read("mainStyle"));
            }
            catch (Exception ex)
            {
               WriteConsoleBox(string.Format("При загрузке файла настроек произошла ошибка. Настройки были сброшены.\r\nТекст ошибки: {0}", ex), errorMessageColor);
            }

            this.Style = mainStyle;
            QueryComboBox.Style = QueryEditButton.Style = ArchieveButton.Style = SettingsButton.Style = this.Style;
            normalMessageColor = MetroFramework.Drawing.MetroPaint.GetStyleColor(this.Style);

            textQueries = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\queries\", "*.query");
            QueryComboBox.Items.Clear();
            foreach (var t in textQueries)
            {
                QueryComboBox.Items.Add(t.Split('\\').Last());
            }
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            WriteConsoleBox(string.Format("Добро пожаловать в Monitoring Query Manager v.{0}.{1}.{2}.", v.Major, v.Minor, v.Build), normalMessageColor);
        }

        // Обработчик нажатия кнопки запроса
        private void MakeQueryButton_Click(object sender, EventArgs e)
        {
            try
            {
                currentQuery = new INIFile(textQueries[QueryComboBox.SelectedIndex]);
            }
            catch
            {
                WriteConsoleBox("При открытии файла запроса возникла ошибка. Возможно, запрос не был выбран из списка.", errorMessageColor);
                return;
            }
            if (!isStarted)
            {
                string queryFileName = textQueries[QueryComboBox.SelectedIndex].Split('\\').Last();
                WriteConsoleBox(string.Format("Программа запущена (обработка {0}).", queryFileName), normalMessageColor);
                queryThread = new Thread(() => MakeQueryQueue(currentQuery, queryFileName));
                queryThread.Start();
                MakeQueryButton.Text = "Остановить";
                isStarted = true;
                QueryComboBox.Enabled = !isStarted;
            }
            else
            {
                WriteConsoleBox("Выполнение программы остановлено.", normalMessageColor);
                StopProgram();
                GC.Collect();
            }
        }

        // Парсим файл запроса и готовимся к его обработке
        private void MakeQueryQueue(INIFile inputQueryConfig, string queryFileName)
        {
            DateTime startDate;
            DateTime endDate;
            try
            {
                startDate = DateTime.Parse(inputQueryConfig.Read("fromDate"));
                endDate = DateTime.Parse(inputQueryConfig.Read("toDate"));

            }
            catch (Exception e)
            {
                ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { string.Format("В ходе разбора текста запроса возникла ошибка. Возможно, были допущены ошибки в ходе составления запроса.\r\n\r\nНиже приведены примеры допустимых величин.\r\nПример для дат: 03-12-2014\r\nПример для времени: 15:30\r\nПример для интервалов выборки: 1-sec, 1-min, 1-hour, 1-day, 1-mon, 1-year\r\n\r\nТекст ошибки: {0}", e.Message), errorMessageColor });
                StopProgram();
                return;
            }

            TimeSpan difference = endDate - startDate;
            DateTime queryDate = startDate;
            string fromTime = inputQueryConfig.Read("fromTime");
            string toTime = inputQueryConfig.Read("toTime");
            string[] queryBody = inputQueryConfig.Read("queryBody").Replace(" ", "").Split(',');
            string[] queryInterval = inputQueryConfig.Read("queryInterval").Replace(" ", "").Split(',');

            int queryCounter = 1;
            for (int i = 0; i <= difference.Days; i++)
            {
                for (int j = 0; j < queryInterval.Length; j++)
                {
                    NameValueCollection query = new NameValueCollection();
                    try
                    {
                        foreach (var body in queryBody)
                            query[body] = "true";

                        query["xtime"] = queryInterval[j].Split('-')[0];
                        query["intime"] = queryInterval[j].Split('-')[1];


                        query["datebox1"] = queryDate.ToString("dd-MM-yyyy");
                        query["datebox2"] = queryDate.ToString("dd-MM-yyyy");


                        query["hour1"] = fromTime.Split(':')[0];
                        query["hour2"] = toTime.Split(':')[0];
                        query["minute1"] = fromTime.Split(':')[1];
                        query["minute2"] = toTime.Split(':')[1];
                    }
                    catch (Exception e)
                    {
                        ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { string.Format("В ходе разбора текста запроса возникла ошибка. Возможно, были допущены ошибки в ходе составления запроса.\r\n\r\nНиже приведены примеры допустимых величин.\r\nПример для дат: 03-12-2014\r\nПример для времени: 15:30\r\nПример для интервалов выборки: 1-sec, 1-min, 1-hour, 1-day, 1-mon, 1-year\r\n\r\nТекст ошибки: {0}", e.Message), errorMessageColor });
                        Invoke(StopProgramDelegatee, new Object[] { });
                        return;
                    }

                    ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { string.Format("Запрос {0} из {1} ({2}, {3}).",
                                                                                            queryCounter,
                                                                                            (difference.Days + 1) * queryInterval.Length,
                                                                                            query["datebox1"],
                                                                                            queryInterval[j]), normalMessageColor});
                    queryCounter++;
                    SaveToExcel(query, string.Format("{0} - {1} - {2}.xlsx", queryFileName, queryDate.ToString("dd-MM-yyyy"), queryInterval[j]));
                }
                queryDate = queryDate.AddDays(1);
            }

            ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { string.Format("Обработка запроса {0} завершена.", queryFileName), normalMessageColor });
            Invoke(StopProgramDelegatee, new Object[] { });
        }

        // Пишем в консоль
        public void WriteConsoleBox(string message, System.Drawing.Color color)
        {

            ConsoleBox.SelectionStart = ConsoleBox.TextLength;
            ConsoleBox.SelectionLength = 0;

            ConsoleBox.SelectionColor = System.Drawing.Color.DimGray;
            ConsoleBox.AppendText(string.Format("[{0}] ", DateTime.Now.ToString("HH:mm:ss")));
            ConsoleBox.SelectionColor = ConsoleBox.ForeColor;

            ConsoleBox.SelectionColor = color;
            ConsoleBox.AppendText(message + "\r\n");
            ConsoleBox.SelectionColor = ConsoleBox.ForeColor;

            ConsoleBox.SelectionStart = ConsoleBox.TextLength;
            ConsoleBox.ScrollToCaret();

            message = string.Empty;
        }

        // Делаем запрос и сохраняем в эксель
        public void SaveToExcel(NameValueCollection postQuery, string fileName)
        {
            SLDocument sl = new SLDocument();
            using (var client = new TimeoutedWebClient(webClientTimeout))
            {
                client.Encoding = Encoding.UTF8;
                byte[] response = { };
                try
                {
                    response = client.UploadValues(queryURL, postQuery);
                }
                catch (TimeoutException timeoutEx)
                {
                    ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { string.Format("Превышено время ожидания ответа от сервера. Возможно, сервер недоступен. Повторите попытку позже.\r\nТекст ошибки: {0}", timeoutEx.Message), normalMessageColor });
                    Invoke(StopProgramDelegatee, new Object[] { });
                    return;
                }
                catch (Exception e)
                {
                    ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { string.Format("При выполнении запроса возникла ошибка.\r\nТекст ошибки: {0}", e.Message), normalMessageColor });
                    Invoke(StopProgramDelegatee, new Object[] { });
                    return;
                }
                HtmlNode table = HtmlNode.CreateNode("");
                var responseString = Encoding.Default.GetString(response);
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(responseString);
                if (htmlDocument.DocumentNode.SelectNodes("//table") != null)
                {
                    table = htmlDocument.DocumentNode.SelectNodes("//table").First();
                    if (table != null)
                    {
                        int iRow = 1;
                        var tableRows = table.Descendants("tr");
                        foreach (var tableRow in tableRows)
                        {
                            var rowCells = tableRow.Descendants("td");
                            int iColumn = 1;
                            foreach (var cell in rowCells)
                            {
                                sl.SetCellValue(iRow, iColumn++, cell.InnerText);
                            }
                            iRow++;
                        }
                        sl.SetCellValue(1, 1, "Дата и время измерения");
                    }
                    else
                    {
                        ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[]
                        {
                            string.Format("Статус запроса: не выполнен ({0}).",
                                htmlDocument.DocumentNode.SelectNodes("//strong") != null
                                    ? htmlDocument.DocumentNode.SelectNodes("//strong").First().InnerText
                                    : "возможно, отсутствуют данные"),
                            errorMessageColor
                        });
                        return;
                    }
                }
                else
                {
                    ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[]
                        {
                            string.Format("Статус запроса: не выполнен ({0}).",
                                htmlDocument.DocumentNode.SelectNodes("//strong") != null
                                    ? htmlDocument.DocumentNode.SelectNodes("//strong").First().InnerText
                                    : "возможно, отсутствуют данные"),
                            errorMessageColor
                        });
                    return;
                }
            }
            sl.SaveAs(MakeUniqueFileName(queryReportsDirectory + fileName).ToString());

            ConsoleBox.Invoke(WriteConsoleBoxDelegate, new Object[] { "Статус запроса: выполнен.", normalMessageColor });
        }

        public FileInfo MakeUniqueFileName(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                    return new FileInfo(path);

                path = Path.Combine(dir, string.Format("{0} (copy {1}){2}", fileName, i, fileExt));
            }
        }

        // Останавливаем программу и меняем статус
        public void StopProgram()
        {
            queryThread.Abort();
            isStarted = false;
            QueryComboBox.Enabled = !isStarted;
            WriteConsoleBox("Программа остановлена.", normalMessageColor);
            MakeQueryButton.Text = "Выполнить";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings = new INIFile("settings.ini");
            settings.Write("queryURL", queryURL);
            settings.Write("webClientTimeout", webClientTimeout.ToString());
            settings.Write("mainStyle", this.Style.ToString());
            Environment.Exit(0);
        }

        private void ArchieveButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(queryReportsDirectory);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Program.SettingsForm.ShowDialog();
        }

        private void QueryEditButton_Click(object sender, EventArgs e)
        {
            Program.EditorForm.ShowDialog();
        }
    }

    public class TimeoutedWebClient : WebClient
    {
        private int timeout;
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        public TimeoutedWebClient()
        {
            this.timeout = 60000;
        }

        public TimeoutedWebClient(int timeout)
        {
            this.timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var result = base.GetWebRequest(address);
            result.Timeout = this.timeout;
            return result;
        }
    }
}