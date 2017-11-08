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
            segmentPanel1.Visible = false;
            segmentPanel2.Visible = false;
            segmentPanel3.Visible = false;
            segmentPanel4.Visible = false;
            segmentPanel5.Visible = false;
            segmentPanel6.Visible = false;
            segmentPanel7.Visible = false;
            segmentPanel8.Visible = false;
            segmentPanel9.Visible = false;
            segmentPanel10.Visible = false;
            segmentPanel11.Visible = false;
            segmentPanel12.Visible = false;
            segmentPanel13.Visible = false;
            segmentPanel14.Visible = false;
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
            Image myImageSegment = new Image("..\\..\\panthers.jpg");
            Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4, 2, 4);
            mySegmentArray = new Segment[] { myThirdSegment, mySecondSegment, myImageSegment, };
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black, Color.Red, 0, 25, 2000);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
            //Message myMessage = new Vision.Message("DISCOVERY", Color.Aqua, Color.Black, Color.Black, Color.Red, 0, 0, 0);
            //myDisplayThread = new Thread(delegate () {
            //    MyMarquee.displayRandomColorMessage(myMessage);
            //});
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

        private void addSegmentButton1_Click(object sender, EventArgs e)
        {
            addSegmentButton1.Visible = false;
            segmentPanel2.Visible = true;
            addSegmentButton2.Visible = true;
        }

        private void addSegmentButton2_Click(object sender, EventArgs e)
        {
            addSegmentButton2.Visible = false;
            segmentPanel3.Visible = true;
            addSegmentButton3.Visible = true;
        }

        private void addSegmentButton3_Click(object sender, EventArgs e)
        {
            addSegmentButton3.Visible = false;
            segmentPanel4.Visible = true;
            addSegmentButton4.Visible = true;
        }

        private void addSegmentButton4_Click(object sender, EventArgs e)
        {
            addSegmentButton4.Visible = false;
            segmentPanel5.Visible = true;
            addSegmentButton5.Visible = true;
        }

        private void addSegmentButton5_Click(object sender, EventArgs e)
        {
            addSegmentButton5.Visible = false;
            segmentPanel6.Visible = true;
            addSegmentButton6.Visible = true;
        }

        private void addSegmentButton6_Click(object sender, EventArgs e)
        {
            addSegmentButton6.Visible = false;
            segmentPanel7.Visible = true;
            addSegmentButton7.Visible = true;
        }

        private void addSegmentButton7_Click(object sender, EventArgs e)
        {
            addSegmentButton7.Visible = false;
            segmentPanel8.Visible = true;
            addSegmentButton8.Visible = true;
        }

        private void addSegmentButton8_Click(object sender, EventArgs e)
        {
            addSegmentButton8.Visible = false;
            segmentPanel9.Visible = true;
            addSegmentButton9.Visible = true;
        }

        private void addSegmentButton9_Click(object sender, EventArgs e)
        {
            addSegmentButton9.Visible = false;
            segmentPanel10.Visible = true;
            addSegmentButton10.Visible = true;
        }

        private void addSegmentButton10_Click(object sender, EventArgs e)
        {
            addSegmentButton10.Visible = false;
            segmentPanel11.Visible = true;
            addSegmentButton11.Visible = true;
        }

        private void addSegmentButton11_Click(object sender, EventArgs e)
        {
            addSegmentButton11.Visible = false;
            segmentPanel12.Visible = true;
            addSegmentButton12.Visible = true;
        }

        private void addSegmentButton12_Click(object sender, EventArgs e)
        {
            addSegmentButton12.Visible = false;
            segmentPanel13.Visible = true;
            addSegmentButton13.Visible = true;
        }

        private void addSegmentButton13_Click(object sender, EventArgs e)
        {
            addSegmentButton13.Visible = false;
            segmentPanel14.Visible = true;
        }

        private void saveAndExitButton_Click(object sender, EventArgs e)
        {
            //Closes the form
            Application.Exit();
            myDisplayThread.Abort();
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Abort();
                }
            }
        }

        private void resetSegments()
        {
            segmentPanel1.BackColor = Color.Gray;
            segmentPanel2.BackColor = Color.Gray;
            segmentPanel3.BackColor = Color.Gray;
            segmentPanel4.BackColor = Color.Gray;
            segmentPanel5.BackColor = Color.Gray;
            segmentPanel6.BackColor = Color.Gray;
            segmentPanel7.BackColor = Color.Gray;
            segmentPanel8.BackColor = Color.Gray;
            segmentPanel9.BackColor = Color.Gray;
            segmentPanel10.BackColor = Color.Gray;
            segmentPanel11.BackColor = Color.Gray;
            segmentPanel12.BackColor = Color.Gray;
            segmentPanel13.BackColor = Color.Gray;
            segmentPanel14.BackColor = Color.Gray;
        }

        private void saveAndRunButton_Click(object sender, EventArgs e)
        {
            //Start at the highest to decided how big the array should be.
            //If segment14 is visable then the user added all segments.
            if (segmentPanel14.Visible == true)
            {
                /* Test data */
                /*
                Segment[] mySegmentArray = new Segment[13];
                Segment mySegment = new Segment("TEAM", Color.Red, 1, 1, 1);
                Segment mySecondSegment = new Segment("Discovery", Color.Aqua, -1, -1, -1);
                Image myImageSegment = new Image("..\\..\\desert.jpg");
                Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4, 0, 4);
                mySegmentArray = new Segment[] { mySegment, mySecondSegment, myImageSegment, myThirdSegment };
                Message myMessage = new Vision.Message(mySegmentArray, Color.Black, Color.Red, 0, 25, 2000);
                myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
                myDisplayThread.Start();
                */
            }
            else if (segmentPanel13.Visible == true)
            {

            }
            else if (segmentPanel12.Visible == true)
            {

            }
            else if (segmentPanel11.Visible == true)
            {

            }
            else if (segmentPanel10.Visible == true)
            {

            }
            else if (segmentPanel9.Visible == true)
            {

            }
            else if (segmentPanel8.Visible == true)
            {

            }
            else if (segmentPanel7.Visible == true)
            {

            }
            else if (segmentPanel6.Visible == true)
            {

            }
            else if (segmentPanel5.Visible == true)
            {

            }
            else if (segmentPanel4.Visible == true)
            {

            }
            else if (segmentPanel3.Visible == true)
            {

            }
            else if (segmentPanel2.Visible == true)
            {

            }
            else //only segment one is active.
            {

            }
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            //Test which segment button is active
            if (segmentPanel14.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel13.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel12.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel11.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel10.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel9.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel8.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel7.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel6.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel5.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel4.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel3.BackColor == Color.DeepSkyBlue)
            {

            }
            else if (segmentPanel2.BackColor == Color.DeepSkyBlue)
            {

            }
            else //Segment 1
            {

            }
        }

        private void segmentPanel1_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel1.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel2_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel2.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel3_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel4_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel5_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel6_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel7_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel8_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel9_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel10_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel11_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel12_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel13_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
        }

        private void segmentPanel14_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel1.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel2_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel2.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel3_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel4_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel5_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel6_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel7_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel8_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel9_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel10_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel11_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel12_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel13_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
        }

        private void segmentLabel14_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
        }
    }
}
