/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: UIForm.cs
// Description: 
//
// Name: Heather
// Last Edit: 10/22
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class UIForm : Form
    {
        Marquee MyMarquee = null;

        public OpenFileDialog openFileDialog { get; private set; }

        public UIForm()
        {
            InitializeComponent();
        }      

        private void UIForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            marquee.Visible = true;
            tabControl.Visible = false;
            createNewMessageButton.Visible = false;
            uploadMessageFromFileButton.Visible = false;
            fileLocationTextBox.Visible = false;
            browseButton.Visible = false;
            uploadButton.Visible = false;
            MyMarquee = new Marquee(this.marquee);
            Message myMessage = new Vision.Message("DISCOVERY", Color.Red, Color.Black, Color.Black, Color.Green, 0, 0, 0);
            MyMarquee.displayStaticMessage(myMessage);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            int size = -1;

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog.SafeFileName;

            }
        }

        private void uploadMessageFromFileButton_CheckedChanged(object sender, EventArgs e)
        {
            if (uploadMessageFromFileButton.Checked)
            {
                fileLocationTextBox.Visible = true;
                browseButton.Visible = true;
                uploadButton.Visible = true;
            }
            else if (!uploadMessageFromFileButton.Checked)
            {
                fileLocationTextBox.Visible = false;
                browseButton.Visible = false;
                uploadButton.Visible = false;
            }
        }

        private void createNewMessageButton_CheckedChanged(object sender, EventArgs e)
        {
            if (createNewMessageButton.Checked)
            {
                createAMessageGroupBox.Visible = true;
                textLabel.Visible = true;
                textTextBox.Visible = true;
                transitionLabel.Visible = true;
                transitionComboBox.Visible = true;
                repeatLabel.Visible = true;
                repeatComboBox.Visible = true;
                colorLabel.Visible = true;
                colorComboBox.Visible = true;
                transitionSpeedLabel.Visible = true;
                transitionSpeedComboBox.Visible = true;
            }
            else if (!createNewMessageButton.Checked)
            {
                createAMessageGroupBox.Visible = false;
                textLabel.Visible = false;
                textTextBox.Visible = false;
                transitionLabel.Visible = false;
                transitionComboBox.Visible = false;
                repeatLabel.Visible = false;
                repeatComboBox.Visible = false;
                colorLabel.Visible = false;
                colorComboBox.Visible = false;
                transitionSpeedLabel.Visible = false;
                transitionSpeedComboBox.Visible = false;
            }
        }
    }
}
