using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rozego
{
    public partial class Form1 : Form
    {
        public static int totalBytes = 0;

        public Form1()
        {
            InitializeComponent();
        }

        WebBrowser web = new WebBrowser();
        int i = 0;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i += 1; 
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://youtube.ru");//при загрузке сразу переходит на ютуб
           
        }

        private void Back_Click(object sender, EventArgs e)
        {

            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
            
        }

        private void forward_Click(object sender, EventArgs e) 
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
            int totalCount = 100 - progbar1.Value;
            progbar1.Value += totalCount;
            progLabel1.Visible = true;
        }

        private void start_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(adress.Text);
            if (!adress.Items.Contains(adress.Text))
            {
                adress.Items.Add(adress.Text);
            }
        
        }

        private void home_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://youtube.ru");
        }

        private void adress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(adress.Text);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Stop();
        }

        private void web_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //totalBytes++;
            //if (totalBytes>75)
            //{
             //   totalBytes = totalBytes - 50;
            //}
            //progbar1.Value = totalBytes;
        }

        private void TabControl1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void zakladki_Click(object sender, EventArgs e)
        {

        }

        private void adress_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                start.PerformClick();//событие запускающее кнопку "Go" по нажатию enter
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i += 1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
             if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count -1);
                i -= 1;
            }

        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Back.PerformClick();//событие запускающее кнопку "Go" по нажатию enter
            }

        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

    }

}


