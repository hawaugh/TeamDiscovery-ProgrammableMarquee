/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Marquee.cs
// Description: 
//
// Name: Logan
// Last Edit: 11/6
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
using System.Collections.Generic;

namespace Vision
{
    class Marquee : Control
    {
        private Dot[,] matrix = new Dot[16, 96];
        private Dot[] border = new Dot[220];
        private Thread myBorderThread = null;
        private Color borderColor;
        private int borderEffect;

        public Marquee()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.BackColor = Color.Black;
            this.borderColor = Color.Black;
            this.borderEffect = 0;

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

        public void setDot(int row, int col, Color fore)
        {
            matrix[row, col].ForeColor = fore;
        }

        public Color getDotFore(int row, int col)
        {
            return matrix[row, col].ForeColor;
        }
        
        public void clearMarquee(Color backgroundColor)
        {
            for (int r = 1; r < 15; r++)
            {
                for (int c = 1; c < 95; c++)
                {
                    setDot(r, c, backgroundColor);
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
            this.borderColor = message.borderColor;
            this.borderEffect = message.borderEffect;

            //Start Border Effect
            myBorderThread = new Thread(delegate () { displayBorder(); });
            myBorderThread.Start();

            //Display Segments
            for (int i = 0; i < message.getSegmentArray().Length; i++)
            {
                displaySegment(message.getSegmentArray()[i], message.backgroundColor, message.scrollSpeed, message.segmentSpeed);
            }
        }

        //Selects the correct effects to use to display the segment
        public void displaySegment(Segment segment, Color backgroundColor, int scrollSpeed, int segmentSpeed)
        {
            //If segment is image then display image and return
            if (segment is Image)
            {
                displayImage((Image) segment, segmentSpeed);
                return;
            }
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
            else if (segment.entranceEffect == 4)
            {
                displayRandomEntrance(segment, backgroundColor);
                Thread.Sleep(segmentSpeed);
            }

            //Display Middle
            if (segment.middleEffect == -1)
            {
                displayScrollingSegment(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(500);
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
                displaySplitExit(segment, backgroundColor, scrollSpeed);
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
            else if (segment.exitEffect == 4)
            {
                displayRandomExit(segment, backgroundColor);
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
                        setDot(r, ((96 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currString[c].Equals('0'))
                    {
                        setDot(r, ((96 - segmentLength) / 2) + c, backgroundColor);
                    }
                }
            }
            Invalidate();
        }

        //Heather - edited on 11/05/17
        public void displaySplitEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int topColumnStop = (96 - segmentLength) / 2 + segmentLength + 4; //gives stop column for top half scrolling in from right
            int bottomColumnStop = (96 - segmentLength) / 2;   //gives stop column for bottom half in from left.           

            //scroll top half from left-side of screen, and bottom half from right-side of screen. 
            //Stop scrolling when they line up.
            for (int s = segmentLength - 1; s > -1; s--)
            {
                //Move top half of dots to the right, starting at the topColumnStop column
                for (int c = topColumnStop; c > 1; c--)
                {
                    //Only want to use the upper half of rows on the display (2-7)
                    for (int r = 2; r < 8; r++)
                    {
                        setDot(r, c, getDotFore(r, c - 1));
                    }
                }

                //Set last column to next column in segment
                for (int r = 2; r < 8; r++)
                {
                    if (currSegment[r - 2][s].Equals('1'))
                    {
                        setDot(r, 2, segment.onColor);
                    }
                    else if (currSegment[r - 2][s].Equals('0'))
                    {
                        setDot(r, 93, backgroundColor);
                    }
                }
                Invalidate();
                Thread.Sleep(scrollSpeed);
            }
            ////////center upper half of message
            for (int i = 96; i > topColumnStop; i--)
            {
                //Move all dots 1 column right
                for (int c = 93; c > 0; c--)
                {
                    for (int r = 2; r < 8; r++)
                    {
                        setDot(r, c, getDotFore(r, c - 1));
                    }
                }

                //Set last column to blank
                for (int r = 2; r < 8; r++)
                {
                    setDot(r, 1, backgroundColor);
                }
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
            //scroll bottom half from left

            for (int q = 0; q < segmentLength; q++)
                {
                    //Move all dots 1 column left
                    for (int c = 2; c < 93; c++)
                    {
                        for (int row = 8; row < 14; row++)
                        {
                            setDot(row, c, getDotFore(row, c + 1));
                        }
                    }

                    //Set last column to next column in segment
                    for (int r = 8; r < 14; r++)
                    {
                        if (currSegment[r - 2][q].Equals('1'))
                        {
                            setDot(r, 93, segment.onColor);
                        }
                        else if (currSegment[r - 2][q].Equals('0'))
                        {
                            setDot(r, 93, backgroundColor);
                        }
                    }
                    Invalidate();
                    Thread.Sleep(scrollSpeed);
                }
            //////center lower half of message
            for (int i = 0; i < bottomColumnStop; i++)
            {
                //Move all dots 1 column left
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 8; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r, c + 1));
                    }
                }

                //Set last column to blank
                for (int r = 8; r < 14; r++)
                {
                    setDot(r, 93, backgroundColor);
                }
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }
        

        //Ahmad
        public void displayUpEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {
             displayBorder(message.borderColor, message.backgroundColor, message.offColor);
            String[] currSegment = message.getSegmentArray()[0].getMessageMatrix();
            int segmentLength = currSegment.Length;
            for (int s = 0; s < segmentLength; s++)
            {
                //Move all dots 1 row down
                for (int c = 93; c > 0; c--)
                {
                    for (int r  = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c), message.backgroundColor);
                    }
                }


                //Set last column to next column in segment
                for (int c = 2; c < segmentLength; c++)
                {
                    if (currSegment[0][c - 2].Equals('1'))
                    {
                        //setDot(14, c, message.onColor, message.backgroundColor);
                        setDot(93, ((96 - segmentLength) / 2) + c, message.onColor, message.backgroundColor);
                    }
                    else if (currSegment[0][c - 2].Equals('0'))
                    {
                        //setDot(14, c, message.offColor, message.backgroundColor);
                        setDot(93, ((96 - segmentLength) / 2) + c, message.onColor, message.backgroundColor);
                    }
                }
                Thread.Sleep(75);
            }

            //Exit rest of segment to the down
            for (int i = 14; i > 0; i--)
            {
                //Move all dots 1 column down
                for (int c = 93; c > 0; c--)
                {
                    for (int r = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c), message.backgroundColor);
                    }
                }

