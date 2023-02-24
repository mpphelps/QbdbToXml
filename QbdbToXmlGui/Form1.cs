using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QbdbToXmlGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "QBDB File (*.HDW;*.PNT)|*.HDW;*.PNT|";

            // Allow the user to select multiple images.
            //this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "QBDB File Browser";
        }

        private void TrainerHdwBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                TrainerHdwText.Text = openFileDialog1.FileName;
            }
        }

        private void TrainerPntBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                TrainerPntText.Text = openFileDialog1.FileName;
            }
        }

        private void CustomerHdwBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                CustomerHdwText.Text = openFileDialog1.FileName;
            }
        }

        private void CustomerPntBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                CustomerPntText.Text = openFileDialog1.FileName;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            //var converter = new QbdbToXml.QbdbToXmlConverter("aa", "aa", "aa", "aa");
            var converter = new QbdbToXml.QbdbToXmlConverter(TrainerHdwText.Text, TrainerPntText.Text, CustomerHdwText.Text,CustomerPntText.Text);
            if(converter.Convert())
                SuccessLabel.Visible = true;
        }
    }
}
