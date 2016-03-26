using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQM
{
    static class Program
    {
        public static MainForm MainForm;
        public static SettingsForm SettingsForm;
        public static EditorForm EditorForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();
            SettingsForm = new SettingsForm();
            EditorForm = new EditorForm();

            Application.Run(MainForm);
        }
    }
}
