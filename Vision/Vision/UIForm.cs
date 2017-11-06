/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: UIForm.cs
// Description: 
//
// Name: Nick Burnette
// Last Edit: 11/3
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class UIForm : Form
    {
        private Thread myDisplayThread = null;
        private Thread myBorderThread = null;
        private Segment[] mySegmentArray;

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
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Abort();
                }
            }
            tabControl.Visible = false;
            createNewMessageButton.Visible = false;
            uploadMessageFromFileButton.Visible = false;
            fileLocationTextBox.Visible = false;
            browseButton.Visible = false;
            uploadButton.Visible = false;
            segment1Button.Visible = false;
            segment2Button.Visible = false;
            segment3Button.Visible = false;
            segment4Button.Visible = false;
            segment5Button.Visible = false;
            segment6Button.Visible = false;
            segment7Button.Visible = false;
            segment8Button.Visible = false;
            segment9Button.Visible = false;
            segment10Button.Visible = false;
            segment11Button.Visible = false;
            segment12Button.Visible = false;
            segment13Button.Visible = false;
            segment14Button.Visible = false;
            addSegmentButton1.Visible = false;
            addSegmentButton2.Visible = false;
            addSegmentButton3.Visible = false;
            addSegmentButton4.Visible = false;
            addSegmentButton5.Visible = false;
            addSegmentButton6.Visible = false;
            addSegmentButton7.Visible = false;
            addSegmentButton8.Visible = false;
            addSegmentButton9.Visible = false;
            addSegmentButton10.Visible = false;
            addSegmentButton11.Visible = false;
            addSegmentButton12.Visible = false;
            addSegmentButton13.Visible = false;
            marquee1.Visible = true;
            Segment mySegment = new Segment("TEAM", Color.Red, 1, 1, 1);
            Segment mySecondSegment = new Segment("Discovery", Color.Aqua, -1, -1, -1);
            Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4, 0, 4);
            mySegmentArray = new Segment[] {mySegment, mySecondSegment, myThirdSegment};
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black, 25, 2000);
            myBorderThread = new Thread(delegate () { marquee1.displayBorder(Color.Red); });
            myDisplayThread = new Thread(delegate(){ marquee1.displayMessage(myMessage); });
            //Message myMessage = new Vision.Message("DISCOVERY", Color.Aqua, Color.Black, Color.Black, Color.Red, 0, 0, 0);
            //myDisplayThread = new Thread(delegate () {
            //    MyMarquee.displayRandomColorMessage(myMessage);
            //});
            myBorderThread.Start();
            myDisplayThread.Start();
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
                specialEffectButton.Visible = true;
                scrollingTextButton.Visible = true;
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
                specialEffectButton.Visible = false;
                scrollingTextButton.Visible = false;
            }
        }
        private void segment1Button_Click(object sender, EventArgs e)
        {
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment1Button.BackColor = Color.Gray;
        }
        private void segment2Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment2Button.BackColor = Color.Gray;
        }
        private void segment3Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment3Button.BackColor = Color.Gray;
        }

        private void segment4Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment4Button.BackColor = Color.Gray;
        }

        private void segment5Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment5Button.BackColor = Color.Gray;
        }

        private void segment6Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment6Button.BackColor = Color.Gray;
        }
        private void segment7Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment7Button.BackColor = Color.Gray;
        }

        private void segment8Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment8Button.BackColor = Color.Gray;
        }

        private void segment9Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment9Button.BackColor = Color.Gray;
        }

        private void segment10Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment10Button.BackColor = Color.Gray;
        }

        private void segment11Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment11Button.BackColor = Color.Gray;
        }

        private void segment12Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment12Button.BackColor = Color.Gray;
        }

        private void segment13Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment14Button.BackColor = Color.LightGray;

            segment13Button.BackColor = Color.Gray;
        }

        private void segment14Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.LightGray;
            segment2Button.BackColor = Color.LightGray;
            segment3Button.BackColor = Color.LightGray;
            segment4Button.BackColor = Color.LightGray;
            segment5Button.BackColor = Color.LightGray;
            segment6Button.BackColor = Color.LightGray;
            segment7Button.BackColor = Color.LightGray;
            segment8Button.BackColor = Color.LightGray;
            segment9Button.BackColor = Color.LightGray;
            segment10Button.BackColor = Color.LightGray;
            segment11Button.BackColor = Color.LightGray;
            segment12Button.BackColor = Color.LightGray;
            segment13Button.BackColor = Color.LightGray;

            segment14Button.BackColor = Color.Gray;
        }
        private void addSegmentButton1_Click(object sender, EventArgs e)
        {
            addSegmentButton1.Visible = false;
            segment2Button.Visible = true;
            addSegmentButton2.Visible = true;
        }

        private void addSegmentButton2_Click(object sender, EventArgs e)
        {
            addSegmentButton2.Visible = false;
            segment3Button.Visible = true;
            addSegmentButton3.Visible = true;
        }

        private void addSegmentButton3_Click(object sender, EventArgs e)
        {
            addSegmentButton3.Visible = false;
            segment4Button.Visible = true;
            addSegmentButton4.Visible = true;
        }

        private void addSegmentButton4_Click(object sender, EventArgs e)
        {
            addSegmentButton4.Visible = false;
            segment5Button.Visible = true;
            addSegmentButton5.Visible = true;
        }

        private void addSegmentButton5_Click(object sender, EventArgs e)
        {
            addSegmentButton5.Visible = false;
            segment6Button.Visible = true;
            addSegmentButton6.Visible = true;
        }

        private void addSegmentButton6_Click(object sender, EventArgs e)
        {
            addSegmentButton6.Visible = false;
            segment7Button.Visible = true;
            addSegmentButton7.Visible = true;
        }

        private void addSegmentButton7_Click(object sender, EventArgs e)
        {
            addSegmentButton7.Visible = false;
            segment8Button.Visible = true;
            addSegmentButton8.Visible = true;
        }

        private void addSegmentButton8_Click(object sender, EventArgs e)
        {
            addSegmentButton8.Visible = false;
            segment9Button.Visible = true;
            addSegmentButton9.Visible = true;
        }

        private void addSegmentButton9_Click(object sender, EventArgs e)
        {
            addSegmentButton9.Visible = false;
            segment10Button.Visible = true;
            addSegmentButton10.Visible = true;
        }

        private void addSegmentButton10_Click(object sender, EventArgs e)
        {
            addSegmentButton10.Visible = false;
            segment11Button.Visible = true;
            addSegmentButton11.Visible = true;
        }

        private void addSegmentButton11_Click(object sender, EventArgs e)
        {
            addSegmentButton11.Visible = false;
            segment12Button.Visible = true;
            addSegmentButton12.Visible = true;
        }

        private void addSegmentButton12_Click(object sender, EventArgs e)
        {
            addSegmentButton12.Visible = false;
            segment13Button.Visible = true;
            addSegmentButton13.Visible = true;
        }

        private void addSegmentButton13_Click(object sender, EventArgs e)
        {
            addSegmentButton13.Visible = false;
            segment14Button.Visible = true;
        }

        private void saveAndExitButton_Click(object sender, EventArgs e)
        {
            //Closes the form
            Application.Exit();
        }
    }
}
