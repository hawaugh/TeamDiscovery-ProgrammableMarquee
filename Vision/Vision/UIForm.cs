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
        private Segment[] mySegmentArray = new Segment[18];
        private Color darkerGray = new Color();
        private Color lightGray = new Color();

        //Getting setup for movable segments
        //Holder for the location for all SegmentPanels
        private Point[] mySegmentPanelArray = new Point[18];
        //Parallel Array for the location of all SegmentLabels
        private Point[] mySegmentLabelArray = new Point[18];
        //Parallel Array for the location of all SegmentCloseButtons
        private Point[] mySegmentCloseButtonArray = new Point[18];

        public OpenFileDialog openFileDialog { get; private set; }

        public UIForm()
        {
            darkerGray = Color.FromArgb(0, 64, 64, 64);
            lightGray = Color.FromArgb(0, 224, 224, 224);

            for (int i = 0; i < 18; i++)
            {
                mySegmentArray[i] = new Segment();
            }
            InitializeComponent();
            getLocations();
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
            clearForMarquee();
            marquee1.Visible = true;
            Segment mySegment = new Segment("TEAM", Color.Red, 1, 1, 1);
            Segment mySecondSegment = new Segment("Discovery", Color.Aqua, -1, -1, -1);
            Image myImageSegment = new Image("..\\..\\panthers.jpg");
            Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4, 2, 4);
            mySegmentArray = new Segment[] { mySegment, mySecondSegment, myImageSegment, myThirdSegment };
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black, Color.Red, 1, 25, 2000);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
            myDisplayThread.Start();
            
        }

        //Leave until image tab is working.
        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            int size = -1;

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog.SafeFileName;

            }
        }
        
        /*
         * 
         *   Generic functions
         * 
         */
        #region Generic Functions
        //Sets the locations of objects to a parallel array
        private void getLocations()
        {
            mySegmentPanelArray[0] = segmentPanel1.Location;
            mySegmentPanelArray[1] = segmentPanel2.Location;
            mySegmentPanelArray[2] = segmentPanel3.Location;
            mySegmentPanelArray[3] = segmentPanel4.Location;
            mySegmentPanelArray[4] = segmentPanel5.Location;
            mySegmentPanelArray[5] = segmentPanel6.Location;
            mySegmentPanelArray[6] = segmentPanel7.Location;
            mySegmentPanelArray[7] = segmentPanel8.Location;
            mySegmentPanelArray[8] = segmentPanel9.Location;
            mySegmentPanelArray[9] = segmentPanel10.Location;
            mySegmentPanelArray[10] = segmentPanel11.Location;
            mySegmentPanelArray[11] = segmentPanel12.Location;
            mySegmentPanelArray[12] = segmentPanel13.Location;
            mySegmentPanelArray[13] = segmentPanel14.Location;
            mySegmentPanelArray[14] = segmentPanel15.Location;
            mySegmentPanelArray[15] = segmentPanel16.Location;
            mySegmentPanelArray[16] = segmentPanel17.Location;
            mySegmentPanelArray[17] = segmentPanel18.Location;

            mySegmentLabelArray[0] = segmentLabel1.Location;
            mySegmentLabelArray[1] = segmentLabel2.Location;
            mySegmentLabelArray[2] = segmentLabel3.Location;
            mySegmentLabelArray[3] = segmentLabel4.Location;
            mySegmentLabelArray[4] = segmentLabel5.Location;
            mySegmentLabelArray[5] = segmentLabel6.Location;
            mySegmentLabelArray[6] = segmentLabel7.Location;
            mySegmentLabelArray[7] = segmentLabel8.Location;
            mySegmentLabelArray[8] = segmentLabel9.Location;
            mySegmentLabelArray[9] = segmentLabel10.Location;
            mySegmentLabelArray[10] = segmentLabel11.Location;
            mySegmentLabelArray[11] = segmentLabel12.Location;
            mySegmentLabelArray[12] = segmentLabel13.Location;
            mySegmentLabelArray[13] = segmentLabel14.Location;
            mySegmentLabelArray[14] = segmentLabel15.Location;
            mySegmentLabelArray[15] = segmentLabel16.Location;
            mySegmentLabelArray[16] = segmentLabel17.Location;
            mySegmentLabelArray[17] = segmentLabel18.Location;

            mySegmentCloseButtonArray[0] = closeButton1.Location;
            mySegmentCloseButtonArray[1] = closeButton2.Location;
            mySegmentCloseButtonArray[2] = closeButton3.Location;
            mySegmentCloseButtonArray[3] = closeButton4.Location;
            mySegmentCloseButtonArray[4] = closeButton5.Location;
            mySegmentCloseButtonArray[5] = closeButton6.Location;
            mySegmentCloseButtonArray[6] = closeButton7.Location;
            mySegmentCloseButtonArray[7] = closeButton8.Location;
            mySegmentCloseButtonArray[8] = closeButton9.Location;
            mySegmentCloseButtonArray[9] = closeButton10.Location;
            mySegmentCloseButtonArray[10] = closeButton11.Location;
            mySegmentCloseButtonArray[11] = closeButton12.Location;
            mySegmentCloseButtonArray[12] = closeButton13.Location;
            mySegmentCloseButtonArray[13] = closeButton14.Location;
            mySegmentCloseButtonArray[14] = closeButton15.Location;
            mySegmentCloseButtonArray[15] = closeButton16.Location;
            mySegmentCloseButtonArray[16] = closeButton17.Location;
            mySegmentCloseButtonArray[17] = closeButton18.Location;
        }
        
        private void clearForMarquee()
        {
            fileLocationTextBox.Visible = false;
            SegmentHolderPanel.Visible = false;
            loadXMLButton.Visible = false;
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
            segmentPanel15.Visible = false;
            segmentPanel16.Visible = false;
            segmentPanel17.Visible = false;
            segmentPanel18.Visible = false;
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
            addSegmentButton14.Visible = false;
            addSegmentButton15.Visible = false;
            addSegmentButton16.Visible = false;
            addSegmentButton17.Visible = false;
            logoLabel.Visible = false;
            textTabLabel.Visible = false;
            imageTabLabel.Visible = false;
            textPanel.Visible = false;
            imagePanel.Visible = false;
        }
        #endregion

        /*
         * 
         *   Segment Buttons
         * 
         */
        #region Segment Buttons
        private void addSegmentButton1_Click(object sender, EventArgs e)
        {        
            /*
            if (mySegmentArray[0].messageText == "")
            {
                noTextPopUp.Visible = true;
            }
            else
            {
                addSegmentButton1.Visible = false;
                segmentPanel2.Visible = true;
                addSegmentButton2.Visible = true;
            }
            */
            addSegmentButton1.Visible = false;
            segmentPanel2.Visible = true;
            addSegmentButton2.Visible = true;
        }

        private void addSegmentButton2_Click(object sender, EventArgs e)
        {
            /*
            if (mySegmentArray[0].messageText == "")
            {
                noTextPopUp.Visible = true;
            }
            else
            {
                addSegmentButton2.Visible = false;
                segmentPanel3.Visible = true;
                addSegmentButton3.Visible = true;
            }
            */
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
            addSegmentButton14.Visible = true;
        }

        private void addSegmentButton14_Click(object sender, EventArgs e)
        {
            addSegmentButton14.Visible = false;
            segmentPanel15.Visible = true;
            addSegmentButton15.Visible = true;
        }

        private void addSegmentButton15_Click(object sender, EventArgs e)
        {
            addSegmentButton15.Visible = false;
            segmentPanel16.Visible = true;
            addSegmentButton16.Visible = true;
        }

        private void addSegmentButton16_Click(object sender, EventArgs e)
        {
            addSegmentButton16.Visible = false;
            segmentPanel17.Visible = true;
            addSegmentButton17.Visible = true;
        }

        private void addSegmentButton17_Click(object sender, EventArgs e)
        {
            addSegmentButton17.Visible = false;
            segmentPanel18.Visible = true;
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

        private void segmentPanel1_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel1.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel2_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel2.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[1].messageText;
        }

        private void segmentPanel3_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[2].messageText;
        }

        private void segmentPanel4_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[3].messageText;
        }

        private void segmentPanel5_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[4].messageText;
        }

        private void segmentPanel6_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[5].messageText;
        }

        private void segmentPanel7_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[6].messageText;
        }

        private void segmentPanel8_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[7].messageText;
        }

        private void segmentPanel9_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[8].messageText;
        }

        private void segmentPanel10_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[9].messageText;
        }

        private void segmentPanel11_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[10].messageText;
        }

        private void segmentPanel12_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[11].messageText;
        }

        private void segmentPanel13_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[12].messageText;
        }

        private void segmentPanel14_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[13].messageText;
        }

        private void segmentPanel15_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel15.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[14].messageText;
        }

        private void segmentPanel16_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel16.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[15].messageText;
        }

        private void segmentPanel17_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel17.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[16].messageText;
        }

        private void segmentPanel18_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel18.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[17].messageText;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel1.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel2_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel2.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[1].messageText;
        }

        private void segmentLabel3_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[2].messageText;
        }

        private void segmentLabel4_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[3].messageText;
        }

        private void segmentLabel5_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[4].messageText;
        }

        private void segmentLabel6_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[5].messageText;
        }

        private void segmentLabel7_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[6].messageText;
        }

        private void segmentLabel8_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[7].messageText;
        }

        private void segmentLabel9_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[8].messageText;
        }

        private void segmentLabel10_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[9].messageText;
        }

        private void segmentLabel11_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[10].messageText;
        }

        private void segmentLabel12_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[11].messageText;
        }

        private void segmentLabel13_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[12].messageText;
        }

        private void segmentLabel14_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[13].messageText;
        }

        private void segmentLabel15_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel15.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[14].messageText;
        }

        private void segmentLabel16_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel16.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[15].messageText;
        }

        private void segmentLabel17_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel17.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[16].messageText;
        }

        private void segmentLabel18_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel18.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[17].messageText;
        }
        #endregion


        /*
         * 
         *   ComboBoxes
         * 
         */
        #region ComboBoxes
        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //noTextPopUp.Visible = false;
            //Test which segment button is active
            if (segmentPanel14.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[13].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel13.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[12].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel12.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[11].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel11.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[10].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel10.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[9].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel9.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[8].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel8.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[7].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel7.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[6].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel6.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[5].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel5.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[4].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel4.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[3].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel3.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[2].onColor = findColor(colorComboBox.Text);
            }
            else if (segmentPanel2.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[1].onColor = findColor(colorComboBox.Text);
            }
            else //Segment 1
            {
                mySegmentArray[0].onColor = findColor(colorComboBox.Text);
            }
        }

        private Color findColor(String text)
        {
            if (colorComboBox.Text == "Aqua")
            {
                return Color.Aqua;
            }
            else if (colorComboBox.Text == "Blue")
            {
                return Color.Blue;
            }
            else if (colorComboBox.Text == "BlueViolet")
            {
                return Color.BlueViolet;
            }
            else if (colorComboBox.Text == "Cyan")
            {
                return Color.Cyan;
            }
            else if (colorComboBox.Text == "Fuchsia")
            {
                return Color.Fuchsia;
            }
            else
            {
                return Color.Yellow;
            }
        }
        #endregion

        /*
         * 
         *   Bottom Buttons
         * 
         */
        #region Segment Buttons
        private void saveAndExitButton_Click(object sender, EventArgs e)
        {
            //Closes the form
            Application.Exit();
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Abort();
                }
            }
        }
        private void saveAndRunButton_Click(object sender, EventArgs e)
        {
            //Start at the highest to decided how big the array should be.
            //If segment14 is visable then the user added all segments.
            if (segmentPanel18.Visible == true)
            {

            }
            else if (segmentPanel17.Visible == true)
            {

            }
            else if (segmentPanel16.Visible == true)
            {

            }
            else if (segmentPanel15.Visible == true)
            {

            }
            else if (segmentPanel14.Visible == true)
            {

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
                /* Test data */
                /*
                Segment mySegment = new Segment("TEAM", Color.Red, 1, 1, 1);
                Segment mySecondSegment = new Segment("Discovery", Color.Aqua, -1, -1, -1);
                Image myImageSegment = new Image("..\\..\\panthers.jpg");
                Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4, 2, 4);
                mySegmentArray = new Segment[] { myThirdSegment, mySecondSegment, myImageSegment, };
                Message myMessage = new Vision.Message(mySegmentArray, Color.Black, Color.Red, 0, 25, 2000);
                myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
                myDisplayThread.Start();
                */
            }
            else //only segment one is active.
            {
                if (myDisplayThread != null)
                {
                    if (myDisplayThread.IsAlive)
                    {
                        myDisplayThread.Abort();
                    }
                }
                clearForMarquee();
                marquee1.Visible = true;
                //Segment mySegment = new Segment("TEAM", Color.Red, 1, 1, 1);
                //segment1.onColor = Color.Blue;
                mySegmentArray = new Segment[] { mySegmentArray[0] };  //make direct calls to indexes for now, but once we get ignore field up this line will go away (since the whole array will be passed every time)
                Message myMessage = new Vision.Message(mySegmentArray, Color.Black, Color.Red, 0, 25, 2000);
                myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
                myDisplayThread.Start();
            }
        }
        
                private int findLocation(double x, double y)
        {
            int result = 0;
            //test whether the mouse location is in a segment zone
            if (x > 5 && x < 115 && y > 6 && y < 46)
            {
                result = 1;
            }
            else if (x > 120 && x < 230 && y > 6 && y < 46)
            {
                result = 2;
            }
            else if (x > 5 && x < 115 && y > 52 && y < 92)
            {
                result = 3;
            }
            else if (x > 120 && x < 230 && y > 52 && y < 92)
            {
                result = 4;
            }
            else if (x > 5 && x < 115 && y > 98 && y < 138)
            {
                result = 5;
            }
            else if (x > 120 && x < 230 && y > 98 && y < 138)
            {
                result = 6;
            }
            else if (x > 5 && x < 115 && y > 144 && y < 184)
            {
                result = 7;
            }
            else if (x > 120 && x < 230 && y > 144 && y < 184)
            {
                result = 8;
            }
            else if (x > 5 && x < 115 && y > 190 && y < 230)
            {
                result = 9;
            }
            else if (x > 120 && x < 230 && y > 190 && y < 230)
            {
                result = 10;
            }
            else if (x > 5 && x < 115 && y > 236 && y < 276)
            {
                result = 11;
            }
            else if (x > 120 && x < 230 && y > 236 && y < 276)
            {
                result = 12;
            }
            else if (x > 5 && x < 115 && y > 282 && y < 322)
            {
                result = 13;
            }
            else if (x > 120 && x < 230 && y > 282 && y < 322)
            {
                result = 14;
            }
            else if (x > 5 && x < 115 && y > 328 && y < 348)
            {
                result = 15;
            }
            else if (x > 120 && x < 230 && y > 328 && y < 348)
            {
                result = 16;
            }
            else if (x > 5 && x < 115 && y > 374 && y < 414)
            {
                result = 17;
            }
            else if (x > 120 && x < 230 && y > 374 && y < 414)
            {
                result = 18;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        private Point MouseDownLocation;
        private Point segment1Point;

        private void segmentPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //moves the selected panel to the top so it doesnt go behind other panels while being dragged.
            segmentPanel1.BringToFront();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }

            segment1Point = segmentPanel1.Location;
        }

        private void segmentPanel1_MouseMove(object sender, MouseEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                segmentPanel1.Left = e.X + segmentPanel1.Left - MouseDownLocation.X;
                segmentPanel1.Top = e.Y + segmentPanel1.Top - MouseDownLocation.Y;

                //segmentPanel1.Location = e.Location;
                //segmentLabel1.Location = e.Location;
                //closeButton1.Location = e.Location;
            }
            /*
            double x;
            double y;
            
            x = e.X;
            y = e.Y;
            if (x > 5 && x < 115 && y > 6 && y < 46)
            {
                
            }
            if (x > 120 && x < 230 && y > 6 && y < 46)
            {
                segmentPanel2.Left = mySegmentPanelArray[0].X;
                segmentPanel2.Top = mySegmentPanelArray[0].Y;
                //segmentPanel2.Location = mySegmentPanelArray[0];
                segmentPanel2.ForeColor = Color.White;
                
            }
            if (x > 5 && x < 115 && y > 52 && y < 92)
            {
                segmentPanel2.Location = mySegmentPanelArray[0];
                segmentPanel3.Location = mySegmentPanelArray[1];
            }
            else if (x > 120 && x < 230 && y > 52 && y < 92)
            {
                segmentPanel2.Location = mySegmentPanelArray[0];
                segmentPanel3.Location = mySegmentPanelArray[1];
                segmentPanel4.Location = mySegmentPanelArray[2];
            }
            else if (x > 5 && x < 115 && y > 98 && y < 138)
            {
                segmentPanel2.Location = mySegmentPanelArray[0];
                segmentPanel3.Location = mySegmentPanelArray[1];
                segmentPanel4.Location = mySegmentPanelArray[2];
                segmentPanel5.Location = mySegmentPanelArray[3];
            }
            else if (x > 120 && x < 230 && y > 98 && y < 138)
            {
                segmentPanel2.Location = mySegmentPanelArray[0];
                segmentPanel3.Location = mySegmentPanelArray[1];
                segmentPanel4.Location = mySegmentPanelArray[2];
                segmentPanel5.Location = mySegmentPanelArray[3];
                segmentPanel6.Location = mySegmentPanelArray[4];
            }
            else if (x > 5 && x < 115 && y > 144 && y < 184)
            {
                segmentPanel2.Location = mySegmentPanelArray[0];
                segmentPanel3.Location = mySegmentPanelArray[1];
                segmentPanel4.Location = mySegmentPanelArray[2];
                segmentPanel5.Location = mySegmentPanelArray[3];
                segmentPanel6.Location = mySegmentPanelArray[4];
                segmentPanel7.Location = mySegmentPanelArray[5];
            }
            else if (x > 120 && x < 230 && y > 144 && y < 184)
            {
                //result = 8;
            }
            else if (x > 5 && x < 115 && y > 190 && y < 230)
            {
                //result = 9;
            }
            else if (x > 120 && x < 230 && y > 190 && y < 230)
            {
                //result = 10;
            }
            else if (x > 5 && x < 115 && y > 236 && y < 276)
            {
                //result = 11;
            }
            else if (x > 120 && x < 230 && y > 236 && y < 276)
            {
                //result = 12;
            }
            else if (x > 5 && x < 115 && y > 282 && y < 322)
            {
                //result = 13;
            }
            else if (x > 120 && x < 230 && y > 282 && y < 322)
            {
                //result = 14;
            }
            else if (x > 5 && x < 115 && y > 328 && y < 348)
            {
                //result = 15;
            }
            else if (x > 120 && x < 230 && y > 328 && y < 348)
            {
                //result = 16;
            }
            else if (x > 5 && x < 115 && y > 374 && y < 414)
            {
                //result = 17;
            }
            else if (x > 120 && x < 230 && y > 374 && y < 414)
            {
                //result = 18;
            }
            
            */
        }

        private void segmentPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            //segmentPanel1.Left = mySegmentPanelArray[1].X;
            //segmentPanel1.Top = mySegmentPanelArray[1].Y;
            //segmentPanel1.Left = e.X + segmentPanel1.Left - MouseDownLocation.X;
            //segmentPanel1.Top = e.Y + segmentPanel1.Top - MouseDownLocation.Y;


            if (e.X > 120 && e.X < 230 && e.Y > 6 && e.Y < 46)
            {
                segmentPanel2.ForeColor = Color.White;
                
            }

            /*
            int mouseLocation = findLocation(e.X, e.Y);
            if (mouseLocation != 0)
            {

                if (mouseLocation == 1)
                {
                    segmentPanel1.Location = mySegmentPanelArray[0];
                    //getLocations();
                }
                else if (mouseLocation == 2)
                {
                    segmentPanel1.Location = mySegmentPanelArray[1];
                    //getLocations();
                }
                else if (mouseLocation == 3)
                {
                    segmentPanel1.Location = mySegmentPanelArray[2];
                    //getLocations();
                }
                else if (mouseLocation == 4)
                {
                    segmentPanel1.Location = mySegmentPanelArray[3];
                    //getLocations();
                }
                else if (mouseLocation == 5)
                {
                    segmentPanel1.Location = mySegmentPanelArray[4];
                }
                else if (mouseLocation == 6)
                {

                }
                else if (mouseLocation == 7)
                {

                }
                else if (mouseLocation == 8)
                {

                }
                else if (mouseLocation == 9)
                {

                }
                else if (mouseLocation == 10)
                {

                }
                else if (mouseLocation == 11)
                {

                }
                else if (mouseLocation == 12)
                {

                }
                else if (mouseLocation == 13)
                {

                }
                else if (mouseLocation == 14)
                {

                }
                else if (mouseLocation == 15)
                {

                }
                else if (mouseLocation == 16)
                {

                }
                else if (mouseLocation == 17)
                {

                }
                else if (mouseLocation == 18)
                {

                }
            }
            else
            {
                segmentPanel1.Location = mySegmentPanelArray[0];
            }
            */
        }

        private void segmentLabel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void segmentLabel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void segmentLabel1_MouseUp(object sender, MouseEventArgs e)
        {

        }
        #endregion
        
        /*
         *
         *   Tab Buttons
         * 
         */
        #region Tab Buttons
        private void textTabLabel_MouseEnter(object sender, EventArgs e)
        {
            textTabLabel.ForeColor = Color.DeepSkyBlue;
        }

        private void textTabLabel_MouseLeave(object sender, EventArgs e)
        {
            if (textTabLabel.BackColor == Color.White)
            {
                textTabLabel.ForeColor = Color.Black;
            }
            else
            {
                textTabLabel.ForeColor = Color.White;
            }
        }

        private void imageTabLabel_MouseEnter(object sender, EventArgs e)
        {
            imageTabLabel.ForeColor = Color.DeepSkyBlue;
        }

        private void imageTabLabel_MouseLeave(object sender, EventArgs e)
        {
            if (imageTabLabel.BackColor == Color.White)
            {
                imageTabLabel.ForeColor = Color.Black;
            }
            else
            {
                imageTabLabel.ForeColor = Color.White;
            }
        }

        private void textTabLabel_Click(object sender, EventArgs e)
        {
            textTabLabel.BackColor = Color.White;
            textTabLabel.ForeColor = Color.Black;
            imageTabLabel.BackColor = darkerGray;
            imageTabLabel.ForeColor = Color.White;

        }

        private void imageTabLabel_Click(object sender, EventArgs e)
        {
            imageTabLabel.BackColor = Color.White;
            imageTabLabel.ForeColor = Color.Black;
            textTabLabel.BackColor = darkerGray;
            textTabLabel.ForeColor = Color.White;
        }

        private void textTabLabel_BackColorChanged(object sender, EventArgs e)
        {
            //Active
            if (textTabLabel.BackColor == Color.White)
            {
                textPanel.Visible = true;
            }
            else
            {
                textPanel.Visible = false;
            }
        }

        private void specialEffectButton_CheckedChanged(object sender, EventArgs e)
        {
            if (specialEffectButton.Checked == true)
            {
                entranceEffectLabel.Visible = true;
                entranceEffectComboBox.Visible = true;
                staticEffectLabel.Visible = true;
                staticEffectComboBox.Visible = true;
                exitEffectLabel.Visible = true;
                exitEffectComboBox.Visible = true;
            }
            
        }

        private void scrollingTextButton_CheckedChanged(object sender, EventArgs e)
        {
            if (scrollingTextButton.Checked == true)
            {
                entranceEffectLabel.Visible = false;
                entranceEffectComboBox.Visible = false;
                staticEffectLabel.Visible = false;
                staticEffectComboBox.Visible = false;
                exitEffectLabel.Visible = false;
                exitEffectComboBox.Visible = false;
            }
        }
        
        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            noTextPopUp.Visible = false;
            //Test which segment button is active
            if (segmentPanel18.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[17].messageText = textTextBox.Text;
            }
            else if (segmentPanel17.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[16].messageText = textTextBox.Text;
            }
            else if (segmentPanel16.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[15].messageText = textTextBox.Text;
            }
            else if (segmentPanel15.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[14].messageText = textTextBox.Text;
            }
            else if (segmentPanel14.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[13].messageText = textTextBox.Text;
            }
            else if (segmentPanel13.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[12].messageText = textTextBox.Text;
            }
            else if (segmentPanel12.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[11].messageText = textTextBox.Text;
            }
            else if (segmentPanel11.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[10].messageText = textTextBox.Text;
            }
            else if (segmentPanel10.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[9].messageText = textTextBox.Text;
            }
            else if (segmentPanel9.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[8].messageText = textTextBox.Text;
            }
            else if (segmentPanel8.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[7].messageText = textTextBox.Text;
            }
            else if (segmentPanel7.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[6].messageText = textTextBox.Text;
            }
            else if (segmentPanel6.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[5].messageText = textTextBox.Text;
            }
            else if (segmentPanel5.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[4].messageText = textTextBox.Text;
            }
            else if (segmentPanel4.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[3].messageText = textTextBox.Text;
            }
            else if (segmentPanel3.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[2].messageText = textTextBox.Text;
            }
            else if (segmentPanel2.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[1].messageText = textTextBox.Text;
            }
            else if (segmentPanel1.BackColor == Color.DeepSkyBlue)
            {
                mySegmentArray[0].messageText = textTextBox.Text;
            }
        }
        #endregion
    }
}
