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
            bool currentIsImage = false;
            Color currentBorderColor = Color.Black;
            int currentBorderEffect = 0;

            //Display Segments
            for (int i = 0; i < message.getSegmentArray().Length; i++)
            {
                //Skip current index if ignore is true
                if (!message.getSegmentArray()[i].ignore)
                {
                    //Check if its not an image
                    if (!message.getSegmentArray()[i].isImage)
                    {
                        currentIsImage = false;
                        //Check if its the first segment
                        if (i == 0)
                        {
                            currentBorderColor = message.getSegmentArray()[i].borderColor;
                            currentBorderEffect = message.getSegmentArray()[i].borderEffect;
                            //Start Border Effect
                            myBorderThread = new Thread(delegate () { displayBorder(currentBorderColor, currentBorderEffect); });
                            myBorderThread.Start();
                        }
                        //Check if the segment before was an image
                        else if (currentIsImage)
                        {
                            currentBorderColor = message.getSegmentArray()[i].borderColor;
                            currentBorderEffect = message.getSegmentArray()[i].borderEffect;
                            //Start Border Effect
                            myBorderThread = new Thread(delegate () { displayBorder(currentBorderColor, currentBorderEffect); });
                            myBorderThread.Start();
                        }
                        //Check if border effect changed from the last one
                        else if (message.getSegmentArray()[i].borderColor != currentBorderColor || message.getSegmentArray()[i].borderEffect != currentBorderEffect)
                        {
                            if (myBorderThread != null)
                            {
                                if (myBorderThread.IsAlive)
                                {
                                    myBorderThread.Abort();
                                }
                            }

                            currentBorderColor = message.getSegmentArray()[i].borderColor;
                            currentBorderEffect = message.getSegmentArray()[i].borderEffect;
                            //Start Border Effect
                            myBorderThread = new Thread(delegate () { displayBorder(currentBorderColor, currentBorderEffect); });
                            myBorderThread.Start();
                        }
                    }
                    //Set current variables if it is an image
                    else if (message.getSegmentArray()[i].isImage)
                    {
                        currentIsImage = true;
                        currentBorderColor = Color.Black;
                        currentBorderEffect = 0;
                    }

                    //Display Current Segment
                    displaySegment(message.getSegmentArray()[i], message.backgroundColor);
                }
            }

            //Stop Border Thread if running
            if (myBorderThread != null)
            {
                if (myBorderThread.IsAlive)
                {
                    myBorderThread.Abort();
                }
            }
            //Clear Marquee
            clearBorder(BackColor);
            clearMarquee(BackColor);
        }

        //Selects the correct effects to use to display the segment
        public void displaySegment(Segment segment, Color backgroundColor)
        {
            //If segment is image then display image and return
            if (segment.isImage)
            {
                displayImage(segment);
                return;
            }

            //If segment is Scrolling then display scrolling message
            if (segment.isScrolling)
            {
                displayScrollingSegment(segment, backgroundColor);
                Thread.Sleep(500);
                return;
            }

            //Display Entrance
            if (segment.entranceEffect == 0)
            {
                displayStaticEntrance(segment, backgroundColor);
            }
            else if (segment.entranceEffect == 1)
            {
                displaySplitEntrance(segment, backgroundColor);
            }
            else if (segment.entranceEffect == 2)
            {
                displayUpEntrance(segment, backgroundColor);
            }
            else if (segment.entranceEffect == 3)
            {
                displayDownEntrance(segment, backgroundColor);
            }
            else if (segment.entranceEffect == 4)
            {
                displayRandomEntrance(segment, backgroundColor);
            }
                  else if (segment.entranceEffect == 5)
            {
                displayUpsideDownEntrance(segment, backgroundColor);
            }
                  else if (segment.entranceEffect == 6)
            {
                displaySidewayEntrance(segment, backgroundColor);
            }

            //Display Middle   
            if (segment.middleEffect == 0)
            {
                Thread.Sleep(segment.segmentSpeed);
            }
            else if (segment.middleEffect == 1)
            {
                displayRandomColors(segment, backgroundColor);
                Thread.Sleep(segment.segmentSpeed);
            }
            else if (segment.middleEffect == 2)
            {
                displayFadeEffect(segment, backgroundColor);
            }

            //Display Exit
            if (segment.exitEffect == 0)
            {
                clearMarquee(backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 1)
            {
                displaySplitExit(segment, backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 2)
            {
                displayUpExit(segment, backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 3)
            {
                displayDownExit(segment, backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 4)
            {
                displayRandomExit(segment, backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 5)
            {
                displayUpsideDownExit(segment, backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 6)
            {
                 displaySidewayExit(segment, backgroundColor);
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

        //Heather - edited on 11/10/17
        //Displays segment by scrolling top half in from left and bottom half in from left.
        public void displaySplitEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            Segment seg = segment;
            Color col = backgroundColor;            

            //causes both methods to run concurrently.
            Parallel.Invoke(() =>
            {
                displayUpperSplitEntrance(seg, col);
            },

            () =>
            {
                displayLowerSplitEntrance(seg, col);
            }
            );          
        }
        //Heather - Created on 11/10/17
        //private method that will display upper half of segment.  
        //To be used in displaySplitEntrance that will run concurrently with lower half
        private void displayUpperSplitEntrance(Segment segment, Color backgroundColor)
        {
           
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int topColumnStop = (96 - segmentLength) / 2 + segmentLength + 1; //gives stop column for top half scrolling in from right                     

            //scroll top half from left-side of screen 
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
                Thread.Sleep(25);
            }
            ////////center upper half of message
            for (int i = 96; i > topColumnStop; i--)
            {
                //Move all dots 1 column right
                for (int c = 94; c > 0; c--)
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
                Thread.Sleep(25);
                Invalidate();
            }
        }
        //Heather - Created on 11/10/17
        //private method that will display lower half of message scrolling in.
        //Will be called in displaySplitEntrance and used to run concurrently with upper half method
        private void displayLowerSplitEntrance(Segment segment, Color backgroundColor)
        {   
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;           
            int bottomColumnStop = (96 - segmentLength) / 2 - 2 ;   //gives stop column for bottom half in from left. 

            //scroll bottom half from left
            for (int q = 0; q < segmentLength; q++)
            {
                //Move all dots 1 column left
                for (int c = 2; c < 94; c++)
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
                        setDot(r, 94, segment.onColor);
                    }
                    else if (currSegment[r - 2][q].Equals('0'))
                    {
                        setDot(r, 94, backgroundColor);
                    }
                }
                Invalidate();
                Thread.Sleep(25);
            }
            //////center lower half of message
            for (int i = 0; i < bottomColumnStop; i++)
            {
                //Move all dots 1 column left
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 8; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r, c + 1));
                    }
                }

                //Set last column to blank
                for (int r = 8; r < 14; r++)
                {
                    setDot(r, 94, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }
        }

         //Ahmad
        public void displayUpEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int stopMiddle = (14 - segmentLength) / 2;

            for (int i = 12; i > 0; i--)
            {
                //Move all dots 1 row down
                for (int r = 2; r < 14; r++)
                {
                    for (int c = 2; c < 94; c++)
                    {
                        setDot(r, c, getDotFore(r + 1, c));
                    }
                }
                
                //Set last row to next row in segment
                for (int c = 2; c < segmentLength; c++)
                {
                    if (currSegment[i][c - 2].Equals('1'))
                    {
                        
                        setDot(2, ((96 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c - 2].Equals('0'))
                    {
                      
                        setDot(2, ((96 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);

            }

            //Exit rest of segment to the down
            for (int i = 0; i < stopMiddle; i++)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c));
                    }
                }

                //Set last column to blank
                for (int c = 2; c > 94; c++)
                {
                    setDot(2, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }
        }

        //Ahmad
        //Edited on 11/14/2017
        public void displayDownEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int stopMiddle = (14 - segmentLength) / 2;

            for (int i = 0; i < 12; i++)
            {
                //Move all dots 1 row up
                 for (int c = 2; c < 94; c++)
                 {
                     for (int r = 2; r < 14; r++)
                     {
                         setDot(r, c, getDotFore(r + 1, c));
                     }
                 }


                //Set last row to next row in segment
                for (int c = 2; c < segmentLength; c++)
                {
                   if (currSegment[i][c-2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(13, ((96 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c-2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(13, ((96 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);

            }


            //Exit rest of segment to the up
            for (int i = 0; i < stopMiddle; i++)
                {
                    //Move all dots 1 column up
                    for (int c = 2; c < 93; c++)
                    {
                        for (int r = 2; r < 14; r++)
                        {
                            setDot(r, c, getDotFore(r + 1, c));
                        }
                    }

                    //Set last column to blank
                    for (int c = 2; c < 93; c++)
                    {
                        setDot(14, c, backgroundColor);
                    }
                    Thread.Sleep(25);
                    Invalidate();
                }
        }


        //Ahmad
        //Added on 11/14/2017
        public void displayUpsideDownEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int stopMiddle = (14 - segmentLength) / 2;

            for (int i = 0; i < 12; i++)
            {
                //Move all dots 1 row up
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c));
                    }
                }


                //Set last row to next row in segment
                for (int c = 2; c < segmentLength; c++)
                {
                    if (currSegment[i][c - 2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(2, ((96 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c - 2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(2, ((96 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);

            }

            //Exit rest of segment to the down
            for (int i = 0; i < stopMiddle; i++)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c));
                    }
                }

                //Set last column to blank
                for (int c = 2; c > 94; c++)
                {
                    setDot(2, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }
        }

        //Ahmad
        //Added on 11/14/2017
        public void displaySidewayEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int stopMiddle = (14 - segmentLength) / 2;

            for (int i = 0; i < 12; i++)
            {
                //Move all dots 1 row up
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r + 1, c + 1));
                    }
                }


                //Set last row to next row in segment
                for (int c = 2; c < segmentLength; c++)
                {
                    if (currSegment[i][c - 2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(13, ((96 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c - 2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(13, ((96 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);

            }


            //Exit rest of segment to the up
            for (int i = 0; i < stopMiddle; i++)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r + 1, c));
                    }
                }

                //Set last column to blank
                for (int c = 2; c < 93; c++)
                {
                    setDot(14, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
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
        public void displayScrollingSegment(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            Color onColor = segment.onColor;
            if (segment.isRandomColorScrolling)
            {
                onColor = randomColor();
            }
            int counter = 1;
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
                        setDot(r, 93, onColor);
                    }
                    else if (currSegment[r - 2][s].Equals('0'))
                    {                        
                        setDot(r, 93, backgroundColor);                        
                    }
                }

                //Counter for random color effect
                if(counter == 10)
                {
                    //If effect active change to random color
                    if(segment.isRandomColorScrolling)
                    {
                        onColor = randomColor();
                    }
                    counter = 1;
                }
                else
                {
                    counter++;
                }

                Invalidate();
                Thread.Sleep(segment.scrollSpeed);
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
                Thread.Sleep(segment.scrollSpeed);
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
            //Change this to affect speed of the effect
            int effectCycleTime = 1020;

            int updateIntervalTime = effectCycleTime / 102;
            int extraTime = (segment.segmentSpeed % 1020);   
            for (int a = segment.segmentSpeed / 1020; a > 0; a--)
            {
                for (int i = 255; i > -1; i -= 5)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        for (int c = 2; c < 94; c++)
                        {
                            if (getDotFore(r, c) != backgroundColor)
                            {
                                setDot(r, c, Color.FromArgb(i, getDotFore(r, c)));
                            }
                        }
                    }
                    
                    Invalidate();
                    Thread.Sleep(updateIntervalTime);
                }
                for (int i = 0; i < 256; i += 5)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        for (int c = 2; c < 94; c++)
                        {
                            if (getDotFore(r, c) != backgroundColor)
                            {
                                setDot(r, c, Color.FromArgb(i, getDotFore(r, c)));
                            }
                        }
                    }
                    
                    Invalidate();
                    Thread.Sleep(updateIntervalTime);
                }
            }
            Thread.Sleep(extraTime);
        }
        #endregion


        /*
         * 
         *   Exit Effects
         * 
         */
        #region Exit Effects
        //Heather edited on 11/10/17
        //Uses 2 helper methods to split and exit the segment concurrently
        public void displaySplitExit(Segment segment, Color backgroundColor)
        {
            //causes both methods to run concurrently.
            Parallel.Invoke(() =>
            {
                displayUpperSplitExit(segment, backgroundColor);
            },

            () =>
            {
                displayLowerSplitExit(segment, backgroundColor);
            }
            );

        }

        //Heather - Created on 11/10/17
        //Private method that is used in the displaySplitExit method.
        private void displayUpperSplitExit(Segment segment, Color backgroundColor)
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
                Thread.Sleep(25);
                Invalidate();
            }
        }

        //Heather - Created on 11/10/17
        //Private method that is used in the displaySplitExit method. Moves lower half of message off screen to the left
        private void displayLowerSplitExit(Segment segment, Color backgroundColor)
        {
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
                Thread.Sleep(25);
                Invalidate();
            }
        }

        //Ahmad
        //Edited on 11/14/2017
        public void displayUpExit(Segment segment, Color backgroundColor)
        {
            for (int i = 0; i < 14; i++)
            {
                //Move all dots 1 column up
                for (int c = 93; c > 0 ; c--)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r + 1, c));
                    }
                }

                //Set last column to blank
                for (int c = 2; c < 93; c++)
                {
                    setDot(14, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }
        }
        
        //Ahmad
        //Edited on 11/14/2017
        public void displayDownExit(Segment segment, Color backgroundColor)
        {
            //Exit rest of segment to the down
            for (int i = 14; i > 0; i--)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c));
                    }
                }

                //Set last column to blank
                for (int c = 2; c < 94; c++)
                {
                    setDot(2, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }

        }
        
        //Ahmad 
        //Added On 11/14/2017
        public void displayUpsideDownExit(Segment segment, Color backgroundColor)
        {
            for (int i = 0; i < 14; i++)
            {
                //Move all dots 1 column up
                for (int c = 93; c > 0; c--)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r + 1, c));
                    }
                }

                //Set last column to blank
                for (int c = 2; c < 93; c++)
                {
                    setDot(14, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }
        }
        
        //Ahmad
        //Added on 11/14/2017
        public void displaySidewayExit(Segment segment, Color backgroundColor)
        {

            //Exit rest of segment to the up
            for (int i = 0; i < 14; i++)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 93; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r + 1, c + 1));
                    }
                }

                //Set last column to blank
                for (int c = 2; c < 93; c++)
                {
                    setDot(14, c, backgroundColor);
                }
                Thread.Sleep(25);
                Invalidate();
            }
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
        public void borderThreadAbort()
        {
            //Stop Border Thread if running
            if (myBorderThread != null)
            {
                if (myBorderThread.IsAlive)
                {
                    myBorderThread.Suspend();
                    myBorderThread.Resume();
                    myBorderThread.Abort();
                }
            }
            clearBorder(BackColor);
        }

        public void borderThreadSuspend()
        {
            if (myBorderThread != null)
            {
                if (myBorderThread.IsAlive)
                {
                    myBorderThread.Suspend();
                }
            }            
        }

        public void borderThreadResume()
        {
            if (myBorderThread != null)
            {
                if (myBorderThread.IsAlive)
                {
                    if (myBorderThread.ThreadState == ThreadState.Suspended)
                    {
                        myBorderThread.Resume();
                    }
                }
            }            
        }

        public void clearBorder(Color backgroundColor)
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = backgroundColor;
            }
        }

        public void displayBorder(Color borderColor, int borderEffect)
        {
            if (borderEffect == 0)
            {
                noBorder();
            }
            else if (borderEffect == 1)
            {
                displayBorderHighlight(borderColor);
            }
            else if (borderEffect == 2)
            {
                staticBorder(borderColor);
            }
        }

        //Border effect 0
        public void noBorder()
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = BackColor;
            }
            while (true)
            {
                Invalidate();
                Thread.Sleep(200);
            }
        }

        //Border effect 1
        public void staticBorder(Color borderColor)
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = borderColor;
            }

            while (true)
            {
                Invalidate();
                Thread.Sleep(200);
            }
        }

        //Border effect 2
        public void displayBorderHighlight(Color borderColor)
        {
            #region 1 on:1 off
            //for (int a = 0; a < 220; a = a + 2)
            //{
            //    border[a].ForeColor = borderColor;
            //}

            //for (int a = 1; a < 220; a = a + 2)
            //{
            //    border[a].ForeColor = BackColor;
            //}
            #endregion


            #region 2 on:2 off
            //for (int a = 0; a < 220; a = a + 4)
            //{
            //    border[a].ForeColor = borderColor;
            //    border[a + 1].ForeColor = borderColor;
            //}

            //for (int a = 2; a < 220; a = a + 4)
            //{
            //    border[a].ForeColor = BackColor;
            //    border[a + 1].ForeColor = BackColor;
            //}
            #endregion

            #region 3 on:1 off
            for (int a = 0; a < 220; a = a + 4)
            {
                border[a].ForeColor = borderColor;
                border[a + 1].ForeColor = borderColor;
                border[a + 2].ForeColor = borderColor;
            }

            for (int a = 3; a < 220; a = a + 4)
            {
                border[a].ForeColor = BackColor;
            }
            #endregion

            Invalidate();

            Color oneColor;
            while (true)
            {
                oneColor = border[0].ForeColor;
                for (int i = 0; i < 219; i++)
                {
                    border[i].ForeColor = border[i + 1].ForeColor;
                }
                border[219].ForeColor = oneColor;
                Invalidate();
                Thread.Sleep(200);
            }

        }
        #endregion


        /*
         * 
         *   Image Effects
         * 
         */
        #region Image Effects
        public void displayImage(Segment image)
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
            clearMarquee(BackColor);
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

            //Hold Image on marquee for set time, redrawing over intervals
            for (int i = 0; i < (image.segmentSpeed / 25); i++)
            {
                Invalidate();
                Thread.Sleep(25);
            }

            //Clear Whole Marquee
            clearMarquee(BackColor);
            clearBorder(BackColor);
            Invalidate();          
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


        /*
         * 
         *   Utility Methods
         * 
         */
        #region Utility Methods
        public Color randomColor()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 20);
            if (randomNumber == 0)
            {
                return Color.Aqua;
            }
            else if (randomNumber == 1)
            {
                return Color.Blue;
            }
            else if (randomNumber == 2)
            {
                return Color.BlueViolet;
            }
            else if (randomNumber == 3)
            {
                return Color.Cyan;
            }
            else if (randomNumber == 4)
            {
                return Color.Fuchsia;
            }
            else if (randomNumber == 5)
            {
                return Color.DeepPink;
            }
            else if (randomNumber == 6)
            {
                return Color.Gold;
            }
            else if (randomNumber == 7)
            {
                return Color.GreenYellow;
            }
            else if (randomNumber == 8)
            {
                return Color.HotPink;
            }
            else if (randomNumber == 9)
            {
                return Color.LightCoral;
            }
            else if (randomNumber == 10)
            {
                return Color.Lime;
            }
            else if (randomNumber == 11)
            {
                return Color.MediumSpringGreen;
            }
            else if (randomNumber == 12)
            {
                return Color.Navy;
            }
            else if (randomNumber == 13)
            {
                return Color.OrangeRed;
            }
            else if (randomNumber == 14)
            {
                return Color.Purple;
            }
            else if (randomNumber == 15)
            {
                return Color.Red;
            }
            else if (randomNumber == 16)
            {
                return Color.Snow;
            }
            else if (randomNumber == 17)
            {
                return Color.SpringGreen;
            }
            else if (randomNumber == 18)
            {
                return Color.Turquoise;
            }
            else if (randomNumber == 19)
            {
                return Color.Violet;
            }
            else
            {
                return Color.Yellow;
            }
        }

        #endregion
    }
}
