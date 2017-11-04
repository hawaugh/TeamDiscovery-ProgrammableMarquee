/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Marquee.cs
// Description: 
//
// Name: Logan
// Last Edit: 11/2
/////////////////////////////////////////////////////﻿

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Vision
{
    class Marquee : Control
    {
        private Dot[,] matrix = new Dot[16, 96];
        private Dot[] border = new Dot[220];

        public Marquee()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.BackColor = Color.Black;

            //Populate matrix array of Dots
            for (int r = 0; r < 16; r++)
            {
                for (int c = 0; c < 96; c++)
                {
                    matrix[r, c] = new Dot();
                }
            }

            //Reference border array
            //Set Top border
            for (int b = 0; b < 96; b++)
            {
                border[b] = matrix[0, b];
            }
            //Set Right border
            for (int b = 96; b < 111; b++)
            {
                border[b] = matrix[b - 95, 95];
            }
            //Set Bottom border
            for (int b = 111; b < 206; b++)
            {
                border[b] = matrix[15, 205 - b];
            }
            //Set Left border
            for (int b = 206; b < 220; b++)
            {
                border[b] = matrix[220 - b, 0];
            }
        }

        public void setDot(int row, int col, Color fore, Color back)
        {
            matrix[row, col].ForeColor = fore;
            matrix[row, col].BackColor = back;
        }

        public Color getDotFore(int row, int col)
        {
            return matrix[row, col].ForeColor;
        }

        public Color getDotBack(int row, int col)
        {
            return matrix[row, col].BackColor;
        } 
        
        public void clearMarquee(Color backgroundColor)
        {
            for (int r = 2; r < 14; r++)
            {
                for (int c = 2; c < 94; c++)
                {
                    setDot(r, c, backgroundColor, backgroundColor);
                }
            }
            Invalidate();
        }

        /*
         * 
         *   Message Control
         * 
         */
        #region Message Control

        //Cycles through segments and displays them
        public void displayMessage(Message message)
        {
            this.BackColor = message.backgroundColor;
            for (int i = 0; i < message.getSegmentArray().Length; i++)
            {
                displaySegment(message.getSegmentArray()[i], message.backgroundColor, message.scrollSpeed, message.segmentSpeed);
            }
        }

        //Selects the correct effects to use to display the segment
        public void displaySegment(Segment segment, Color backgroundColor, int scrollSpeed, int segmentSpeed)
        {
            //Display Entrance
            if (segment.entranceEffect == 0)
            {
                displayStaticEntrance(segment, backgroundColor);
                Thread.Sleep(segmentSpeed);
            }
            else if (segment.entranceEffect == 1)
            {
                displaySplitEntrance(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(segmentSpeed);
            }
            else if (segment.entranceEffect == 2)
            {
                displayUpEntrance(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(segmentSpeed);
            }
            else if (segment.entranceEffect == 3)
            {
                displayDownEntrance(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(segmentSpeed);
            }

            //Display Middle
            if (segment.middleEffect == -1)
            {
                displayScrollingSegment(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(segmentSpeed);
            }
            else if (segment.middleEffect == 1)
            {
                displayRandomColors(segment, backgroundColor);
                Thread.Sleep(segmentSpeed);
            }
            else if (segment.middleEffect == 2)
            {
                displayFadeEffect(segment, backgroundColor);
                Thread.Sleep(segmentSpeed);
            }

            //Display Exit
            if (segment.exitEffect == 0)
            {
                clearMarquee(backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 1)
            {
                displaySplitExit();
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 2)
            {
                displayUpExit();
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 3)
            {
                displayDownExit();
                Thread.Sleep(500);
            }
        }
        #endregion


        /*
         * 
         *   Entrance Effects
         * 
         */
        #region Entrance Effects
        public void displayStaticEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            String currString;
            for (int r = 2; r < 14; r++)
            {
                currString = currSegment[r - 2];
                for (int c = 0; c < segmentLength; c++)
                {

                    if (currString[c].Equals('1'))
                    {
                        setDot(r, ((96 - segmentLength) / 2) + c, segment.onColor, backgroundColor);
                    }
                    else if (currString[c].Equals('0'))
                    {
                        setDot(r, ((96 - segmentLength) / 2) + c, backgroundColor, backgroundColor);
                    }
                }
            }
            Invalidate();
        }

        //Heather - edited on 10/29/17
        public void displaySplitEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            String currString;
            String[] topHalfSegment = new String[6];
            String[] bottomHalfSegment = new String[6];
            //loop through each index of currSegment
            //make currString = value at index of currSegment
            //loop through index 0-5 and add the values to topHalfSegment
            //loop through index 6-11 and add the values to bottomHalfSegment.
            //scroll top half from left-side of screen, and bottom half from right-side of screen. 
            //Stop scrolling when they line up.
        }

        //Ahmad
        public void displayUpEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {

        }

        //Ahmad
        public void displayDownEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {

        }
        #endregion


        /*
         * 
         *   Middle Effects
         * 
         */
        #region Middle Effects
        //Logan
        public void displayScrollingSegment(Segment segment, Color backgroundColor, int scrollSpeed)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            for (int s = 0; s < segmentLength; s++)
            {                
                //Move all dots 1 column left
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {                        
                        setDot(r, c, getDotFore(r, c + 1), backgroundColor);                        
                    }
                }

                //Set last column to next column in segment
                for (int r = 2; r < 14; r++)
                {
                    if (currSegment[r - 2][s].Equals('1'))
                    {
                        setDot(r, 93, segment.onColor, backgroundColor);
                    }
                    else if (currSegment[r - 2][s].Equals('0'))
                    {                        
                        setDot(r, 93, backgroundColor, backgroundColor);                        
                    }
                }
                Invalidate();
                Thread.Sleep(scrollSpeed);
            }

            //Exit rest of segment to the left
            for (int i = 0; i < 94; i++)
            {
                //Move all dots 1 column left
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r, c + 1), backgroundColor);
                    }
                }

                //Set last column to blank
                for (int r = 2; r < 14; r++)
                {
                    setDot(r, 93, backgroundColor, backgroundColor);
                }
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }

        //Nick
        //The marquee will already have the message displayed and the dots are set for you to edit them in this method
        public void displayRandomColors(Segment segment, Color backgroundColor)
        {
            ArrayList activeDotArray = new ArrayList();
            for (int r = 2; r < 14; r++)
            {
                for (int c = 3; c < 94; c++)
                {
                    if (getDotFore(r, c) == segment.onColor)
                    {
                        //add to storage for next loop
                        //Count will always return a odd number
                        activeDotArray.Add(r);
                        activeDotArray.Add(c);
                    }
                }
            }
            while (activeDotArray.Count > 0)
            {
                Random rnd = new Random();
                //Convert to int32
                int randomNumber = rnd.Next(0, activeDotArray.Count);
                //test whether randomNumber is odd
                if (randomNumber % 2 == 0)
                {
                    setDot(randomNumber, randomNumber + 1, segment.randColor, backgroundColor);
                    activeDotArray.RemoveAt(randomNumber);
                    activeDotArray.RemoveAt(randomNumber + 1);
                }
                else
                {
                    setDot(randomNumber - 1, randomNumber, segment.randColor, backgroundColor);
                    activeDotArray.RemoveAt(randomNumber);
                    activeDotArray.RemoveAt(randomNumber - 1);
                }
                Thread.Sleep(50);
            }
        }

        //Jeremy
        public void displayFadeEffect(Segment segment, Color backgroundColor)
        {

        }
        #endregion


        /*
         * 
         *   Exit Effects
         * 
         */
        #region Exit Effects
        //Heather
        public void displaySplitExit()
        {

        }

        //Ahmad
        public void displayUpExit()
        {

        }

        //Ahmad
        public void displayDownExit()
        {

        }
        #endregion


        /*
         * 
         *   Border Effects
         * 
         */
        #region Border Effects
        public void displayBorder(Color borderColor, Color backgroundColor)
        {
            for (int r = 0; r < 16; r++)
            {
                for (int c = 0; c < 96; c++)
                {
                    setDot(r, c, backgroundColor, backgroundColor);
                }
            }
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = borderColor;
                border[b].BackColor = backgroundColor;
            }
        }

        //Brooks
        public void displayBorderHighlightMessage(Message message)
        {

        }
        #endregion


        /*
         * 
         *   Image Effects
         * 
         */
        #region Image Effects
        public void displayImage(Image image)
        {

        }
        #endregion


        /*
         * 
         *   Events
         * 
         */
        #region Events
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;

            // Calling the base class OnPaint
            base.OnPaint(e);

            // Antialiasing
            gfx.SmoothingMode = SmoothingMode.AntiAlias;

            int dotWidth = this.Width / 96;         
            int xLoc = (this.Width - (dotWidth * 96)) / 2;
            int yLoc = (this.Height - (dotWidth * 16)) / 2;
            this.SuspendLayout();         
            for (int r = 0; r < 16; r++)
            {
                for (int c = 0; c < 96; c++)
                {
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(getDotFore(r, c));
                    e.Graphics.FillPie(myBrush, xLoc, yLoc, dotWidth - 1, dotWidth - 1, 0, 360);                              
                    xLoc += dotWidth;
                }
                xLoc = (this.Width - (dotWidth * 96)) / 2;
                yLoc += dotWidth;
            }
            this.ResumeLayout();
        }



        #endregion

    }
}
