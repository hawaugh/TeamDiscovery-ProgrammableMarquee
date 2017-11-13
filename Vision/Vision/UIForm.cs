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
        private Segment[] mySegmentArray = new Segment[14];
        private Color darkerGray = new Color();
        private Color lightGray = new Color();

        public OpenFileDialog openFileDialog { get; private set; }

        public UIForm()
        {
            darkerGray = Color.FromArgb(0, 64, 64, 64);
            lightGray = Color.FromArgb(0, 224, 224, 224);
            for (int i = 0; i < 14; i++)
            {
                mySegmentArray[i] = new Segment();
            }
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
            clearForMarquee();
            marquee1.Visible = true;
            Segment mySegment = new Segment("TEAM", Color.Red, 1, 1, 1);
            Segment mySecondSegment = new Segment("Discovery", Color.Aqua, -1, -1, -1);
            Image myImageSegment = new Image("..\\..\\panthers.jpg");
            Segment myThirdSegment = new Segment("BEST TEAM", Color.Yellow, 4, 0, 4);
            mySegmentArray = new Segment[] { mySegment, mySecondSegment, myImageSegment, myThirdSegment };
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black, Color.Red, 0, 25, 2000);
            myDisplayThread = new Thread(delegate () { marquee1.displayMessage(myMessage); });
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
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel3_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel4_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel5_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel6_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel7_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel8_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel9_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel10_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel11_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel12_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel13_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentPanel14_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
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
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel3_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel3.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel4_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel4.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel5_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel5.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel6_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel6.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel7_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel7.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel8_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel8.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel9_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel9.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel10_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel10.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel11_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel11.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel12_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel12.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel13_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel13.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
        }

        private void segmentLabel14_Click(object sender, EventArgs e)
        {
            resetSegments();
            segmentPanel14.BackColor = Color.DeepSkyBlue;
            //Clears the text in TextBox
            textTextBox.Text = "";
            //Adds the Text thats saved the the segment into the TextBox
            textTextBox.Text = mySegmentArray[0].messageText;
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
            if (segmentPanel14.Visible == true)
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

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            noTextPopUp.Visible = false;
            //Test which segment button is active
            if (segmentPanel14.BackColor == Color.DeepSkyBlue)
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

        private void clearForMarquee()
        {
            fileLocationTextBox.Visible = false;
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
            flowLayoutPanel1.Visible = false;
            logoLabel.Visible = false;
            textTabLabel.Visible = false;
            imageTabLabel.Visible = false;
            textPanel.Visible = false;
            imagePanel.Visible = false;
        }
    }
}
