/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Dot.cs
// Description: Stores dot information for the Marquee
//
// Name: Logan
// Last Edit: 11/6
/////////////////////////////////////////////////////﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Vision
{
    class Dot
    {
        private Color _ForeColor;
        private static Random rnd = new Random();

        public Dot()
        {
            _ForeColor = Color.DarkGray;
        }

        //getter/setter for ForeColor
        public Color ForeColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

        //sets dot color to a random color
        public void randColor()
        {
            int randomNumber = rnd.Next(0, 20);
            if (randomNumber == 0)
            {
                _ForeColor = Color.Aqua;
            }
            else if (randomNumber == 1)
            {
                _ForeColor = Color.Blue;
            }
            else if (randomNumber == 2)
            {
                _ForeColor = Color.BlueViolet;
            }
            else if (randomNumber == 3)
            {
                _ForeColor = Color.Cyan;
            }
            else if (randomNumber == 4)
            {
                _ForeColor = Color.Fuchsia;
            }
            else if (randomNumber == 5)
            {
                _ForeColor = Color.DeepPink;
            }
            else if (randomNumber == 6)
            {
                _ForeColor = Color.Gold;
            }
            else if (randomNumber == 7)
            {
                _ForeColor = Color.GreenYellow;
            }
            else if (randomNumber == 8)
            {
                _ForeColor = Color.HotPink;
            }
            else if (randomNumber == 9)
            {
                _ForeColor = Color.LightCoral;
            }
            else if (randomNumber == 10)
            {
                _ForeColor = Color.Lime;
            }
            else if (randomNumber == 11)
            {
                _ForeColor = Color.MediumSpringGreen;
            }
            else if (randomNumber == 12)
            {
                _ForeColor = Color.Navy;
            }
            else if (randomNumber == 13)
            {
                _ForeColor = Color.OrangeRed;
            }
            else if (randomNumber == 14)
            {
                _ForeColor = Color.Purple;
            }
            else if (randomNumber == 15)
            {
                _ForeColor = Color.Red;
            }
            else if (randomNumber == 16)
            {
                _ForeColor = Color.Snow;
            }
            else if (randomNumber == 17)
            {
                _ForeColor = Color.SpringGreen;
            }
            else if (randomNumber == 18)
            {
                _ForeColor = Color.Turquoise;
            }
            else if (randomNumber == 19)
            {
                _ForeColor = Color.Violet;
            }
            else
            {
                _ForeColor = Color.Yellow;
            }
        }
    }
}

    

