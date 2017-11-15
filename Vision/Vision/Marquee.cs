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
                  else if (segment.entranceEffect == 5)
            {
                displayUpsideDownEntrance(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(segmentSpeed);
            }
                  else if (segment.entranceEffect == 6)
            {
                displaySidewayEntrance(segment, backgroundColor, scrollSpeed);
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
                displayUpExit(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 3)
            {
                displayDownExit(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 4)
            {
                displayRandomExit(segment, backgroundColor);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 5)
            {
                displayUpsideDownExit(segment, backgroundColor, scrollSpeed);
                Thread.Sleep(500);
            }
            else if (segment.exitEffect == 6)
            {
                 displaySidewayExit(segment, backgroundColor, scrollSpeed);
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
        public void displaySplitEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {
            clearMarquee(backgroundColor);
            Segment seg = segment;
            Color col = backgroundColor;
            int speed = scrollSpeed;

            //causes both methods to run concurrently.
            Parallel.Invoke(() =>
            {
                displayUpperSplitEntrance(seg, col, speed);
            },

            () =>
            {
                displayLowerSplitEntrance(seg, col, speed);
            }
            );          
        }
        //Heather - Created on 11/10/17
        //private method that will display upper half of segment.  
        //To be used in displaySplitEntrance that will run concurrently with lower half
        private void displayUpperSplitEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {
           
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int topColumnStop = (96 - segmentLength) / 2 + segmentLength + 4; //gives stop column for top half scrolling in from right                     

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
        }
        //Heather - Created on 11/10/17
        //private method that will display lower half of message scrolling in.
        //Will be called in displaySplitEntrance and used to run concurrently with upper half method
        private void displayLowerSplitEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
        {   
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;           
            int bottomColumnStop = (96 - segmentLength) / 2;   //gives stop column for bottom half in from left. 

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
                Thread.Sleep(scrollSpeed);

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
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }

        //Ahmad
        //Edited on 11/14/2017
        public void displayDownEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);

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
                    Thread.Sleep(scrollSpeed);
                    Invalidate();
                }
        }


        //Ahmad
        //Added on 11/14/2017
        public void displayUpsideDownEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);

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
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }

        //Ahmad
        //Added on 11/14/2017
        public void displaySidewayEntrance(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);

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
                Thread.Sleep(scrollSpeed);
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
            
            for (int a = 4; a > 0; a--)
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
                    Thread.Sleep(10);
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
                    Thread.Sleep(10);
                }
            }
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
        public void displaySplitExit(Segment segment, Color backgroundColor, int scrollSpeed)
        {
            //causes both methods to run concurrently.
            Parallel.Invoke(() =>
            {
                displayUpperSplitExit(segment, backgroundColor, scrollSpeed);
            },

            () =>
            {
                displayLowerSplitExit(segment, backgroundColor, scrollSpeed);
            }
            );

        }

        //Heather - Created on 11/10/17
        //Private method that is used in the displaySplitExit method.
        private void displayUpperSplitExit(Segment segment, Color backgroundColor, int scrollSpeed)
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
        }

        //Heather - Created on 11/10/17
        //Private method that is used in the displaySplitExit method. Moves lower half of message off screen to the left
        private void displayLowerSplitExit(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }

        //Ahmad
        //Edited on 11/14/2017
        public void displayUpExit(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }
        
        //Ahmad
        //Edited on 11/14/2017
        public void displayDownExit(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }

        }
        
        //Ahmad 
        //Added On 11/14/2017
        public void displayUpsideDownExit(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);
                Invalidate();
            }
        }
        
        //Ahmad
        //Added on 11/14/2017
        public void displaySidewayExit(Segment segment, Color backgroundColor, int scrollSpeed)
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
                Thread.Sleep(scrollSpeed);
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

            for (int a = 0; a < 220; a = a + 2)
            {
                border[a].ForeColor = borderColor;
            }

            for (int a = 1; a < 220; a = a + 2)
            {
                border[a].ForeColor = BackColor;
            }
            Invalidate();

            while (true)
            {
                for (int i = 0; i < 219; i++)
                {
                    border[i].ForeColor = border[i + 1].ForeColor;
                }
                border[219].ForeColor = border[0].ForeColor;
                Invalidate();
                Thread.Sleep(50);
            }

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