                //Set last column to blank
                for (int c = 93; c > 2; c--)
                {
                    setDot(14, c, message.offColor, message.backgroundColor);
                }
                Thread.Sleep(75);
            }

        }

        //Ahmad
        public void displayDownEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {
             displayBorder(message.borderColor, message.backgroundColor, message.offColor);
            String[] currSegment = message.getSegmentArray()[0].getMessageMatrix();
            int segmentLength = currSegment.Length;
            for (int s = 0; s < segmentLength; s++)
            {
                //Move all dots 1 row up
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r+1,c), message.backgroundColor);
                    }
                }


                //Set last column to next column in segment
                for (int c = 2; c < segmentLength; c++)
                {
                    if (currSegment[0][c-2].Equals('1'))
                    {
                        //setDot(14, c, message.onColor, message.backgroundColor);
                        setDot(14, ((96 - segmentLength) / 2) + c, message.onColor, message.backgroundColor);
                    }
                    else if (currSegment[0][c-2].Equals('0'))
                    {
                        //setDot(14, c, message.offColor, message.backgroundColor);
                        setDot(14, ((96 - segmentLength) / 2) + c, message.onColor, message.backgroundColor);
                    }
                }
                Thread.Sleep(75);
            }

            //Exit rest of segment to the up
            for (int i = 0; i < 14; i++)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r+1, c), message.backgroundColor);
                    }
                }

                //Set last column to blank
                for (int c = 2; c < 93; c++)
                {
                    setDot(14, c, message.offColor, message.backgroundColor);
                }
                Thread.Sleep(75);
            }
        }

        public void displayRandomEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            String currString;
            List<Dot> activeDotList = new List<Dot>();
            for (int r = 2; r < 14; r++)
            {
                currString = currSegment[r - 2];
                for (int c = 0; c < segmentLength; c++)
                {
                    if (currString[c].Equals('1'))
                    {
                        activeDotList.Add(matrix[r, ((96 - segmentLength) / 2) + c]);                        
                    }                    
                }
            }
            Random rnd = new Random();
            while (activeDotList.Count > 0)
            {
                int randomNumber = rnd.Next(0, activeDotList.Count);
                activeDotList[randomNumber].ForeColor = segment.onColor;
                activeDotList.RemoveAt(randomNumber);
                Invalidate();
                Thread.Sleep(10);
            }
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
                        setDot(r, c, getDotFore(r, c + 1));                        
                    }
                }

                //Set last column to next column in segment
                for (int r = 2; r < 14; r++)
                {
                    if (currSegment[r - 2][s].Equals('1'))
                    {
                        setDot(r, 93, segment.onColor);
                    }
                    else if (currSegment[r - 2][s].Equals('0'))
                    {                        
                        setDot(r, 93, backgroundColor);                        
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
                        setDot(r, c, getDotFore(r, c + 1));
                    }
                }

                //Set last column to blank
                for (int r = 2; r < 14; r++)
                {
                    setDot(r, 93, backgroundColor);
                }
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }

        //Nick
        //The marquee will already have the message displayed and the dots are set for you to edit them in this method
        public void displayRandomColors(Segment segment, Color backgroundColor)
        {
            List<Dot> activeDotList = new List<Dot>();
            for (int r = 2; r < 14; r++)
            {
                for (int c = 2; c < 94; c++)
                {
                    if (getDotFore(r, c) != backgroundColor)
                    {
                        //add to storage for next loop
                        activeDotList.Add(matrix[r, c]);
                    }
                }
            }
            Random rnd = new Random();
            while (activeDotList.Count > 0)
            {
                int randomNumber = rnd.Next(0, activeDotList.Count);
                activeDotList[randomNumber].randColor();
                activeDotList.RemoveAt(randomNumber);                
                Invalidate();
                Thread.Sleep(10);
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
        //Heather edited on 11/05/17
        public void displaySplitExit(Segment segment, Color backgroundColor, int scrollSpeed)
        {

            //Exit top half to right
            for (int i = 0; i < 94; i++)
            {
                for (int c = 93; c > 0; c--)
                {
                    for (int r = 2; r < 8; r++)
                    {
                        setDot(r, c, getDotFore(r, c - 1));
                    }
                }

                //Set last column to blank
                for (int r = 2; r < 8; r++)
                {
                    setDot(r, 1, backgroundColor);
                }
                Thread.Sleep(scrollSpeed);
                Invalidate();              
            }
            //Exit rest of segment to the left
            for (int i = 0; i < 94; i++)
            {
                //Move all dots 1 column left
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 8; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r, c + 1));
                    }
                }

                //Set last column to blank
                for (int r = 2; r < 14; r++)
                {
                    setDot(r, 93, backgroundColor);
                }
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }

        //Ahmad
        public void displayUpExit()
        {

        }

        //Ahmad
        public void displayDownExit()
        {

        }

        public void displayRandomExit(Segment segment, Color backgroundColor)
        {
            List<Dot> activeDotList = new List<Dot>();
            for (int r = 2; r < 14; r++)
            {
                for (int c = 2; c < 94; c++)
                {
                    if (getDotFore(r, c) != backgroundColor)
                    {
                        //add to storage for next loop
                        activeDotList.Add(matrix[r, c]);
                    }
                }
            }
            Random rnd = new Random();
            while (activeDotList.Count > 0)
            {
                int randomNumber = rnd.Next(0, activeDotList.Count);
                activeDotList[randomNumber].ForeColor = backgroundColor;
                activeDotList.RemoveAt(randomNumber);
                Invalidate();
                Thread.Sleep(10);
            }
        }
        #endregion


        /*
         * 
         *   Border Effects
         * 
         */
        #region Border Effects
        public void clearBorder(Color backgroundColor)
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = backgroundColor;
            }
        }

        public void displayBorder()
        {
            if (borderEffect == 1)
            {
                displayBorderHighlight();
            }
            else
            {
                staticBorder();
            }
        }

        public void staticBorder()
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = borderColor;
            }
        }

        //Brooks
        public void displayBorderHighlight()
        {

        }
        #endregion


        /*
         * 
         *   Image Effects
         * 
         */
        #region Image Effects
        public void displayImage(Image image, int segmentSpeed)
        {
            //Stop Border Effect
            if (myBorderThread != null)
            {
                if (myBorderThread.IsAlive)
                {
                    myBorderThread.Abort();
                }
            }

            //Clear Border
            clearBorder(BackColor);
            Invalidate();

            for (int c = 0; c < image.getWidth(); c++)
            {
                for (int r = 0; r < image.getHeight(); r++)
                {
                    setDot(r + ((16 - image.getHeight()) / 2), c + ((96 - image.getWidth()) / 2), image.getPixel(c, r)); 
                }
            }

            Invalidate();

            //Hold Image on marquee for set time
            Thread.Sleep(10000);

            //Clear Whole Marquee
            clearMarquee(BackColor);
            clearBorder(BackColor);
            Invalidate();
            Thread.Sleep(500);

            //Resume Border effect
            myBorderThread = new Thread(delegate () { displayBorder(); });
            myBorderThread.Start();
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
