﻿using CefSharp.WinForms;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExamBrowser
{
    class CefCustomObject
    {
        // Declare a local instance of chromium and the main form in order to execute things from here in the main thread
        private static ChromiumWebBrowser _instanceBrowser = null;
        // The form class needs to be changed according to yours
        private static Chrome _instanceMainForm = null;


        public CefCustomObject(ChromiumWebBrowser originalBrowser, Chrome mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;
        }

        public void showDevTools()
        {
            _instanceBrowser.GetBrowser().GetHost().ShowDevTools();
        }

        public void opencmd()
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c pause");
            Process.Start(start);
        }

        public void exit()
        {
            Application.Exit();
        }

    }
}