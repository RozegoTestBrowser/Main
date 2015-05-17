using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rozego
{
    public partial class Favorites : Form
    {
        public Favorites()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            	ListViewItem item = new ListViewItem(urlTxt.Text);
                listView1.Items.Add(urlTxt.Text);

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
            catch
            {
                MessageBox.Show("You need to select an item");
            }
        }

        private void Favorites_Load(object sender, EventArgs e)
        {
            System.Xml.XmlDocument loadDoc = new System.Xml.XmlDocument();
            loadDoc.Load(Application.StartupPath + "\\Favorites.xml");

            foreach (System.Xml.XmlNode favNode in loadDoc.SelectNodes("/Favorites/Item"))
            {
                listView1.Items.Add(favNode.Attributes["url"].InnerText);
            }
        }

        private void Favorites_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(Application.StartupPath + "\\Favorites.xml", null);

            writer.WriteStartElement("Favorites");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                writer.WriteStartElement("Item");
                writer.WriteAttributeString("url", listView1.Items[i].Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
