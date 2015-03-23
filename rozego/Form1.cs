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
               
           
        } // Загрузка домашний страницы

        private void Back_Click(object sender, EventArgs e)
        {

            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
            
        }// нажатие кнопки назад 

        private void forward_Click(object sender, EventArgs e) 
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        } // нажатие кнопки вперед

        private void refresh_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }// нажатие кнопки обновить 

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) // когда страница загрузилась отображает название вкладки
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;      

        }


        private void start_Click(object sender, EventArgs e) // нажатие кнопки GO
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
        } // нажатие кнопки домой 

        private void adress_KeyDown(object sender, KeyEventArgs e) // переходит по нажатию enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(adress.Text);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Stop();
        }// нажатие кнопки стоп

        private void tabControl1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) // прогресс бар 
        {
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            if (e.CurrentProgress > 1) toolStripProgressBar1.Value = (int)e.CurrentProgress;
        }
      
        private void adress_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                start.PerformClick();
            }
        } //событие запускающее кнопку "Go" по нажатию enter

        private void toolStripButton1_Click_1(object sender, EventArgs e) // кнопка добавить вкладку
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

        } // закрытие вкладки

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Back.PerformClick();//событие запускающее кнопку "Go" по нажатию enter
            }

        }

        private void zakladki_Click(object sender, EventArgs e)
        {
                Favorites fav = new Favorites();
                fav.urlTxt.Text = web.Url.ToString();
                fav.StartPosition = FormStartPosition.CenterParent;
                fav.Show();
        }
        
    }

}


