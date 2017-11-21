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
using System.Runtime.InteropServices;

namespace Vision
{
    public partial class UIForm : Form
    {
        private Thread myDisplayThread = null;
        private Segment[] mySegmentArray = new Segment[24];
        private Color darkerGray = new Color();
        private Color lightGray = new Color();
        private Color activeColor = new Color();
        private int activeIndex;
        private Point mouseDownLocation;
        private Color marqueeBackgroundColor = Color.Black;
        //holds the last visible segment for backToMenuButton
        private int lastSegmentVisable;
        private Panel[] segmentPanels = new Panel[24];
        private Label[] segmentLabels = new Label[24];
        private Button[] segmentButtons = new Button[24];
        private Button[] addSegmentButtons = new Button[24];

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
            activeColor = Color.DeepSkyBlue;
            for (int i = 0; i < 24; i++)
            {
                mySegmentArray[i] = new Segment();
            }

            InitializeComponent();
            int x = 5;
            int y = 6;
            int x2 = 60;
            int y2 = 14;
            for (int i = 0; i < 24; i++)
            {
                if (i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21)
                {
                    x = 5;
                    x2 = 50;
                    y += 46;
                    y2 += 46;
                }
                else if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22)
                {
                    x = 120;
                    x2 = 165;
                }
                else if (i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23)
                {
                    x = 235;
                    x2 = 280;
                }
                segmentLabels[i] = new System.Windows.Forms.Label();
                segmentButtons[i] = new System.Windows.Forms.Button();
                segmentPanels[i] = new System.Windows.Forms.Panel();
                if (i == 0)
                {
                    //The first segment will be automatically added. (no need for a button)
                }
                else
                {
                    addSegmentButtons[i] = new System.Windows.Forms.Button();
                    // 
                    // Create addSegmentButtons
                    // 
                    addSegmentButtons[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                    addSegmentButtons[i].BackColor = System.Drawing.Color.Gray;
                    addSegmentButtons[i].FlatAppearance.BorderColor = System.Drawing.Color.Gray;
                    addSegmentButtons[i].Location = new System.Drawing.Point(x2, y2);
                    addSegmentButtons[i].Size = new System.Drawing.Size(25, 25);
                    addSegmentButtons[i].TabIndex = 14;
                    addSegmentButtons[i].Text = "+";
                    addSegmentButtons[i].UseVisualStyleBackColor = false;
                    addSegmentButtons[i].Visible = false;
                    addSegmentButtons[i].Click += new System.EventHandler(addSegmentClickEvent);
                    addSegmentButtons[i].BringToFront();
                }
                SegmentHolderPanel.Controls.Add(addSegmentButtons[i]);
                SegmentHolderPanel.Controls.Add(segmentPanels[i]);
                // 
                // Create Segment Panels
                // 
                segmentPanels[i].BackColor = System.Drawing.Color.Gray;
                segmentPanels[i].Controls.Add(segmentLabels[i]);
                segmentPanels[i].Controls.Add(segmentButtons[i]);
                segmentPanels[i].Location = new System.Drawing.Point(x, y);
                segmentPanels[i].Size = new System.Drawing.Size(110, 40);
                segmentPanels[i].TabIndex = 14;
                segmentPanels[i].Visible = false;
                segmentPanels[i].Click += new System.EventHandler(segmentClickEvent);
                // 
                // Create Segment Label
                // 
                segmentLabels[i].AutoSize = true;
                segmentLabels[i].ForeColor = System.Drawing.Color.White;
                segmentLabels[i].Location = new System.Drawing.Point(17, 11);
                segmentLabels[i].Size = new System.Drawing.Size(58, 13);
                segmentLabels[i].TabIndex = 8;
                segmentLabels[i].Text = "Segment " + (i + 1);
                segmentLabels[i].Click += new System.EventHandler(segmentClickEvent);
                // 
                // Create Segment Close Buttons
                // 
                segmentButtons[i].BackColor = System.Drawing.Color.Transparent;
                segmentButtons[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                segmentButtons[i].FlatAppearance.BorderSize = 0;
                segmentButtons[i].FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
                segmentButtons[i].FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
                segmentButtons[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                segmentButtons[i].ForeColor = System.Drawing.Color.White;
                segmentButtons[i].Location = new System.Drawing.Point(87, 0);
                segmentButtons[i].Size = new System.Drawing.Size(23, 23);
                segmentButtons[i].TabIndex = 7;
                segmentButtons[i].Text = "X";
                segmentButtons[i].UseVisualStyleBackColor = false;
            }
            
            //getLocations();
            activeIndex = 0;
            segmentPanels[0].Visible = true;
            segmentPanels[0].BackColor = activeColor;

            addSegmentButtons[1].Visible = true;
        }
        
        private void UIForm_Load(object sender, EventArgs e)
        {
            
        }

        private void segmentClickEvent(object sender, EventArgs e)
        {
            //Util.Animate(segmentPanels[0], Util.Effect.Slide, 150, 180);
            for (int i = 0; i < 24; i++)
            {
                if (mouseIsOverPanel(segmentPanels[i]) || mouseIsOverLabel(segmentLabels[i]))
                {
                    activeIndex = i;
                    resetSegments();
                    //leave loop
                    i = 24;
                }
            }
        }

        private void addSegmentClickEvent(object sender, EventArgs e)
        {
            for (int i = 1; i < 24; i++)
            {
                if (mouseIsOverButton(addSegmentButtons[i]))
                {
                    activeIndex = i;
                    segmentPanels[i].Visible = true;
                    resetSegments();
                    addSegmentButtons[i].Visible = false;
                    addSegmentButtons[i + 1].Visible = true;
                    //leave loop
                    i = 24;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pauseButton.Visible = true;
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
            Segment mySegment = new Segment("DISCOVERY", Color.Red, 20000, 4, 4, 4, Color.Red, 4);
            Segment mySecondSegment = new Segment("Discovery", Color.Aqua, true, 25, Color.Aqua, 3);
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
        /*
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
        */
        
        private void clearForMarquee()
        {
            //If it starts from 0 it will continue to overwrite until no more segments are visible
            for (int i = 0; i < 24; i++)
            {
                if (segmentPanels[i].Visible == true)
                {
                    lastSegmentVisable = i;
                }
            }
            populateMarqueeButton.Visible = false; //REMOVE
            SegmentHolderPanel.Visible = false;
            loadXMLButton.Visible = false;
            logoLabel.Visible = false;
            textTabLabel.Visible = false;
            imageTabLabel.Visible = false;
            textPanel.Visible = false;
            imagePanel.Visible = false;
            marqueeBackgroundColorLabel.Visible = false;
            marqueeBackgroundColorButton.Visible = false;
            saveAndRunButton.Visible = false;
        }

        
        private void openMenu()
        {
            populateMarqueeButton.Visible = true; //REMOVE
            SegmentHolderPanel.Visible = true;
            loadXMLButton.Visible = true;
            logoLabel.Visible = true;
            textTabLabel.Visible = true;
            imageTabLabel.Visible = true;
            textPanel.Visible = true;
            imagePanel.Visible = true;
            marqueeBackgroundColorLabel.Visible = true;
            marqueeBackgroundColorButton.Visible = true;
            playButton.Visible = false;
            pauseButton.Visible = false;
            saveAndRunButton.Visible = true;
            resetSegments();
            backToMenuButton.Visible = false;
            this.Size = new System.Drawing.Size(1219, 513);
        }
        private bool mouseIsOverPanel(Panel pnl)
        {
            if (pnl.ClientRectangle.Contains(pnl.PointToClient(Cursor.Position)))
            {
                return true;
            }
            return false;
        }

        private bool mouseIsOverButton(Button btn)
        {
            if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
            {
                return true;
            }
            return false;
        }

        private bool mouseIsOverLabel(Label label)
        {
            if (label.ClientRectangle.Contains(label.PointToClient(Cursor.Position)))
            {
                return true;
            }
            return false;
        }
        #endregion

        /*
         *
         *   Animations
         * 
         */
        #region Animations
        public static class Util
        {
            public enum Effect { Roll, Slide, Center, Blend }

            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];
                if (ctl.Visible) { flags |= 0x10000; angle += 180; }
                else
                {
                    if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                    else if (effect == Effect.Blend) throw new ArgumentException();
                }
                flags |= dirmap[(angle % 360) / 45];
                bool ok = AnimateWindow(ctl.Handle, msec, flags);
                if (!ok) throw new Exception("Animation failed");
                ctl.Visible = !ctl.Visible;
            }

            private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
            private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

            [DllImport("user32.dll")]
            private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
        }
        #endregion

        /*
         *
         *   UI Buttons
         * 
         */
        #region UI Buttons
        private void marqueeBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (marqueeBackgroundColorDialogBox.ShowDialog() == DialogResult.OK)
            {
                marqueeBackgroundColor = marqueeBackgroundColorDialogBox.Color;
                marqueeBackgroundColorButton.BackColor = marqueeBackgroundColorDialogBox.Color;
            }
        }
        #endregion

        /*
         * 
         *   Segment Buttons
         * 
         */
        #region Segment Buttons
        private void resetSegments()
        {
            //set everything to default
            segmentPanels[0].BackColor = Color.Gray;
            segmentPanels[1].BackColor = Color.Gray;
            segmentPanels[2].BackColor = Color.Gray;
            segmentPanels[3].BackColor = Color.Gray;
            segmentPanels[4].BackColor = Color.Gray;
            segmentPanels[5].BackColor = Color.Gray;
            segmentPanels[6].BackColor = Color.Gray;
            segmentPanels[7].BackColor = Color.Gray;
            segmentPanels[8].BackColor = Color.Gray;
            segmentPanels[9].BackColor = Color.Gray;
            segmentPanels[10].BackColor = Color.Gray;
            segmentPanels[11].BackColor = Color.Gray;
            segmentPanels[12].BackColor = Color.Gray;
            segmentPanels[13].BackColor = Color.Gray;
            segmentPanels[14].BackColor = Color.Gray;
            segmentPanels[15].BackColor = Color.Gray;
            segmentPanels[16].BackColor = Color.Gray;
            segmentPanels[17].BackColor = Color.Gray;
            textTextBox.Text = "";
            colorButton.BackColor = lightGray;
            specialEffectButton.Checked = false;
            scrollingTextButton.Checked = false;
            entranceEffectComboBox.Text = "";
            staticEffectComboBox.Text = "";
            exitEffectComboBox.Text = "";
            scrollSpeedControl.Value = 0;
            randomColorCheckBox.Checked = false;
            borderEffectComboBox.Text = "";
            borderColorButton.BackColor = lightGray;
            segmentPanels[activeIndex].BackColor = activeColor;

            //Fill information into the text and image tabs
            //Adds the text thats saved in the segment, into the TextBox
            textTextBox.Text = mySegmentArray[activeIndex].messageText;
            displayDurationControl.Value = (mySegmentArray[activeIndex].segmentSpeed / 1000);
            colorButton.BackColor = mySegmentArray[activeIndex].onColor;
            if (mySegmentArray[activeIndex].ignore == true)
            {
                ignoreCheckBox.Checked = false;
            }
            else
            {
                ignoreCheckBox.Checked = true;
            }
            if (mySegmentArray[activeIndex].isScrolling == true)
            {
                scrollingTextButton.Checked = true;
                scrollSpeedControl.Value = mySegmentArray[activeIndex].scrollSpeed;
                if (mySegmentArray[activeIndex].isRandomColorScrolling == true)
                {
                    randomColorCheckBox.Checked = true;
                }
            }
            else if (mySegmentArray[activeIndex].entranceEffect != 0 || mySegmentArray[activeIndex].middleEffect != 0 || mySegmentArray[activeIndex].exitEffect != 0)
            {
                specialEffectButton.Checked = true;
                //Sets values for Effect combo boxes
                setEntranceEffectText();
                setMiddleEffectText();
                setExitEffectText();
            }
            setBorderEffectText();
            borderColorButton.BackColor = mySegmentArray[activeIndex].borderColor;
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
        /*
        private void segmentPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //moves the selected panel to the top so it doesnt go behind other panels while being dragged.
            segmentPanel1.BringToFront();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }
        */
        /*
        private void segmentPanel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                segmentPanel1.Left = e.X + segmentPanel1.Left - mouseDownLocation.X;
                segmentPanel1.Top = e.Y + segmentPanel1.Top - mouseDownLocation.Y;
            }
        }
        */
        /*
        //Save for later
        private void segmentMoveAnimation(Panel panel, Point a, Point b)
        {

            for (int i = 0; i < 23; i++)
            {
                panel.Left = a.X + 5;
                
                //if (a.X < b.X)
                //{
                //    panel.Left = a.X + 1;
                //    a.X += 1;
                //}
                //if (a.Y < b.Y)
                //{
                //    panel.Top = a.Y + 1;
                //    a.Y += 1;
                //}
                
            }
        }
        */
        /*
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
                    
                    //if (a.X < b.X)
                    //{
                    //    panel.Left = a.X + 1;
                    //    a.X += 1;
                    //}
                    //if (a.Y < b.Y)
                    //{
                    //    panel.Top = a.Y + 1;
                    //    a.Y += 1;
                    //}
                    
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
        */
        private void tempop (int moreingIndex, int moreToIndex)
        {
            // call 2 other methods
        }

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
            imagePanel.Visible = false;
            textPanel.Visible = true;
            textPanel.Controls.Add(ignoreCheckBox);
            displayDurationLabel.Location = new Point(14, 63);
            textPanel.Controls.Add(displayDurationLabel);
            createASegmentGroupBox.Controls.Add(displayDurationLabel);
            displayDurationControl.Location = new Point(104, 59);
            textPanel.Controls.Add(displayDurationControl);
            createASegmentGroupBox.Controls.Add(displayDurationControl);
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
            if (textTextBox.Text.Length > 9)
            {
                scrollingTextButton.Checked = true;
                specialEffectButton.Visible = false;
                longTextPopUp.Visible = true;
            }
            else
            {
                longTextPopUp.Visible = false;
                specialEffectButton.Visible = true;
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
            textPanel.Visible = false;
            imagePanel.Visible = true;
            imagePanel.Controls.Add(ignoreCheckBox);
            imagePanel.Controls.Add(displayDurationLabel);
            displayDurationLabel.Location = new Point (12, 21);
            imagePanel.Controls.Add(displayDurationControl);
            displayDurationControl.Location = new Point(102, 18);
        }

        private void displayDurationControl_ValueChanged(object sender, EventArgs e)
        {
            int input = (int)Math.Floor(displayDurationControl.Value) * 1000;
            mySegmentArray[activeIndex].segmentSpeed = input;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            int size = -1;

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                int segmentSpeed = mySegmentArray[activeIndex].segmentSpeed;
                string filename = openFileDialog.FileName;
                fileLocationTextBox.Text = filename;
                mySegmentArray[activeIndex] = new Segment(filename, segmentSpeed);
            }
        }
        #endregion

        /*
         *
         *   Border Options
         * 
         */
        #region Border Options
        private void borderColorButton_Click(object sender, EventArgs e)
        {
            if (borderColorDialogBox.ShowDialog() == DialogResult.OK)
            {
                mySegmentArray[activeIndex].borderColor = borderColorDialogBox.Color;
                borderColorButton.BackColor = borderColorDialogBox.Color;
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
                exitEffectComboBox.Text = "Static";
            }
            else if (mySegmentArray[activeIndex].borderEffect == 2)
            {
                exitEffectComboBox.Text = "Rotate";
            }
            else
            {
                exitEffectComboBox.Text = "";
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
                    myDisplayThread.Suspend();
                    myDisplayThread.Resume();
                    myDisplayThread.Abort();
                }
            }
            marquee1.borderThreadAbort();
            marquee1.clearMarquee(marquee1.BackColor);
            marquee1.clearBorder(marquee1.BackColor);

            //show menu
            openMenu();
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
            pauseButton.Visible = true;
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
            Message myMessage = new Vision.Message(mySegmentArray, marqueeBackgroundColor);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
            myDisplayThread.Start();
            //create XML file
        }
        #endregion

        /*
         * 
         *   XML Methods
         * 
         */
        #region XML Methods

        //Don't know what parameters you will need
        //Save all fields but "filename" and the "messageMatrix" in every segment object in array
        //Also save the marqueeBackgroundColor from this class
        public void saveXML()
        {

        }

        public void loadXML()
        {

        }

        #endregion

        /*
         * 
         *   Marquee Control Buttons
         * 
         */
        #region Marquee Control Buttons
        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            pauseButton.Visible = true;
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    if (myDisplayThread.ThreadState == ThreadState.Suspended)
                    {
                        myDisplayThread.Resume();
                    }
                }
                else
                {
                    Message myMessage = new Vision.Message(mySegmentArray, marqueeBackgroundColor);
                    myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
                    myDisplayThread.Start();
                }
            }
            marquee1.borderThreadResume();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pauseButton.Visible = false;
            playButton.Visible = true;
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Suspend();
                }
            }
            marquee1.borderThreadSuspend();
        }
        #endregion

        private void logoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}