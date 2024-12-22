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
    /// <summary>
    /// Represents the configuration form for selecting game modes.
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// File path for the configuration file.
        /// </summary>
        private string filePath = "config.xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form2"/> class.
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves the selected configuration to an XML file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            XDocument xmlDoc = new XDocument(
                new XElement("Configuration",
                    new XElement("ManVsAI", radioManAi.Checked),
                    new XElement("ManVsMan", radioManMan.Checked),
                    new XElement("AIvsAI", radioAiAi.Checked)
                )
            );

            xmlDoc.Save(filePath);
        }

        /// <summary>
        /// Loads the saved configuration from an XML file and updates the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
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
