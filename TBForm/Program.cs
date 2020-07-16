///using Infrastructure.CrossCutting.Framework.Encrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBForm.Models;

namespace TBForm
{
    static class Program
    {
        private static TBConsole.AppConfig _AppConfig = new TBConsole.AppConfig();
        public static TBConsole.AppConfig AppConfig { get { return _AppConfig; } set { _AppConfig = value; } }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Assembly.Load("AESDLL.dll");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string appCfgPath = "AppConfig.json";

            //LoginModel loginsr = new LoginModel();

            if (!File.Exists("appCfgPath"))
            {
                using (StreamReader sr = new StreamReader(appCfgPath))
                {
                    string json = sr.ReadToEnd();
                    //loginsr = JsonParser.Deserialize<TBConsole.AppConfig>(json).Login;
                }
            }
            WebLoginForm loginForm = new WebLoginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                AppConfig.TaobaoAccessToken = loginForm.TaobaoAccessToken;
                Application.Run(new MainForm());
            }
            else
            {
                return;
            }
        }
    }
}
