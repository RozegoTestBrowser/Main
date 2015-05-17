using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class browser : Form
    {
        public browser()
        {
            InitializeComponent();
            this.webBrowser1.ProgressChanged+=new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            Form1 main = this.Owner as Form1;
            main.tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
            WebRequest web_request = (HttpWebRequest)System.Net.WebRequest.Create("http://" + webBrowser1.Document.Url.Host.ToString() + "/favicon.ico");
            System.Net.HttpWebResponse web_response = (HttpWebResponse)web_request.GetResponse();
            System.IO.Stream web_stream = web_response.GetResponseStream();
            Image image = Image.FromStream(web_stream);
            main.imageList1.Images.Add(image);
            main.tabControl1.SelectedTab.ImageIndex = main.imageList1.Images.Count - 1;

        }
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress >= 0 && e.CurrentProgress <= 100)
            {
                toolStripProgressBar1.Value = (int)e.CurrentProgress;
           }

            toolStripStatusLabel1.Text = webBrowser1.StatusText;
            
        }
    }
}
