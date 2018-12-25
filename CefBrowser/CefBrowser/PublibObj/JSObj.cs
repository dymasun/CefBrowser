using ExamBrowser.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExamBrowser
{
    class JSObj
    {
        //you can run exe progame by this func
        public void start(string start)
        {
            int index = start.IndexOf(".exe");
            string exe = start.Substring(0, index + 4);
            string args = start.Substring(index + 4, start.Length - (index + 4));
            Exec.exec(exe,args);
        }
        //start a webpage with IE
        public void href(string url)
        {
            System.Diagnostics.Process.Start("explorer.exe", url);

        }
        //exit this process by kill
        public void exit()
        {
            Process current = Process.GetCurrentProcess();
            current.Kill();
        }
    }
}
