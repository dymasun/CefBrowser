using ExamBrowser.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamBrowser
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static IniKit ik;
        public static string lang;
        public static Chrome chrome;
        public static string start_url;
        [STAThread]
        static void Main(string[] args)
        {
            //read config infomation
            ik = new IniKit("config.ini");
            lang = ik["base"]["lang"];
            ik.addSetion("env");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(chrome = new Chrome());
        }
    }
}