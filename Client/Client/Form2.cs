using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XDocument xmlDoc = new XDocument(
                new XElement("Configuration",
                    new XElement("ManVsAI", radioManAi.Checked),
                    new XElement("ManVsMan", radioManMan.Checked),
                    new XElement("AIvsAI", radioAiAi.Checked)
                )
            );

            string filePath = "config.xml";
            xmlDoc.Save(filePath);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string filePath = "config.xml";

            if (File.Exists(filePath))
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                radioManAi.Checked = (bool)xmlDoc.Root.Element("ManVsAI");
                radioManMan.Checked = (bool)xmlDoc.Root.Element("ManVsMan");
                radioAiAi.Checked = (bool)xmlDoc.Root.Element("AIvsAI");
            }
            else
            {
                MessageBox.Show("No saved data found.", "Error");
            }
        }

    }
}
