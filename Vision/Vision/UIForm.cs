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
using System.Timers;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace Vision
{
    public partial class UIForm : Form
    {
        private Thread myDisplayThread = null;
        private Thread myPauseInvalidationThread = null;
        private Segment[] mySegmentArray = new Segment[24];
        private Color darkerGray = new Color();
        private Color lightGray = new Color();
        private Color offWhite = new Color();
        private Color activeColor = new Color();
        private int activeIndex;
        private Point mouseDownLocation;
        private Color marqueeBackgroundColor = Color.Black;
        //holds the last visible segment for backToMenuButton
        private int lastSegmentVisable;
        private Panel[] segmentPanels = new Panel[24];
        private Label[] segmentLabels = new Label[24];
        private Label[] segmentReference = new Label[24];
        private Button[] segmentButtons = new Button[24];
        private Button[] addSegmentButtons = new Button[24];
        private Point[] segmentLocationArray = new Point[24];
        private Point[] addSegmentLocationArray = new Point[24];
        private Point a;
        private Point b;
        private int moveFrom;
        private bool clickEvent = true;
        private bool fullScreen = false;
        XmlSerializer xs;
        List<Segment> list;

        public OpenFileDialog openFileDialog { get; private set; }

        public UIForm()
        {
            darkerGray = Color.FromArgb(0, 64, 64, 64);
            lightGray = Color.FromArgb(0, 224, 224, 224);
            offWhite = Color.FromArgb(100, 224, 224, 224);
            activeColor = Color.DeepSkyBlue;
            for (int i = 0; i < 24; i++)
            {
                mySegmentArray[i] = new Segment();
            }

            InitializeComponent();
            int x = 4;
            int y = 4;
            int x2 = 30;
            int y2 = 14;
            for (int i = 0; i < 24; i++)
            {
                if (i == 0)
                {

                }
                else if (i == 12)
                {
                    x = 4;
                    x2 = 30;
                    y += 44;
                    y2 += 44;
                }
                else
                {
                    x += 84;
                    x2 += 84;
                }
                segmentLabels[i] = new System.Windows.Forms.Label();
                segmentReference[i] = new System.Windows.Forms.Label();
                segmentButtons[i] = new System.Windows.Forms.Button();
                segmentPanels[i] = new System.Windows.Forms.Panel();
                if (i == 0)
                {
                    //The first segment will be automatically added. (no need for a button)
                }
                else
                {
                    addSegmentButtons[i] = new System.Windows.Forms.Button();

                    //Create addSegmentButtons
                    createNewAddSegmentButton(i, x2, y2);
                }
                SegmentHolderPanel.Controls.Add(addSegmentButtons[i]);
                SegmentHolderPanel.Controls.Add(segmentPanels[i]);

                // Create Segment Panels
                createNewPanel(i, x, y);

                // Create Segment Label
                createNewLabel(i);

                // Create Segment Reference
                createNewReference(i);

                // Create Segment Close Buttons
                createNewCloseButtons(i);
            }
            getLocations();
            activeIndex = 0;
            segmentPanels[0].Visible = true;
            mySegmentArray[0].ignore = false;
            resetSegments();
            addSegmentButtons[1].Visible = true;
            list = new List<Segment>();
            xs = new XmlSerializer(typeof(List<Segment>));
        }

        private void UIForm_Load(object sender, EventArgs e)
        {

        }

        private void addSegmentClickEvent(object sender, EventArgs e)
        {
            lastSegmentPopUp.Visible = false;
            for (int i = 1; i < 24; i++)
            {
                if (mouseIsOverButton(addSegmentButtons[i]))
                {
                    if (i == 23)
                    {
                        activeIndex = i;
                        segmentPanels[i].Visible = true;
                        addSegmentButtons[i].Visible = false;
                        mySegmentArray[i].ignore = false;
                        resetSegments();
                        //leave loop
                        i = 24;
                    }
                    else
                    {
                        activeIndex = i;
                        segmentPanels[i].Visible = true;
                        addSegmentButtons[i].Visible = false;
                        mySegmentArray[i].ignore = false;
                        resetSegments();
                        addSegmentButtons[i + 1].Visible = true;
                        //leave loop
                        i = 24;
                    }
                }
            }
        }

        private void closeButtonClickEvent(object sender, EventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                if (mouseIsOverButton(segmentButtons[i]))
                {
                    //Test if segment 1 is the only visible segment. Else it can be deleted.
                    if (i == 0 && segmentPanels[1].Visible == false)
                    {
                        lastSegmentPopUp.Visible = true;
                    }
                    else if (i < 23 && segmentPanels[i + 1].Visible == false)
                    {
                        lastSegmentPopUp.Visible = false;
                        deleteSegment(i);
                        activeIndex = i - 1;
                        resetSegments();
                        //leave loop
                        i = 24;
                    }
                    else if (segmentPanels[23].Visible == true && addSegmentButtons[23].Visible == false)
                    {
                        lastSegmentPopUp.Visible = false;
                        deleteSegment(i);
                        addSegmentButtons[23].Visible = true;
                        activeIndex = i;
                        resetSegments();
                        //leave loop
                        i = 24;
                    }
                    else
                    {
                        lastSegmentPopUp.Visible = false;
                        deleteSegment(i);

                        activeIndex = i;
                        resetSegments();
                        //leave loop
                        i = 24;
                    }
                }
            }
        }


        private void mouseDownEvent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            resetSegments();
            for (int i = 0; i < 24; i++)
            {
                if (mouseIsOverPanel(segmentPanels[i]) || mouseIsOverLabel(segmentLabels[i]))
                {
                    if (segmentPanels[i].Visible == true)
                    {
                        activeIndex = i;
                        resetSegments();
                        moveFrom = i;
                        //moves the selected panel to the top so it doesnt go behind other panels while being dragged.
                        segmentPanels[i].BringToFront();
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            mouseDownLocation = e.Location;
                        }
                        i = 24;
                    }
                }
            }
        }

        private void mouseMoveEvent(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                if (segmentPanels[moveFrom].BackColor == activeColor)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        clickEvent = false;
                        segmentPanels[moveFrom].Left = e.X + segmentPanels[moveFrom].Left - mouseDownLocation.X;
                        segmentPanels[moveFrom].Top = e.Y + segmentPanels[moveFrom].Top - mouseDownLocation.Y;
                    }
                    i = 24;
                }
            }
        }

        private void mouseUpEvent(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                //When segments are moved up the for loop hits the moving segment before the segment to move to.
                if (i == moveFrom)
                {
                    //Skip
                }
                else
                {
                    if (segmentPanels[moveFrom].BackColor == activeColor)
                    {
                        if (mouseIsOverPanel(segmentPanels[i]) && segmentPanels[i].Visible == true)
                        {
                            moveSegment(moveFrom, i);
                            i = 24;
                        }
                        //Set back to starting position
                        else
                        {
                            segmentPanels[moveFrom].Left = segmentLocationArray[moveFrom].X;
                            segmentPanels[moveFrom].Top = segmentLocationArray[moveFrom].Y;
                        }
                    }
                }
            }
            clickEvent = true;
        }

        private void createNewPanel(int i, int x, int y)
        {
            // 
            // Create Segment Panels
            // 
            segmentPanels[i].BackColor = System.Drawing.Color.Gray;
            segmentPanels[i].Controls.Add(segmentLabels[i]);
            segmentPanels[i].Controls.Add(segmentReference[i]);
            segmentPanels[i].Controls.Add(segmentButtons[i]);
            segmentPanels[i].Location = new System.Drawing.Point(x, y);
            segmentPanels[i].Size = new System.Drawing.Size(80, 40);
            segmentPanels[i].TabIndex = 14;
            segmentPanels[i].Visible = false;
            segmentPanels[i].MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownEvent);
            segmentPanels[i].MouseMove += new System.Windows.Forms.MouseEventHandler(mouseMoveEvent);
            segmentPanels[i].MouseUp += new System.Windows.Forms.MouseEventHandler(mouseUpEvent);
        }

        private void createNewLabel(int i)
        {
            // 
            // Create Segment Label
            // 
            segmentLabels[i].AutoSize = true;
            segmentLabels[i].ForeColor = System.Drawing.Color.White;
            segmentLabels[i].Location = new System.Drawing.Point(3, 18);
            segmentLabels[i].Size = new System.Drawing.Size(58, 13);
            segmentLabels[i].TabIndex = 8;
            segmentLabels[i].Text = "EMPTY";
            segmentLabels[i].MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownEvent);
            segmentLabels[i].MouseMove += new System.Windows.Forms.MouseEventHandler(mouseMoveEvent);
            segmentLabels[i].MouseUp += new System.Windows.Forms.MouseEventHandler(mouseUpEvent);
        }
        
        private void createNewReference(int i)
        {
            // 
            // Create Segment Reference
            // 
            segmentReference[i].AutoSize = true;
            segmentReference[i].ForeColor = offWhite;
            segmentReference[i].Location = new System.Drawing.Point(1, 1);
            segmentReference[i].Size = new System.Drawing.Size(5, 13);
            segmentReference[i].Font = new Font("Arial", 7, FontStyle.Bold); ;
            segmentReference[i].TabIndex = 9;
            segmentReference[i].Text = (i + 1).ToString();
        }
        
        private void createNewCloseButtons(int i)
        {
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
            segmentButtons[i].Location = new System.Drawing.Point(62, -2);
            segmentButtons[i].Size = new System.Drawing.Size(20, 20);
            segmentButtons[i].TabIndex = 7;
            segmentButtons[i].Text = "X";
            segmentButtons[i].UseVisualStyleBackColor = false;
            segmentButtons[i].Visible = false;
            segmentButtons[i].Click += new System.EventHandler(closeButtonClickEvent);
        }

        private void createNewAddSegmentButton(int i, int x, int y)
        {
            // 
            // Create addSegmentButtons
            // 
            addSegmentButtons[i].Anchor = System.Windows.Forms.AnchorStyles.None;
            addSegmentButtons[i].BackColor = System.Drawing.Color.Gray;
            addSegmentButtons[i].FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            addSegmentButtons[i].Location = new System.Drawing.Point(x, y);
            addSegmentButtons[i].Size = new System.Drawing.Size(25, 25);
            addSegmentButtons[i].TabIndex = 14;
            addSegmentButtons[i].Text = "+";
            addSegmentButtons[i].UseVisualStyleBackColor = false;
            addSegmentButtons[i].Visible = false;
            addSegmentButtons[i].Click += new System.EventHandler(addSegmentClickEvent);
            addSegmentButtons[i].BringToFront();
        }
        
        private void deleteSegment(int deleted)
        {
            segmentPanels[deleted].Visible = false;
            for (int i = 0; i < 24; i++)
            {
                if (i > deleted)
                {
                    mySegmentArray[i - 1] = mySegmentArray[i];
                    segmentPanels[i - 1] = segmentPanels[i];
                    segmentReference[i - 1] = segmentReference[i];
                    segmentLabels[i - 1] = segmentLabels[i];
                    segmentButtons[i - 1] = segmentButtons[i];
                    addSegmentButtons[i - 1] = addSegmentButtons[i];
                    segmentPanels[i].Left = segmentLocationArray[i - 1].X;
                    segmentPanels[i].Top = segmentLocationArray[i - 1].Y;
                    addSegmentButtons[i].Left = addSegmentLocationArray[i - 1].X;
                    addSegmentButtons[i].Top = addSegmentLocationArray[i - 1].Y;
                }
            }
            //Fill arrays with a new object at the end of the Array
            mySegmentArray[23] = new Segment();
            SegmentHolderPanel.Controls.Add(segmentPanels[23]);
            segmentLabels[23] = new System.Windows.Forms.Label();
            segmentReference[23] = new System.Windows.Forms.Label();
            segmentButtons[23] = new System.Windows.Forms.Button();
            segmentPanels[23] = new System.Windows.Forms.Panel();
            addSegmentButtons[23] = new System.Windows.Forms.Button();
            SegmentHolderPanel.Controls.Add(segmentPanels[23]);
            SegmentHolderPanel.Controls.Add(addSegmentButtons[23]);
            createNewLabel(23);
            createNewReference(23);
            createNewCloseButtons(23);
            createNewPanel(23, 928, 49);
            createNewAddSegmentButton(23, 954, 59);
            getLocations();
        }

        private void moveSegment(int movedFrom, int movedTo)
        {
            Segment tempSegment = mySegmentArray[movedFrom];
            Panel tempPanel = segmentPanels[moveFrom];
            Label tempLabel = segmentLabels[moveFrom];
            Button tempButton = segmentButtons[moveFrom];
            Label tempReference = segmentReference[movedFrom];

            //If segment moved down
            if (movedFrom - movedTo < 0)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (i <= movedTo && i > movedFrom)
                    {
                        segmentPanels[i].Left = segmentLocationArray[i - 1].X;
                        segmentPanels[i].Top = segmentLocationArray[i - 1].Y;
                        mySegmentArray[i - 1] = mySegmentArray[i];
                        segmentPanels[i - 1] = segmentPanels[i];
                        segmentLabels[i - 1] = segmentLabels[i];
                        segmentReference[i - 1] = segmentReference[i];
                        segmentButtons[i - 1] = segmentButtons[i];
                    }
                }
            }
            //Else moved segment up
            else
            {
                for (int i = 23; i >= 0; i--)
                {
                    if (i >= movedTo && i < movedFrom)
                    {
                        segmentPanels[i].Left = segmentLocationArray[i + 1].X;
                        segmentPanels[i].Top = segmentLocationArray[i + 1].Y;
                        mySegmentArray[i + 1] = mySegmentArray[i];
                        segmentPanels[i + 1] = segmentPanels[i];
                        segmentLabels[i + 1] = segmentLabels[i];
                        segmentReference[i + 1] = segmentReference[i];
                        segmentButtons[i + 1] = segmentButtons[i];
                    }
                }
            }
            mySegmentArray[movedTo] = tempSegment;
            segmentPanels[movedTo] = tempPanel;
            segmentLabels[movedTo] = tempLabel;
            segmentReference[movedTo] = tempReference;
            segmentButtons[movedTo] = tempButton;
            segmentPanels[movedTo].Left = segmentLocationArray[movedTo].X;
            segmentPanels[movedTo].Top = segmentLocationArray[movedTo].Y;
            getLocations();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            pauseButton.Visible = true;
            abortDisplayThreads();
            clearForMarquee();
            backToMenuButton.Visible = true;
            goToFullScreenButton.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            marquee1.Visible = true;
            EnterFullScreenMode();
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

        private void getLocations()
        {
            for (int i = 0; i < 24; i++)
            {
                if (i == 0)
                {
                    segmentLocationArray[i] = segmentPanels[i].Location;
                }
                else
                {
                    addSegmentLocationArray[i] = addSegmentButtons[i].Location;
                    segmentLocationArray[i] = segmentPanels[i].Location;
                }
            }
            setReferences();
        }

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
            //Test which tab is active and then sets that tab to the front so the open menu is called the correct tab is displayed first
            if (textPanel.Visible == true)
            {
                textPanel.BringToFront();
            }
            else
            {
                imagePanel.BringToFront();
            }
            //populateMarqueeButton.Visible = false; //REMOVE
            SegmentHolderPanel.Visible = false;
            startNewMessageButton.Visible = false;
            loadXMLButton.Visible = false;
            saveButton.Visible = false;
            buildLabel.Visible = false;
            textTabLabel.Visible = false;
            imageTabLabel.Visible = false;
            textPanel.Visible = false;
            imagePanel.Visible = false;
            marqueeBackgroundColorLabel.Visible = false;
            marqueeBackgroundColorButton.Visible = false;
            runButton.Visible = false;
        }


        private void openMenu()
        {
            //populateMarqueeButton.Visible = true; //REMOVE
            SegmentHolderPanel.Visible = true;
            startNewMessageButton.Visible = true;
            //loadXMLButton.Visible = true; //Removed for Beta Build
            //saveButton.Visible = true; //Removed for Beta Build
            textTabLabel.Visible = true;
            imageTabLabel.Visible = true;
            textPanel.Visible = true;
            imagePanel.Visible = true;
            marqueeBackgroundColorLabel.Visible = true;
            marqueeBackgroundColorButton.Visible = true;
            playButton.Visible = false;
            pauseButton.Visible = false;
            goToFullScreenButton.Visible = false;
            marquee1.Visible = false;
            runButton.Visible = true;
            buildLabel.Visible = true;
            resetSegments();
            backToMenuButton.Visible = false;
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(1034, 592);
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

        private void setReferences()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (segmentLocationArray[i] == segmentPanels[j].Location)
                    {
                        segmentReference[j].Text = (i + 1).ToString();
                    }
                }
            }
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
                originalPictureBox.BackColor = marqueeBackgroundColorDialogBox.Color;
                scaledPictureBox.BackColor = marqueeBackgroundColorDialogBox.Color;
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
            for (int i = 0; i < 24; i++)
            {
                segmentPanels[i].BackColor = Color.Gray;
                segmentButtons[i].Visible = false;
            }
            segmentPanels[activeIndex].BackColor = activeColor;
            segmentButtons[activeIndex].Visible = true;


            //Fill information into the text and image tabs
            if (mySegmentArray[activeIndex].isImage == false && mySegmentArray[activeIndex].messageText == "")
            {
                textTextBox.Text = mySegmentArray[activeIndex].messageText;
                segmentLabels[activeIndex].Text = "EMPTY";
            }
            else
            {
                textTextBox.Text = mySegmentArray[activeIndex].messageText;
            }
            fileLocationTextBox.Text = mySegmentArray[activeIndex].filename;
            originalPictureBox.Image = (Image)mySegmentArray[activeIndex].originalBitmap;
            originalPictureBox.BackColor = marqueeBackgroundColor;
            scaledPictureBox.Image = (Image)mySegmentArray[activeIndex].scaledBitmap;
            scaledPictureBox.BackColor = marqueeBackgroundColor;
            originalPictureBox.Invalidate();
            displayDurationControl.Value = (mySegmentArray[activeIndex].segmentSpeed / 1000);
            colorButton.BackColor = mySegmentArray[activeIndex].onColor;
            if (mySegmentArray[activeIndex].ignore == true)
            {
                ignoreCheckBox.Checked = true;
            }
            else
            {
                ignoreCheckBox.Checked = false;
            }
            if (mySegmentArray[activeIndex].isImage == true)
            {
                //Set everything in Image to active
                imageTabLabel.BackColor = Color.White;
                imageTabLabel.ForeColor = Color.Black;
                textTabLabel.BackColor = darkerGray;
                textTabLabel.ForeColor = Color.White;
                textPanel.Visible = false;
                imagePanel.Visible = true;
                imagePanel.Controls.Add(ignoreCheckBox);
                imagePanel.Controls.Add(displayDurationLabel);
                displayDurationLabel.Location = new Point(12, 28);
                imagePanel.Controls.Add(displayDurationControl);
                displayDurationControl.Location = new Point(102, 26);
            }
            else
            {
                textTabLabel.BackColor = Color.White;
                textTabLabel.ForeColor = Color.Black;
                imageTabLabel.BackColor = darkerGray;
                imageTabLabel.ForeColor = Color.White;
                imagePanel.Visible = false;
                textPanel.Visible = true;
                textPanel.Controls.Add(ignoreCheckBox);
                displayDurationLabel.Location = new Point(14, 109);
                textPanel.Controls.Add(displayDurationLabel);
                createASegmentGroupBox.Controls.Add(displayDurationLabel);
                displayDurationControl.Location = new Point(104, 105);
                textPanel.Controls.Add(displayDurationControl);
                createASegmentGroupBox.Controls.Add(displayDurationControl);

                if (mySegmentArray[activeIndex].isScrolling == true)
                {
                    scrollingTextButton.Checked = true;
                    scrollSpeedControl.Value = (decimal)((double)mySegmentArray[activeIndex].scrollSpeed / 100);
                    if (mySegmentArray[activeIndex].isRandomColorScrolling == true)
                    {
                        randomColorCheckBox.Checked = true;
                    }
                }
                else
                {
                    specialEffectButton.Checked = true;
                    //Sets values for Effect combo boxes
                    setEntranceEffectText();
                    setMiddleEffectText();
                    setExitEffectText();
                }
                borderColorButton.BackColor = mySegmentArray[activeIndex].borderColor;
                setBorderEffectText();
            }
            
        }

        private int findLocation(double x, double y)
        {
            return 0;
        }

        private void tempop(int moreingIndex, int moreToIndex)
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
            setEntranceEffectText();
        }

        private int findEntranceEffect(String text)
        {
            if (text == "No effect")
            {
                return 0;
            }
            else if (text == "From Top")
            {
                return 1;
            }
            else if (text == "From Bottom")
            {
                return 2;
            }
            else if (text == "From Left")
            {
                return 3;
            }
            else if (text == "From Right")
            {
                return 4;
            }
            else if (text == "Horizontal Split")
            {
                return 5;
            }
            else if (text == "Disolve")
            {
                return 6;
            }
            else if (text == "The Schwoop")
            {
                return 7;
            }
            else if (text == "Crooked From Top")
            {
                return 8;
            }
            else if (text == "Crooked From Bottom")
            {
                return 9;
            }
            else
            {
                return 0;
            }
        }

        //Stored here so when added new effects everything can be changed in the same place.
        private void setEntranceEffectText()
        {
            if (mySegmentArray[activeIndex].entranceEffect == 0)
            {
                entranceEffectComboBox.Text = "No effect";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 1)
            {
                entranceEffectComboBox.Text = "From Top";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 2)
            {
                entranceEffectComboBox.Text = "From Bottom";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 3)
            {
                entranceEffectComboBox.Text = "From Left";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 4)
            {
                entranceEffectComboBox.Text = "From Right";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 5)
            {
                entranceEffectComboBox.Text = "Horizontal Split";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 6)
            {
                entranceEffectComboBox.Text = "Disolve";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 7)
            {
                entranceEffectComboBox.Text = "The Schwoop";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 8)
            {
                entranceEffectComboBox.Text = "Crooked From Top";
            }
            else if (mySegmentArray[activeIndex].entranceEffect == 9)
            {
                entranceEffectComboBox.Text = "Crooked From Bottom";
            }
            else
            {
                entranceEffectComboBox.Text = "";
            }
        }

        private void staticEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].middleEffect = findMiddleEffect(middleEffectComboBox.Text);
            setMiddleEffectText();
        }

        private int findMiddleEffect(String text)
        {
            if (text == "No effect")
            {
                return 0;
            }
            else if (text == "Random Colored Dots")
            {
                return 1;
            }
            else if (text == "Flashing")
            {
                return 2;
            }
            else if (text == "The Wave")
            {
                return 3;
            }
            else if (text == "The Spotlight")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        //Stored here so when added new effects everything can be changed in the same place.
        private void setMiddleEffectText()
        {
            if (mySegmentArray[activeIndex].middleEffect == 0)
            {
                middleEffectComboBox.Text = "No effect";
            }
            else if (mySegmentArray[activeIndex].middleEffect == 1)
            {
                middleEffectComboBox.Text = "Random Colored Dots";
            }
            else if (mySegmentArray[activeIndex].middleEffect == 2)
            {
                middleEffectComboBox.Text = "Flashing";
            }
            else if (mySegmentArray[activeIndex].middleEffect == 3)
            {
                middleEffectComboBox.Text = "The Wave";
            }
            else if (mySegmentArray[activeIndex].middleEffect == 4)
            {
                middleEffectComboBox.Text = "The Spotlight";
            }
            else
            {
                middleEffectComboBox.Text = "";
            }
        }

        private void exitEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySegmentArray[activeIndex].exitEffect = findExitEffect(exitEffectComboBox.Text);
            setExitEffectText();
        }

        private int findExitEffect(String text)
        {
            if (text == "No effect")
            {
                return 0;
            }
            else if (text == "Exit Top")
            {
                return 1;
            }
            else if (text == "Exit Bottom")
            {
                return 2;
            }
            else if (text == "Exit Left")
            {
                return 3;
            }
            else if (text == "Exit Right")
            {
                return 4;
            }
            else if (text == "Horizontal Split")
            {
                return 5;
            }
            else if (text == "Disolve")
            {
                return 6;
            }
            else if (text == "Diagonal Exit Top")
            {
                return 7;
            }
            else if (text == "Diagonal Exit Bottom")
            {
                return 8;
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
                exitEffectComboBox.Text = "No effect";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 1)
            {
                exitEffectComboBox.Text = "Exit Top";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 2)
            {
                exitEffectComboBox.Text = "Exit Bottom";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 3)
            {
                exitEffectComboBox.Text = "Exit Left";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 4)
            {
                exitEffectComboBox.Text = "Exit Right";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 5)
            {
                exitEffectComboBox.Text = "Horizontal Split";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 6)
            {
                exitEffectComboBox.Text = "Disolve";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 7)
            {
                exitEffectComboBox.Text = "Diagonal Exit Top";
            }
            else if (mySegmentArray[activeIndex].exitEffect == 8)
            {
                exitEffectComboBox.Text = "Diagonal Exit Bottom";
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
            mySegmentArray[activeIndex].isImage = false;
            if (mySegmentArray[activeIndex].messageText.Length > 9)
            {
                string first9 = mySegmentArray[activeIndex].messageText.Substring(0, 9);
                segmentLabels[activeIndex].Text = first9 + "...";
            }
            else if (mySegmentArray[activeIndex].messageText == "")
            {
                segmentLabels[activeIndex].Text = "EMPTY";
            }
            else
            {
                segmentLabels[activeIndex].Text = mySegmentArray[activeIndex].messageText;
            }
            textTabLabel.BackColor = Color.White;
            textTabLabel.ForeColor = Color.Black;
            imageTabLabel.BackColor = darkerGray;
            imageTabLabel.ForeColor = Color.White;
            imagePanel.Visible = false;
            textPanel.Visible = true;
            textPanel.Controls.Add(ignoreCheckBox);
            displayDurationLabel.Location = new Point(14, 109);
            textPanel.Controls.Add(displayDurationLabel);
            createASegmentGroupBox.Controls.Add(displayDurationLabel);
            displayDurationControl.Location = new Point(104, 105);
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
                displayDurationControl.Visible = true;
                displayDurationLabel.Visible = true;
                entranceEffectLabel.Visible = true;
                entranceEffectComboBox.Visible = true;
                staticEffectLabel.Visible = true;
                middleEffectComboBox.Visible = true;
                exitEffectLabel.Visible = true;
                exitEffectComboBox.Visible = true;
                scrollSpeedControl.Visible = false;
                scrollSpeedLabel.Visible = false;
                secondsPerCharacterLabel.Visible = false;
                randomColorCheckBox.Visible = false;
            }
        }

        private void scrollingTextButton_CheckedChanged(object sender, EventArgs e)
        {
            if (scrollingTextButton.Checked == true)
            {
                mySegmentArray[activeIndex].isScrolling = true;
                //For some reason setting the default value in designer doesnt work. But this fixes it.
                scrollSpeedControl.Value = (decimal)((decimal)mySegmentArray[activeIndex].scrollSpeed / 100);
                displayDurationControl.Visible = false;
                displayDurationLabel.Visible = false;
                entranceEffectLabel.Visible = false;
                entranceEffectComboBox.Visible = false;
                staticEffectLabel.Visible = false;
                middleEffectComboBox.Visible = false;
                exitEffectLabel.Visible = false;
                exitEffectComboBox.Visible = false;
                scrollSpeedControl.Visible = true;
                scrollSpeedLabel.Visible = true;
                secondsPerCharacterLabel.Visible = true;
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
                if (mySegmentArray[activeIndex].isImage == false)
                {
                    string first9 = mySegmentArray[activeIndex].messageText.Substring(0, 9);
                    segmentLabels[activeIndex].Text = first9 + "...";
                }
            }
            else
            {
                longTextPopUp.Visible = false;
                specialEffectButton.Visible = true;
                if (mySegmentArray[activeIndex].isImage == false)
                {
                    segmentLabels[activeIndex].Text = mySegmentArray[activeIndex].messageText;
                }
            }
        }

        private void scrollSpeedControl_ValueChanged(object sender, EventArgs e)
        {
            int input = (int)Math.Floor(scrollSpeedControl.Value * 100);
            mySegmentArray[activeIndex].scrollSpeed = input;
        }

        private void randomColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomColorCheckBox.Checked == true)
            {
                mySegmentArray[activeIndex].isRandomColorScrolling = true;
            }
            else
            {
                mySegmentArray[activeIndex].isRandomColorScrolling = false;
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
            imageTabLabel.ForeColor = activeColor;
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
            mySegmentArray[activeIndex].isImage = true;
            segmentLabels[activeIndex].Text = "Image";
            imageTabLabel.BackColor = Color.White;
            imageTabLabel.ForeColor = Color.Black;
            textTabLabel.BackColor = darkerGray;
            textTabLabel.ForeColor = Color.White;
            textPanel.Visible = false;
            imagePanel.Visible = true;
            imagePanel.Controls.Add(ignoreCheckBox);
            imagePanel.Controls.Add(displayDurationLabel);
            displayDurationLabel.Location = new Point(12, 28);
            imagePanel.Controls.Add(displayDurationControl);
            displayDurationControl.Location = new Point(102, 26);
        }

        private void displayDurationControl_ValueChanged(object sender, EventArgs e)
        {
            int input = (int)Math.Floor(displayDurationControl.Value) * 1000;
            mySegmentArray[activeIndex].segmentSpeed = input;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            int size = -1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
            {

                int segmentSpeed = mySegmentArray[activeIndex].segmentSpeed;
                string filename = openFileDialog1.FileName;
                fileLocationTextBox.Text = filename;
                mySegmentArray[activeIndex].isImage = true;
                mySegmentArray[activeIndex].filename = filename;
                mySegmentArray[activeIndex].segmentSpeed = segmentSpeed;
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
            setBorderEffectText();
        }

        private int findBorderEffect(String text)
        {
            if (text == "No Border")
            {
                return 0;
            }
            else if (text == "Static Border")
            {
                return 1;
            }
            else if (text == "Rotating")
            {
                return 2;
            }
            else if (text == "Flashing Random Colors")
            {
                return 3;
            }
            else if (text == "Oscillating Random Colors")
            {
                return 4;
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
                borderEffectComboBox.Text = "No Border";
                borderColorButton.BackColor = mySegmentArray[activeIndex].borderColor;
            }
            else if (mySegmentArray[activeIndex].borderEffect == 1)
            {
                borderEffectComboBox.Text = "Static Border";
                borderColorButton.BackColor = mySegmentArray[activeIndex].borderColor;
            }
            else if (mySegmentArray[activeIndex].borderEffect == 2)
            {
                borderEffectComboBox.Text = "Rotating";
                borderColorButton.BackColor = mySegmentArray[activeIndex].borderColor;
            }
            else if (mySegmentArray[activeIndex].borderEffect == 3)
            {
                borderEffectComboBox.Text = "Flashing Random Colors";
            }
            else if (mySegmentArray[activeIndex].borderEffect == 4)
            {
                borderEffectComboBox.Text = "Oscillating Random Colors";
            }
            else
            {
                borderEffectComboBox.Text = "";
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
            abortDisplayThreads();
            marquee1.clearBorder(marqueeBackgroundColor);
            marquee1.clearMarquee(marqueeBackgroundColor);

            //show menu
            openMenu();
        }

        private void saveAndExitButton_Click(object sender, EventArgs e)
        {
            //Closes the form
            Application.Exit();
            abortDisplayThreads();
        }
        //Edited 11-26 Heather
        private void saveAndRunButton_Click(object sender, EventArgs e)
        {
            pauseButton.Visible = true;
            goToFullScreenButton.Visible = true;
            abortDisplayThreads();
            clearForMarquee();
            backToMenuButton.Visible = true;
            goToFullScreenButton.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            marquee1.Visible = true;
            Message myMessage = new Vision.Message(mySegmentArray, marqueeBackgroundColor);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
            myDisplayThread.Start();
        }
        #endregion

        /*
         * 
         *   XML Methods
         * 
         */
        #region XML Methods

        //Edited 11-26 Heather
        //Edited 11-28 Logan
        //Save all fields but "filename" and the "messageMatrix" in every segment object in array
        //Also save the marqueeBackgroundColor from this class
        class XmlSave
        {
            public static void SaveData(object IClass, string fileName)
            {
                StreamWriter writer = null;
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer((IClass.GetType()));
                    writer = new StreamWriter(fileName);
                    xmlSerializer.Serialize(writer, IClass);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                    writer = null;
                }
            }

        }

        class XmlLoad<T>
        {
            public static Type type;

            public XmlLoad()
            {
                type = typeof(T);
            }

            public T LoadData(string fileName)
            {
                T result;
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                result = (T)xmlSerializer.Deserialize(fs);
                fs.Close();
                return result;
            }
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
            if (myPauseInvalidationThread != null)
            {
                if (myPauseInvalidationThread.IsAlive)
                {
                    myPauseInvalidationThread.Abort();
                }
            }
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    if (myDisplayThread.ThreadState != ThreadState.Running && myDisplayThread.ThreadState != ThreadState.Suspended)
                    {
                        Thread restartThread = new Thread(delegate () 
                        {
                            while (myDisplayThread.ThreadState != ThreadState.Running && myDisplayThread.ThreadState != ThreadState.Suspended)
                            {
                                Thread.Sleep(25);
                            }
                            if (myDisplayThread.ThreadState == ThreadState.Suspended)
                            {
                                myDisplayThread.Resume();
                            }
                        });
                        restartThread.Start();
                    }
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
            myPauseInvalidationThread = new Thread(delegate ()
            {
                while(true)
                {
                    Thread.Sleep(25);
                    marquee1.Invalidate();
                }
            });
            myPauseInvalidationThread.Start();
        }
        #endregion

        private void logoLabel_Click(object sender, EventArgs e)
        {

        }

        private void abortDisplayThreads()
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
            if (myPauseInvalidationThread != null)
            {
                if (myPauseInvalidationThread.IsAlive)
                {
                    myPauseInvalidationThread.Abort();
                }
            }
            marquee1.borderThreadAbort();
            marquee1.clearMarquee(marquee1.BackColor);
            marquee1.clearBorder(marquee1.BackColor);
        }

        private void startNewMessageButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            originalPictureBox.Image = (Image)mySegmentArray[activeIndex].originalBitmap;
            originalPictureBox.BackColor = marqueeBackgroundColor;
            scaledPictureBox.Image = (Image)mySegmentArray[activeIndex].scaledBitmap;
            scaledPictureBox.BackColor = marqueeBackgroundColor;
            originalPictureBox.Invalidate();
        }

        /* Removed for Beta Build
        private void saveButton_Click(object sender, EventArgs e)
        {
            //create XML file
             saveFileDialog1.Filter = "Xml Files (*.xml) | *.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Message copyMyMessage = new Vision.Message(mySegmentArray, marqueeBackgroundColor);
                Segment[] copSegs = copyMyMessage.getSegmentArray();
                copyMyMessage.backgroundColor = marqueeBackgroundColor;

                for (int i = 0; i < copSegs.Length; i++)
                {
                    Segment seg = new Segment();
                    seg.ignore = copSegs[i].ignore;
                    seg.messageText = copSegs[i].messageText;
                    seg.onColor = copSegs[i].onColor;
                    seg.segmentSpeed = copSegs[i].segmentSpeed;
                    seg.isScrolling = copSegs[i].isScrolling;
                    seg.isRandomColorScrolling = copSegs[i].isRandomColorScrolling;
                    seg.scrollSpeed = copSegs[i].scrollSpeed;
                    seg.isImage = copSegs[i].isImage;
                    seg.originalBitmap = copSegs[i].originalBitmap;
                    seg.scaledBitmap = copSegs[i].scaledBitmap;
                    seg.imageAspect = copSegs[i].imageAspect;
                    seg.entranceEffect = copSegs[i].entranceEffect;
                    seg.middleEffect = copSegs[i].middleEffect;
                    seg.exitEffect = copSegs[i].exitEffect;
                    seg.borderColor = copSegs[i].borderColor;
                    seg.borderEffect = copSegs[i].borderEffect;
                }
                XmlSave.SaveData(copyMyMessage, saveFileDialog1.FileName);
            }
            myDisplayThread.Start();            
        }
        */

        private void UIForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            abortDisplayThreads();
            Application.Exit();
        }

        /*
         * 
         *   FullScreen methods
         * 
         */
        #region FullScreen methods

        //Work in progress
        private void EnterFullScreenMode()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            exitFullScreen.BackColor = marqueeBackgroundColor;
            exitFullScreen.Visible = true;
            backToMenuButton.Visible = false;
            exitButton.Visible = false;
            goToFullScreenButton.Visible = false;
            fullScreen = true;
        }

        //Work in progress
        private void LeaveFullScreenMode()
        {
            exitFullScreen.Visible = false;
            backToMenuButton.Visible = true;
            exitButton.Visible = true;
            goToFullScreenButton.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            fullScreen = false;
        }

        private void exitFullScreen_MouseClick(object sender, MouseEventArgs e)
        {
            if (fullScreen)
            {
                LeaveFullScreenMode();
            }
        }

        private void goToFullScreenButton_Click(object sender, EventArgs e)
        {
            EnterFullScreenMode();
        }
        #endregion

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void fileLocationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (mySegmentArray[activeIndex].isImage == true)
            {
                segmentLabels[activeIndex].Text = "Image";
            }
        }
    }
}
