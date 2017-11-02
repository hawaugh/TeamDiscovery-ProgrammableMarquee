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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Vision
{
    class Marquee
    {
        private Dot[,] matrix = new Dot[16, 96];
        private Dot[] border = new Dot[220];

        public Marquee(Panel objPanel)
        {
            createMarquee(objPanel);
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

        private void createMarquee(Panel objPanel)
        {
            int adjustedSize = ((objPanel.Width - 10) / 96) * 96;
            int dotHeight = adjustedSize / 96;
            int dotWidth = dotHeight;
            Color dotForeColor = Color.Green;
            Color dotBackColor = Color.Black;
            int xLoc = (objPanel.Width - adjustedSize) / 2;
            int yLoc = 3;
            objPanel.SuspendLayout();
            for (int r = 0; r < 16; r++)
            {
                for (int c = 0; c < 96; c++)
                {
                    Dot objDot = new Dot();
                    objDot.Width = dotWidth;
                    objDot.Height = dotHeight;
                    objDot.ForeColor = dotForeColor;
                    objDot.BackColor = dotBackColor;
                    objDot.Location = new Point(xLoc, yLoc);

                    objPanel.Controls.Add(objDot);
                    matrix[r, c] = objDot;
                    if (((r == 1 || r == 14) && (c > 0 && c < 95)) || ((r > 1 && r < 14) && (c == 1 || c == 94))) //blank out pad area
                    {
                        matrix[r, c].ForeColor = Color.Black;
                        matrix[r, c].BackColor = Color.Black;
                    }
                    xLoc += dotWidth + 0;
                }
                xLoc = (objPanel.Width - adjustedSize) / 2;
                yLoc += dotHeight + 1;
            }
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
            objPanel.ResumeLayout();
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
        }  

        //Cycles through segments and displays them
        public void displayMessage(Message message)
        {
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


        /*
         * 
         *   Entrance Effects
         * 
         */

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



        /*
         * 
         *   Middle Effects
         * 
         */

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
            }
        }

        //Nick
        //The marquee will already have the message displayed and the dots are set for you to edit them in this method
        public void displayRandomColors(Segment segment, Color backgroundColor)
        {
            
        }

        //Jeremy
        public void displayFadeEffect(Segment segment, Color backgroundColor)
        {

        }

        /*
         * 
         *   Exit Effects
         * 
         */

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

        /*
         * 
         *   Border Effects
         * 
         */

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

        public void displayImage(Image image)
        {

        }

        /*
        public Message loadXML()
        {
           
        }
        */

        public void saveXML()
        {

        }
    }
}
