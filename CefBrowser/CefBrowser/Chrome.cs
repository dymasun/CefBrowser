using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamBrowser
{
    public partial class Chrome : Form
    {
        private CefSharp.WinForms.ChromiumWebBrowser browser;
        public Chrome()
        {
            //allow other thread to change this form
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            
        }
        private void Chrome_Load(object sender, EventArgs e)
        {
            //get url from config
            Start(Program.ik["url"]["web"]);
        }
        public void Start(string url)
        {
            InitChrome(url);
            //regist the object for js, you can use it from html by js
            browser.RegisterJsObject("cef", new CefCustomObject(browser, this));
            browser.RegisterJsObject("jsobj", new JSObj());
            RequestHandler requestHandler = new RequestHandler();
            browser.RequestHandler = requestHandler;
        }
        public void InitChrome(string url)
        {
            var set = new CefSettings
            {
                Locale = "zh-cn",
                AcceptLanguageList = "zh-cn",
                MultiThreadedMessageLoop = true,
                CachePath = "cache",
            };
            set.CefCommandLineArgs.Add("disable-gpu", "1");
            Cef.Initialize(set);
            browser = new ChromiumWebBrowser(url)
            {
            };
            //browser.LifeSpanHandler = new LifeSpanHandler();
            browser.MenuHandler = new MenuHandler();

            browser.FrameLoadEnd += browser_FrameLoadEnd;

            browser.Dock = DockStyle.Fill;
            browser.KeyPress += new KeyPressEventHandler(browser_keyPress);
            this.panel1.Controls.Add(browser);
        }

        void browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            browser.SetZoomLevel(0);
        }
        private void browser_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon1.Visible = true;
        }

        private void Chrome_Shown(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

    }
}
