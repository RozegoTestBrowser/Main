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
        public Form1()
        {
            InitializeComponent();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

           browser.GoBack();
            
        }

        private void forward_Click(object sender, EventArgs e)
        {
            browser.GoForward();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            browser.Refresh();
        }

        private void adress_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            adress.Text = browser.Url.ToString();
            toolStripStatusLabel1.Visible = true;        

        }

        private void start_Click(object sender, EventArgs e)
        {
            browser.Navigate("http://" + adress.Text);
            adress.AutoCompleteCustomSource.Add(adress.Text);
            browser.Navigate(adress.Text);
            if (!adress.Items.Contains(adress.Text))
            {
                adress.Items.Add(adress.Text);
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            browser.Navigate("http://youtube.ru");
        }

        private void adress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                browser.Navigate(adress.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void stop_Click(object sender, EventArgs e)
        {
            browser.Stop();
        }

        private void adress_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar1.Value = ((int)e.CurrentProgress < 0 || (int)e.MaximumProgress < (int)e.CurrentProgress) ? (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
        }

        private void zakladki_Click(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browser.GoBack();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
            }
        }

    }


