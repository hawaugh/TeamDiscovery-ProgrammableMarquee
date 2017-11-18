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
        private int activeIndex;
        private Point MouseDownLocation;

        //Getting setup for movable segments
        //Holder for the location for all SegmentPanels
        private Point[] mySegmentPanelArray = new Point[18];
        //Holder for all locations in order
        private Point[] mySegmentPanelArrayLoc;
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
            activeIndex = 0;

            mySegmentArray[activeIndex].ignore = false;
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
            marquee1.borderThreadAbort();
            clearForMarquee();
            backToMenuButton.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            marquee1.Visible = true;
            Segment mySegment = new Segment();
            mySegment.messageText = "Test";
            mySegment.onColor = Color.Aqua;
            mySegment.segmentSpeed = 4000;
            mySegment.entranceEffect = 0;
            mySegment.middleEffect = 0;
            mySegment.exitEffect = 0;
            mySegment.borderEffect = 1;
            mySegment.borderColor = Color.Red;
            // Testing Segment mySegment = new Segment("TEAM", Color.Red, 2000, 0, 0, 0, Color.Red, 1);
            Segment mySecondSegment = new Segment("Discovery", Color.Aqua, true, 25, Color.Aqua, 1);
            Segment myImageSegment = new Segment("..\\..\\panthers.jpg", 10000);
            Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4080, 4, 2, 4, Color.Green, 1);
            mySegmentArray = new Segment[] { mySegment, mySecondSegment, myImageSegment, myThirdSegment };
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
            myDisplayThread.Start();
            
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

            //Holder for all locations in order
            mySegmentPanelArrayLoc = mySegmentPanelArray;
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

        private bool mouseIsOverPanel(Panel pnl)
        {
            if (pnl.ClientRectangle.Contains(pnl.PointToClient(Cursor.Position)))
            {
                return true;
            }
            return false;
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
            activeIndex = 1;
            resetSegments();
            segmentPanel2.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Sets ignore Check Box to the correct option
            if (mySegmentArray[activeIndex].ignore == true)
            {
                ignoreCheckBox.Checked = false;
            }
            else
            {
                ignoreCheckBox.Checked = true;
            }
            //Sets values for Effect combo boxes
            setEntranceEffectText();
            setMiddleEffectText();
            setExitEffectText();
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
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
            activeIndex = 2;
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            if (mySegmentArray[activeIndex].ignore == true)
            {
                ignoreCheckBox.Checked = false;
            }
            else
            {
                ignoreCheckBox.Checked = true;
            }
            //Sets values for Effect combo boxes
            setEntranceEffectText();
            setMiddleEffectText();
            setExitEffectText();
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton3_Click(object sender, EventArgs e)
        {
            addSegmentButton3.Visible = false;
            segmentPanel4.Visible = true;
            addSegmentButton4.Visible = true;
            activeIndex = 3;
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton4_Click(object sender, EventArgs e)
        {
            addSegmentButton4.Visible = false;
            segmentPanel5.Visible = true;
            addSegmentButton5.Visible = true;
            activeIndex = 4;
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton5_Click(object sender, EventArgs e)
        {
            addSegmentButton5.Visible = false;
            segmentPanel6.Visible = true;
            addSegmentButton6.Visible = true;
            activeIndex = 5;
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton6_Click(object sender, EventArgs e)
        {
            addSegmentButton6.Visible = false;
            segmentPanel7.Visible = true;
            addSegmentButton7.Visible = true;
            activeIndex = 6;
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton7_Click(object sender, EventArgs e)
        {
            addSegmentButton7.Visible = false;
            segmentPanel8.Visible = true;
            addSegmentButton8.Visible = true;
            activeIndex = 7;
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton8_Click(object sender, EventArgs e)
        {
            addSegmentButton8.Visible = false;
            segmentPanel9.Visible = true;
            addSegmentButton9.Visible = true;
            activeIndex = 8;
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton9_Click(object sender, EventArgs e)
        {
            addSegmentButton9.Visible = false;
            segmentPanel10.Visible = true;
            addSegmentButton10.Visible = true;
            activeIndex = 9;
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton10_Click(object sender, EventArgs e)
        {
            addSegmentButton10.Visible = false;
            segmentPanel11.Visible = true;
            addSegmentButton11.Visible = true;
            activeIndex = 10;
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton11_Click(object sender, EventArgs e)
        {
            addSegmentButton11.Visible = false;
            segmentPanel12.Visible = true;
            addSegmentButton12.Visible = true;
            activeIndex = 11;
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton12_Click(object sender, EventArgs e)
        {
            addSegmentButton12.Visible = false;
            segmentPanel13.Visible = true;
            addSegmentButton13.Visible = true;
            activeIndex = 12;
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton13_Click(object sender, EventArgs e)
        {
            addSegmentButton13.Visible = false;
            segmentPanel14.Visible = true;
            addSegmentButton14.Visible = true;
            activeIndex = 13;
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton14_Click(object sender, EventArgs e)
        {
            addSegmentButton14.Visible = false;
            segmentPanel15.Visible = true;
            addSegmentButton15.Visible = true;
            activeIndex = 14;
            resetSegments();
            segmentPanel15.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton15_Click(object sender, EventArgs e)
        {
            addSegmentButton15.Visible = false;
            segmentPanel16.Visible = true;
            addSegmentButton16.Visible = true;
            activeIndex =  15;
            resetSegments();
            segmentPanel16.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton16_Click(object sender, EventArgs e)
        {
            addSegmentButton16.Visible = false;
            segmentPanel17.Visible = true;
            addSegmentButton17.Visible = true;
            activeIndex = 16;
            resetSegments();
            segmentPanel17.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void addSegmentButton17_Click(object sender, EventArgs e)
        {
            addSegmentButton17.Visible = false;
            segmentPanel18.Visible = true;
            activeIndex = 17;
            resetSegments();
            segmentPanel18.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
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
            segmentPanel15.BackColor = Color.Gray;
            segmentPanel16.BackColor = Color.Gray;
            segmentPanel17.BackColor = Color.Gray;
            segmentPanel18.BackColor = Color.Gray;
        }

        private void segmentPanel1_Click(object sender, EventArgs e)
        {
            activeIndex = 0;
            resetSegments();
            segmentPanel1.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            if (mySegmentArray[activeIndex].ignore == true)
            {
                ignoreCheckBox.Checked = false;
            }
            else
            {
                ignoreCheckBox.Checked = true;
            }
            //Sets values for Effect combo boxes
            setEntranceEffectText();
            setMiddleEffectText();
            setExitEffectText();
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel2_Click(object sender, EventArgs e)
        {
            activeIndex = 1;
            resetSegments();
            segmentPanel2.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            if (mySegmentArray[activeIndex].ignore == true)
            {
                ignoreCheckBox.Checked = false;
            }
            else
            {
                ignoreCheckBox.Checked = true;
            }
            //Sets values for Effect combo boxes
            setEntranceEffectText();
            setMiddleEffectText();
            setExitEffectText();
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel3_Click(object sender, EventArgs e)
        {
            activeIndex = 2;
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel4_Click(object sender, EventArgs e)
        {
            activeIndex = 3;
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel5_Click(object sender, EventArgs e)
        {
            activeIndex = 4;
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel6_Click(object sender, EventArgs e)
        {
            activeIndex = 5;
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel7_Click(object sender, EventArgs e)
        {
            activeIndex = 6;
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel8_Click(object sender, EventArgs e)
        {
            activeIndex = 7; 
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel9_Click(object sender, EventArgs e)
        {
            activeIndex = 8;
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel10_Click(object sender, EventArgs e)
        {
            activeIndex = 9;
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel11_Click(object sender, EventArgs e)
        {
            activeIndex = 10;
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel12_Click(object sender, EventArgs e)
        {
            activeIndex = 11;
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel13_Click(object sender, EventArgs e)
        {
            activeIndex = 12;
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel14_Click(object sender, EventArgs e)
        {
            activeIndex = 13;
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel15_Click(object sender, EventArgs e)
        {
            activeIndex = 14;
            resetSegments();
            segmentPanel15.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel16_Click(object sender, EventArgs e)
        {
            activeIndex = 15;
            resetSegments();
            segmentPanel16.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel17_Click(object sender, EventArgs e)
        {
            activeIndex = 16;
            resetSegments();
            segmentPanel17.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
        }

        private void segmentPanel18_Click(object sender, EventArgs e)
        {
            activeIndex = 17;
            resetSegments();
            segmentPanel18.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
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

        private void segmentPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //moves the selected panel to the top so it doesnt go behind other panels while being dragged.
            segmentPanel1.BringToFront();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void segmentPanel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                segmentPanel1.Left = e.X + segmentPanel1.Left - MouseDownLocation.X;
                segmentPanel1.Top = e.Y + segmentPanel1.Top - MouseDownLocation.Y;
            }
        }

        //Save for later
        private void segmentMoveAnimation(Panel panel, Point a, Point b)
        {

            for (int i = 0; i < 23; i++)
            {
                panel.Left = a.X + 5;
                /*
                if (a.X < b.X)
                {
                    panel.Left = a.X + 1;
                    a.X += 1;
                }
                if (a.Y < b.Y)
                {
                    panel.Top = a.Y + 1;
                    a.Y += 1;
                }
                */
            }
        }

        private void segmentPanel1_MouseUp(object sender, MouseEventArgs e)
        {

            //segmentPanel1.Left = e.X + segmentPanel1.Left - MouseDownLocation.X;
            //segmentPanel1.Top = e.Y + segmentPanel1.Top - MouseDownLocation.Y;

            if (mouseIsOverPanel(segmentPanel2))
            {
                segmentPanel1.Left = mySegmentPanelArray[1].X;
                segmentPanel1.Top = mySegmentPanelArray[1].Y;

                //segmentPanel2.Left = mySegmentPanelArrayLoc[0].X;
                //segmentPanel2.Top = mySegmentPanelArrayLoc[0].Y;

                for (int i = 0; i < 23; i++)
                {
                    segmentPanel2.Left = segmentPanel2.Left - 5;
                    /*
                    if (a.X < b.X)
                    {
                        panel.Left = a.X + 1;
                        a.X += 1;
                    }
                    if (a.Y < b.Y)
                    {
                        panel.Top = a.Y + 1;
                        a.Y += 1;
                    }
                    */
                    Thread.Sleep(20);
                }
                //segmentMoveAnimation(segmentPanel2, segmentPanel2.Location, segmentPanel1.Location);

            }
            else if (mouseIsOverPanel(segmentPanel3))
            {
                segmentMoveAnimation(segmentPanel1, segmentPanel1.Location, segmentPanel2.Location);
                segmentPanel1.Left = mySegmentPanelArray[2].X;
                segmentPanel1.Top = mySegmentPanelArray[2].Y;
            }
            else if (mouseIsOverPanel(segmentPanel4))
            {
                segmentMoveAnimation(segmentPanel1, segmentPanel1.Location, segmentPanel2.Location);
                segmentPanel1.Left = mySegmentPanelArray[3].X;
                segmentPanel1.Top = mySegmentPanelArray[3].Y;
            }
            else
            {
                //segmentPanel1.Left = mySegmentPanelArray[0].X;
                //segmentPanel1.Top = mySegmentPanelArray[0].Y;
            }
        }

        private void tempop (int moreingIndex, int moreToIndex)
        {
            // call 2 other methods
        }
        #endregion

        /*
         * 
         *   ComboBoxes
         * 
         */
        #region ComboBoxes
        private void entranceEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].entranceEffect = findEntranceEffect(entranceEffectComboBox.Text);
        }

        private int findEntranceEffect(String text)
        {
            if (text == "None")
            {
                return 0;
            }
            else if (text == "Split")
            {
                return 1;
            }
            else if (text == "Scroll Up")
            {
                return 2;
            }
            else if (text == "Scroll Down")
            {
                return 3;
            }
            else if (text == "Random Dots")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        //Stored here so when added new effects everything can be changed in the same place.
        private void setEntranceEffectText()
        {
            if (mySegmentArray[activeIndex].exitEffect == 0)
            {
                exitEffectComboBox.Text = "";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 1)
            {
                exitEffectComboBox.Text = "Split";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 2)
            {
                exitEffectComboBox.Text = "Scroll Up";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 3)
            {
                exitEffectComboBox.Text = "Scroll Down";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 4)
            {
                exitEffectComboBox.Text = "Random Dots";
            }
            else
            {
                exitEffectComboBox.Text = "";
            }
        }

        private void staticEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].middleEffect = findMiddleEffect(staticEffectComboBox.Text);
        }

        private int findMiddleEffect(String text)
        {
            if (text == "None")
            {
                return 0;
            }
            else if (text == "Random Color Dots")
            {
                return 1;
            }
            else if (text == "Fade")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        //Stored here so when added new effects everything can be changed in the same place.
        private void setMiddleEffectText()
        {
            if (mySegmentArray[activeIndex].exitEffect == 0)
            {
                exitEffectComboBox.Text = "";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 1)
            {
                exitEffectComboBox.Text = "Random Color Dots";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 2)
            {
                exitEffectComboBox.Text = "Fade";
            }
            else
            {
                exitEffectComboBox.Text = "";
            }
        }

        private void exitEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].exitEffect = findExitEffect(exitEffectComboBox.Text);
        }

        private int findExitEffect(String text)
        {
            if (text == "None")
            {
                return 0;
            }
            else if (text == "Split")
            {
                return 1;
            }
            else if (text == "Scroll Up")
            {
                return 2;
            }
            else if (text == "Scroll Down")
            {
                return 3;
            }
            else if (text == "Random Dots")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        //Stored here so when added new effects everything can be changed in the same place.
        private void setExitEffectText()
        {
            if (mySegmentArray[activeIndex].exitEffect == 0)
            {
                exitEffectComboBox.Text = "";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 1)
            {
                exitEffectComboBox.Text = "Split";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 2)
            {
                exitEffectComboBox.Text = "Scroll Up";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 3)
            {
                exitEffectComboBox.Text = "Scroll Down";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 4)
            {
                exitEffectComboBox.Text = "Random Dots";
            }
            else
            {
                exitEffectComboBox.Text = "";
            }
        }
        
        private void borderEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].borderEffect = findBorderEffect(borderEffectComboBox.Text);
        }

        private int findBorderEffect(String text)
        {
            if (text == "None")
            {
                return 0;
            }
            else if (text == "Static")
            {
                return 1;
            }
            else if (text == "Rotate")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private void setBorderEffectText()
        {
            if (mySegmentArray[activeIndex].borderEffect == 0)
            {
                exitEffectComboBox.Text = "";
            }
            else if (mySegmentArray[activeIndex].borderEffect == 1)
            {
                exitEffectComboBox.Text = "Rotate";
            }
            else if (mySegmentArray[activeIndex].borderEffect == 2)
            {
                exitEffectComboBox.Text = "Static";
            }
            else
            {
                exitEffectComboBox.Text = "";
            }
        }
        #endregion

        /*
         *
         *   Text Tab
         * 
         */
        #region Text Tab
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

        private void textTabLabel_Click(object sender, EventArgs e)
        {
            textTabLabel.BackColor = Color.White;
            textTabLabel.ForeColor = Color.Black;
            imageTabLabel.BackColor = darkerGray;
            imageTabLabel.ForeColor = Color.White;

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialogBox.ShowDialog() == DialogResult.OK)
            {
                mySegmentArray[activeIndex].onColor = colorDialogBox.Color;
                colorButton.BackColor = colorDialogBox.Color;
            }
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
                mySegmentArray[activeIndex].isScrolling = false;
                //For some reason setting the default value in designer doesnt work. But this fixes it.
                scrollSpeedControl.Value = 0;
                entranceEffectLabel.Visible = true;
                entranceEffectComboBox.Visible = true;
                staticEffectLabel.Visible = true;
                staticEffectComboBox.Visible = true;
                exitEffectLabel.Visible = true;
                exitEffectComboBox.Visible = true;
                scrollSpeedControl.Visible = false;
                scrollSpeedLabel.Visible = false;
                randomColorCheckBox.Visible = false;
            }

        }

        private void scrollingTextButton_CheckedChanged(object sender, EventArgs e)
        {
            if (scrollingTextButton.Checked == true)
            {
                mySegmentArray[activeIndex].isScrolling = true;
                //For some reason setting the default value in designer doesnt work. But this fixes it.
                scrollSpeedControl.Value = 10;
                entranceEffectLabel.Visible = false;
                entranceEffectComboBox.Visible = false;
                staticEffectLabel.Visible = false;
                staticEffectComboBox.Visible = false;
                exitEffectLabel.Visible = false;
                exitEffectComboBox.Visible = false;
                scrollSpeedControl.Visible = true;
                scrollSpeedLabel.Visible = true;
                randomColorCheckBox.Visible = true;
            }
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].messageText = textTextBox.Text;
            //noTextPopUp.Visible = false;
        }
        #endregion

        /*
         *
         *   Image Tab
         * 
         */
        #region Image Tab
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

        private void imageTabLabel_Click(object sender, EventArgs e)
        {
            imageTabLabel.BackColor = Color.White;
            imageTabLabel.ForeColor = Color.Black;
            textTabLabel.BackColor = darkerGray;
            textTabLabel.ForeColor = Color.White;
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
        #endregion

        /*
         * 
         *   Bottom Buttons
         * 
         */
        #region Bottom Buttons
        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Abort();
                }
            }
            marquee1.borderThreadAbort();
            marquee1.clearMarquee(marquee1.BackColor);
            marquee1.clearBorder(marquee1.BackColor);

            //show menu
        }

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
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Abort();
                }
            }
            marquee1.borderThreadAbort();
            clearForMarquee();
            backToMenuButton.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            marquee1.Visible = true;
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
            myDisplayThread.Start();
            //create XML file
        }
        #endregion

        private void ignoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreCheckBox.Checked == false)
            {
                mySegmentArray[activeIndex].ignore = false;
            }
            else if (ignoreCheckBox.Checked == true)
            {
                mySegmentArray[activeIndex].ignore = true;
            }
        }

        private void borderColorButton_Click(object sender, EventArgs e)
        {
            if (borderColorDialogBox.ShowDialog() == DialogResult.OK)
            {
                mySegmentArray[activeIndex].borderColor = borderColorDialogBox.Color;
                borderColorButton.BackColor = borderColorDialogBox.Color;
            }
        }

        private void marqueeBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (marqueeBackgroundColorDialogBox.ShowDialog() == DialogResult.OK)
            {
                marquee1.BackColor = marqueeBackgroundColorDialogBox.Color;
                marqueeBackgroundColorButton.BackColor = marqueeBackgroundColorDialogBox.Color;
            }
        }

        private void scrollSpeedControl_ValueChanged(object sender, EventArgs e)
        {
            int input = (int)Math.Floor(scrollSpeedControl.Value);
            mySegmentArray[activeIndex].scrollSpeed = input;
        }

        private void randomColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomColorCheckBox.Checked == true)
            {
                mySegmentArray[activeIndex].isRandomColorScrolling = true;
                //test is a color option is selected.
                if (colorButton.BackColor != lightGray)
                {
                    //if true. Sets button color back to normal and displays pop up.
                    colorButton.BackColor = lightGray;
                    randomColorPopUp.Visible = true;
                }
            }
            else
            {
                mySegmentArray[activeIndex].isRandomColorScrolling = false;
                //Test if pop up is visible. (randomColorCheckBox is already true)
                if (randomColorPopUp.Visible == true)
                {
                    //if true. removes popup and sets the color option back to normal.
                    randomColorPopUp.Visible = false;
                    colorButton.BackColor = colorDialogBox.Color;
                }
            }
        }
    }
}
