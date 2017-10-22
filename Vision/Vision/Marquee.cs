/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Marquee.cs
// Description: 
//
// Name: Ahmad
// Last Edit: 10/22 - Heather
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
            Color dotForeColor = Color.Red;
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
            objPanel.ResumeLayout();
        }   

        //Will choose correct display method with if/else
        public void displayMessage(Message message)
        {

        }

        public void displayStaticMessage(Message message)
        {

        }

        //Logan
        public void displayScrollingMessage(Message message)
        {

        }

        //Logan
        public void displaySubsegmentMessage(Message message)
        {

        }

        //Heather
        public void displayUpperLowerSplitMessage(Message message)
        {

        }

        //Nick
        public void displayRandomColorMessage(Message message)
        {

        }

        //Ahmad
        public void displayUpDownDisappearMessage(Message message)
        {

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
