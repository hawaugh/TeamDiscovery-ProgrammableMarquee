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
        private static Random rnd = new Random();
        private static int prevRandom = -1;

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

            while (true)
            {
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
                            //check if last segment was an image
                            if (currentIsImage)
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
                                clearBorder(BackColor);
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
            }
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
            else if (segment.entranceEffect == 7)
            {
                displaySidewayUpEntrance(segment, backgroundColor);
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
            else if (segment.middleEffect == 3)
            {
                displayWaveEffect(segment);
            }
            else if (segment.middleEffect == 4)
            {
                displaySpotlightEffect(segment);
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
            else if (segment.exitEffect == 7)
            {
                displaySidewayDownExit(segment, backgroundColor);
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

        //Heather - edited on 11/25/17
        //Displays segment by scrolling top half in from left and bottom half in from left.
        public void displaySplitEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            Segment seg = segment;
            Color col = backgroundColor;
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int stopForCenterBottom = (96 - segmentLength) / 2 - 2; //gives stop column for bottom half in from left.                     
            int bColLoopStart = 2;
            int bHalfSegmentLengthStart = 0;
            //scroll top half from left-side of screen and bottom half from right-side of screen
            for (int s = segmentLength - 1; s > -1; s--) //this is used to set the current segment column around line 356
            {
                //Move dots until they are on screen
                for (int c = 93; c > 1; c--)
                {
                    for (int r = 2; r < 8; r++)
                    {
                        setDot(r, c, getDotFore(r, c - 1));
                        setDot(r + 6, bColLoopStart, getDotFore(r + 6, bColLoopStart + 1));
                    }
                    bColLoopStart++;
                }
                bColLoopStart = 2;    //resets this variable to the original value for the next iteration of loop                          

                //Set last column to next column in segment
                for (int r = 2; r < 8; r++)
                {
                    if (currSegment[r - 2][s].Equals('1') && currSegment[r + 4][bHalfSegmentLengthStart].Equals('1'))
                    {
                        setDot(r, 2, segment.onColor);
                        setDot(r + 6, 94, segment.onColor);
                    }
                    else if (currSegment[r - 2][s].Equals('0') && currSegment[r + 4][bHalfSegmentLengthStart].Equals('0'))
                    {
                        setDot(r, 93, backgroundColor);
                        setDot(r + 6, 94, backgroundColor);
                    }
                    else if (currSegment[r - 2][s].Equals('1') && currSegment[r + 4][bHalfSegmentLengthStart].Equals('0'))
                    {
                        setDot(r, 2, segment.onColor);
                        setDot(r + 6, 94, backgroundColor);
                    }
                    else if (currSegment[r - 2][s].Equals('0') && currSegment[r + 4][bHalfSegmentLengthStart].Equals('1'))
                    {
                        setDot(r, 93, backgroundColor);
                        setDot(r + 6, 94, segment.onColor);
                    }
                }
                bHalfSegmentLengthStart++;
                Invalidate();
                Thread.Sleep(25);
            }

            //Center the segment halves
            for (int j = 0; j < stopForCenterBottom; j++) //this is used to set the current segment column around line 356
            {
                //Move dots until they are on screen
                for (int c = 93; c > 1; c--)
                {
                    for (int r = 2; r < 8; r++)
                    {
                        setDot(r, c, getDotFore(r, c - 1));
                        setDot(r + 6, bColLoopStart, getDotFore(r + 6, bColLoopStart + 1));
                    }
                    bColLoopStart++;
                }
                bColLoopStart = 2;    //resets this variable to the original value for the next iteration of loop 
                Invalidate();
                Thread.Sleep(25);   
            }

            //move bottom segment once more (Because the bottom has to travel 1 further)
            for (int c = 93; c > 1; c--)
            {
                for (int r = 2; r < 8; r++)
                {
                    setDot(r + 6, bColLoopStart, getDotFore(r + 6, bColLoopStart + 1));
                }
                bColLoopStart++;
            }
            Invalidate();
        }
         //Ahmad
        public void displayUpEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int centerPosition = (96 - segmentLength) / 2;
            string currString;

            for (int i = 12; i > 0; i--)
            {
                //Move all dots 1 row down
                for (int r = 13; r > 2; r--)
                {
                    for (int c = 2; c < 94; c++)
                    {
                        setDot(r, c, getDotFore(r - 1, c));
                    }
                }

                currString = currSegment[i - 1];
                //Set last row to next row in segment
                for (int c = centerPosition; c < centerPosition + segmentLength; c++)
                {
                    if (currString[c - centerPosition].Equals('1'))
                    {
                        
                        setDot(2, c, segment.onColor);
                    }
                    else if (currString[c - centerPosition].Equals('0'))
                    {
                      
                        setDot(2, c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);
            }
        }

        //Ahmad
        //Edited on 11/27/2017
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
                for (int c = 2; c < segmentLength + 2; c++)
                {
                   if (currSegment[i][c-2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(13, ((92 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c-2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(13, ((92 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);
            }


            //Exit rest of segment to the up
            //Isn't need for this part since start of the code does this as well
            /*for (int i = 0; i < stopMiddle; i++)
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
                }*/
        }

      //Ahmad
        //Added on 11/27/2017
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
                for (int c = 2; c < segmentLength + 2; c++)
                {
                    if (currSegment[i][c - 2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(2, ((92 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c - 2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(2, ((92 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);
            }

            for (int i = 0; i < 12; i++)
            {
                //Move all dots 1 row up for up section
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 13 - i; r < 14; r++)
                    {
                        setDot(r, c, getDotFore(r + 1, c));
                    }
                }

                //Move all Dots 1 row down for down section
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 12 - i; r > 1; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c));
                    }
                }

                //Set last row to next row in segment
                for (int c = 2; c < segmentLength + 2; c++)
                {
                    if (currSegment[i][c - 2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(13, ((92 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c - 2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(13, ((92 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);
            }

            //Exit rest of segment to the down
            //Isn't need so its took it out
            /*
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
            }*/
        }

        //Ahmad
        //Added on 11/27/2017
        public void displaySidewayEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;

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
                for (int c = 2; c < segmentLength + 2; c++)
                {
                    if (currSegment[i][c - 2].Equals('1'))
                    {
                        //setDot(14, c, segment.onColor);
                        setDot(13, ((92 - segmentLength) / 2) + c, segment.onColor);
                    }
                    else if (currSegment[i][c - 2].Equals('0'))
                    {
                        //setDot(14, c, backgroundColor);
                        setDot(13, ((92 - segmentLength) / 2) + c, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);
            }

            Thread.Sleep(100);

            //Number of iterations
            for (int i = 0; i < 11; i++)
            {
                //The range of rows that need to be updated, based on iteration number
                for (int r = 12 - i; r > 1; r--)
                {
                    //Recreate each row from the segmentarray and put it where it needs to be based on the iteration number
                    for (int c = 2; c < segmentLength + 2; c++)
                    {
                        if (currSegment[r - 2][c - 2].Equals('1'))
                        {
                            if (((92 - segmentLength) / 2) + c - (12 - i - r) > 1)
                            {
                                setDot(r, ((92 - segmentLength) / 2) + c - (12 - i - r), segment.onColor);
                            }
                        }
                        else if (currSegment[r - 2][c - 2].Equals('0'))
                        {
                            if (((92 - segmentLength) / 2) + c - (12 - i - r) > 1)
                            {
                                setDot(r, ((92 - segmentLength) / 2) + c - (12 - i - r), backgroundColor);
                            }
                        }
                    }
                    //Turn the dot before the text off
                    if (((96 - segmentLength) / 2) - (12 - i - r) > 2)
                    {
                        setDot(r, ((94 - segmentLength) / 2) - (12 - i - r), backgroundColor);
                    }
                }
                Invalidate();
                Thread.Sleep(25);
            }


            //Exit rest of segment to the up
            //Once again this part of the code is not needed 
            /*for (int i = 0; i < stopMiddle; i++)
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
            }*/
        }
        
        //Ahmad
        //Added on 11/27/2017
        public void displaySidewayUpEntrance(Segment segment, Color backgroundColor)
        {
            clearMarquee(backgroundColor);
            String[] currSegment = segment.getMessageMatrix();
            int segmentLength = currSegment[0].Length;
            int centerPosition = (96 - segmentLength) / 2;
            string currString;

            for (int i = 12; i > 0; i--)
            {
                //Move all dots 1 row down
                for (int r = 13; r > 2; r--)
                {
                    for (int c = 2; c < 94; c++)
                    {
                        setDot(r, c, getDotFore(r - 1 , c + 1));
                    }
                }

                currString = currSegment[i - 1];
                //Set last row to next row in segment
                for (int c = centerPosition; c < centerPosition + segmentLength; c++)
                {
                    if (currString[c - centerPosition].Equals('1'))
                    {

                        setDot(2, c + 5 , segment.onColor);
                    }
                    else if (currString[c - centerPosition].Equals('0'))
                    {

                        setDot(2, c + 5, backgroundColor);
                    }

                }
                Invalidate();
                Thread.Sleep(25);
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

        public void displayRandomColors(Segment segment, Color backgroundColor)
        {
            List<Dot> activeDotList = new List<Dot>();
            for (int r = 2; r < 14; r++)
            {
                for (int c = 2; c < 94; c++)
                {
                    if (getDotFore(r, c).ToArgb() != backgroundColor.ToArgb())
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

        public void displayWaveEffect(Segment segment)
        {
            int waveOne = -15;
            int waveTwo = -45;
            int waveThree = -75;
            int waveFour = -105;
            for (int i = 0; i < (segment.segmentSpeed / 50); i++)
            {
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        //Check wave one
                        if ((c - waveOne) >= 0 && (c - waveOne) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveOne) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveOne) < 0 && (c - waveOne) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveOne - c) * 17, getDotFore(r, c)));
                        }

                        //Check wave two
                        if ((c - waveTwo) >= 0 && (c - waveTwo) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveTwo) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveTwo) < 0 && (c - waveTwo) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveTwo - c) * 17, getDotFore(r, c)));
                        }

                        //Check wave three
                        if ((c - waveThree) >= 0 && (c - waveThree) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveThree) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveThree) < 0 && (c - waveThree) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveThree - c) * 17, getDotFore(r, c)));
                        }

                        //Check wave four
                        if ((c - waveFour) >= 0 && (c - waveFour) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveFour) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveFour) < 0 && (c - waveFour) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveFour - c) * 17, getDotFore(r, c)));
                        }
                    }                    
                }
                Invalidate();
                Thread.Sleep(50);
                //update wave indexes
                waveOne++;
                waveTwo++;
                waveThree++;
                waveFour++;
                if (waveFour > 110)
                {
                    waveOne = -15;
                    waveTwo = -45;
                    waveThree = -75;
                    waveFour = -105;
                }
            }

            //Clear waves off marquee for end of effect
            for (int i = waveFour; i < 111; i++)
            {
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        //Check wave one
                        if ((c - waveOne) >= 0 && (c - waveOne) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveOne) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveOne) < 0 && (c - waveOne) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveOne - c) * 17, getDotFore(r, c)));
                        }

                        //Check wave two
                        if ((c - waveTwo) >= 0 && (c - waveTwo) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveTwo) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveTwo) < 0 && (c - waveTwo) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveTwo - c) * 17, getDotFore(r, c)));
                        }

                        //Check wave three
                        if ((c - waveThree) >= 0 && (c - waveThree) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveThree) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveThree) < 0 && (c - waveThree) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveThree - c) * 17, getDotFore(r, c)));
                        }

                        //Check wave four
                        if ((c - waveFour) >= 0 && (c - waveFour) < 15)
                        {
                            setDot(r, c, Color.FromArgb((c - waveFour) * 17, getDotFore(r, c)));
                        }
                        if ((c - waveFour) < 0 && (c - waveFour) >= -15)
                        {
                            setDot(r, c, Color.FromArgb((waveFour - c) * 17, getDotFore(r, c)));
                        }
                    }
                }
                Invalidate();
                Thread.Sleep(50);
                //update wave indexes
                waveOne++;
                waveTwo++;
                waveThree++;
                waveFour++;                
            }
        }

        public void displaySpotlightEffect(Segment segment)
        {
            //Curtain down to zero the alpha

            for (int curtain = -15; curtain < 14; curtain++)
            {
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        if ((r - curtain) >= 1 && (r - curtain) < 17)
                        {
                            setDot(r, c, Color.FromArgb((r - curtain) * 15, getDotFore(r, c)));
                        }
                        if ((r - curtain) == 0)
                        {
                            setDot(r, c, Color.FromArgb(10, getDotFore(r, c)));
                        }
                    }
                }
                Invalidate();
                Thread.Sleep(50);
            }

            int spotlightC = ((96 - segment.getMessageMatrix()[0].Length) / 2) - 10;
            int spotlightR = 0;
            int radius;
            int direction = 0;
            for (int i = 0; i < (segment.segmentSpeed / 25); i++)
            {
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        radius = (int)Math.Sqrt((double)((c - spotlightC) * (c - spotlightC)) + ((r - spotlightR) * (r - spotlightR)));
                        if (radius <= 16)
                        {
                            setDot(r, c, Color.FromArgb((17 - radius) * 15, getDotFore(r, c)));
                        }
                        else if (radius == 17)
                        {
                            setDot(r, c, Color.FromArgb(10, getDotFore(r, c)));
                        }
                    }
                }
                Invalidate();
                Thread.Sleep(25);
                //Spotlight moving right
                if (direction == 0)
                {
                    spotlightC++;
                    if (spotlightC == (((96 + segment.getMessageMatrix()[0].Length) / 2) + 8))
                    {
                        direction = 1;
                    }
                }
                //Spotlight moving down
                else if (direction == 1)
                {
                    spotlightR++;
                    if (spotlightR == 15)
                    {
                        direction = 2;
                    }
                }
                //Spotlight moving left
                else if (direction == 2)
                {
                    spotlightC--;
                    if (spotlightC == ((96 - segment.getMessageMatrix()[0].Length) / 2) - 10)
                    {
                        direction = 3;
                    }
                }
                //Spotlight moving up
                else if (direction == 3)
                {
                    spotlightR--;
                    if (spotlightR == 0)
                    {
                        direction = 0;
                    }
                }
            }

            //Blank out Marquee
            for (int c = 2; c < 94; c++)
            {
                for (int r = 2; r < 14; r++)
                {
                    setDot(r, c, Color.FromArgb(10, getDotFore(r, c)));
                }
            }

            //Raise Curtain
            for (int curtain = 31; curtain > 1; curtain--)
            {
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 2; r < 14; r++)
                    {
                        if ((curtain - r) >= 0 && (curtain - r) < 17)
                        {
                            setDot(r, c, Color.FromArgb((17 - (curtain - r)) * 15, getDotFore(r, c)));
                        }
                    }
                }
                Invalidate();
                Thread.Sleep(50);
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
        
        //Ahmad
        //Edited on 11/27/2017
        public void displaySidewayDownExit(Segment segment, Color backgroundColor)
        {
            //Exit rest of segment to the down
            for (int i = 14; i > 0; i--)
            {
                //Move all dots 1 column up
                for (int c = 2; c < 94; c++)
                {
                    for (int r = 14; r > 2; r--)
                    {
                        setDot(r, c, getDotFore(r - 1, c + 1));
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
    

        public void displayRandomExit(Segment segment, Color backgroundColor)
        {
            List<Dot> activeDotList = new List<Dot>();
            for (int r = 2; r < 14; r++)
            {
                for (int c = 2; c < 94; c++)
                {
                    if (getDotFore(r, c).ToArgb() != backgroundColor.ToArgb())
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
                staticBorder(borderColor);
            }
            else if (borderEffect == 2)
            {
                displayBorderHighlight(borderColor);
            }
            else if (borderEffect == 3)
            {
                displayRandomColorBorder();
            }
            else if (borderEffect == 4)
            {
                displayRandomShootingBorder(borderColor);
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

        public void displayRandomColorBorder()
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].randColor();
            }

            while (true)
            {
                for (int i = 255; i > -1; i -= 5)
                {
                    for (int b = 0; b < 220; b++)
                    {
                        border[b].ForeColor = Color.FromArgb(i, border[b].ForeColor);
                    }

                    Invalidate();
                    Thread.Sleep(10);
                }
                for (int i = 0; i < 256; i += 5)
                {
                    for (int b = 0; b < 220; b++)
                    {
                        border[b].ForeColor = Color.FromArgb(i, border[b].ForeColor);
                    }

                    Invalidate();
                    Thread.Sleep(10);
                }
            }
        }

        public void displayRandomShootingBorder(Color borderColor)
        {
            for (int b = 0; b < 220; b++)
            {
                border[b].ForeColor = borderColor;
            }

            Color newColor;
            while (true)
            {
                //From Left to Right
                newColor = randomColor();
                for (int b = 212; b >= 103; b--)
                {
                    //Set Bottom dots
                    border[b].ForeColor = newColor;

                    //Set Top dots
                    if (b > 205)
                    {
                        border[425 - b].ForeColor = newColor;
                    }
                    else
                    {
                        border[205 - b].ForeColor = newColor;
                    }

                    Invalidate();
                    Thread.Sleep(10);
                }

                //From Right to Left
                newColor = randomColor();
                for (int b = 103; b <= 212; b++)
                {
                    //Set Bottom dots
                    border[b].ForeColor = newColor;

                    //Set Top dots
                    if (b > 205)
                    {
                        border[425 - b].ForeColor = newColor;
                    }
                    else
                    {
                        border[205 - b].ForeColor = newColor;
                    }

                    Invalidate();
                    Thread.Sleep(10);
                }
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
            int randomNumber;
            do
            {
                randomNumber = rnd.Next(0, 32);
            }
            while (randomNumber == prevRandom);

            prevRandom = randomNumber;

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
            else if (randomNumber == 20)
            {
                return Color.Yellow;
            }
            else if (randomNumber == 21)
            {
                return Color.Aquamarine;
            }
            else if (randomNumber == 22)
            {
                return Color.Maroon;
            }
            else if (randomNumber == 23)
            {
                return Color.MediumOrchid;
            }
            else if (randomNumber == 24)
            {
                return Color.MediumSeaGreen;
            }
            else if (randomNumber == 25)
            {
                return Color.OliveDrab;
            }
            else if (randomNumber == 26)
            {
                return Color.Firebrick;
            }
            else if (randomNumber == 27)
            {
                return Color.Crimson;
            }
            else if (randomNumber == 28)
            {
                return Color.Magenta;
            }
            else if (randomNumber == 29)
            {
                return Color.LightPink;
            }
            else if (randomNumber == 30)
            {
                return Color.DarkRed;
            }
            else 
            {
                return Color.Coral;
            }
        }
        #endregion
    }
}
