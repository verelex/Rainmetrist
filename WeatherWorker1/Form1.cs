using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherWorker1
{
    public partial class Form1 : Form
    {
        private string url = string.Empty;

        private string path = string.Empty;

        public Form1(string[] args)
        {
            InitializeComponent();
            if ( args.Length == 2 )
            {
                url = args[0];
                path = args[1];
            }
            else
            {
                DialogResult drs = MessageBox.Show(this,"Неправильное количество параметров",
                    "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if( drs == DialogResult.OK )
                {
                    Application.Exit();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false; // this hides app window ---------------------!!!!!!!!!!!
            this.Hide();
            //
            if (url.Equals(String.Empty))
            {
                Application.Exit();
            }
            int nProcessID = Process.GetCurrentProcess().Id;
            this.Text = $"WeatherWorker  pid = {nProcessID}";
            webView21.EnsureCoreWebView2Async();
            Uri uri = new Uri(url);
            webView21.Source = uri;
        }

        private async void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            String myScript = "document.documentElement.innerHTML";
            
            String webData = await webView21.ExecuteScriptAsync(myScript);

            string unescaped = Regex.Unescape(webData);

            LogWriter lw = new LogWriter();
            lw.LogWrite(path, unescaped.Trim('\"'));

            //webView21.Visible = false;
            //this.BackColor = Color.Yellow;
            Thread.Sleep(1000);
            Application.Exit();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //webView21.SetBounds(12, 80, this.Width - 50, this.Height - 160);
        }
    }
}
