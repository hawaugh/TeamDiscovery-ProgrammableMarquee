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

        
        //Ahmad Omar
        //Edited on 11/29/2017
        //sets dot color to a random color
        //Added 11 new colors that will populate any text segments
        public void randColor()
        {
            int randomNumber = rnd.Next(0, 32);
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
            else if (randomNumber == 20)
            {
                _ForeColor = Color.Yellow;
            }
            else if (randomNumber == 21)
            {
                _ForeColor = Color.Aquamarine;
            }
            else if (randomNumber == 22)
            {
                _ForeColor = Color.Maroon;
            }
            else if (randomNumber == 23)
            {
                _ForeColor = Color.MediumOrchid;
            }
            else if (randomNumber == 24)
            {
                _ForeColor = Color.MediumSeaGreen;
            }
            else if (randomNumber == 25)
            {
                _ForeColor = Color.OliveDrab;
            }
            else if (randomNumber == 26)
            {
                _ForeColor = Color.Firebrick;
            }
            else if (randomNumber == 27)
            {
                _ForeColor = Color.Crimson;
            }
            else if (randomNumber == 28)
            {
                _ForeColor = Color.Magenta;
            }
            else if (randomNumber == 29)
            {
                _ForeColor = Color.LightPink;
            }
            else if (randomNumber == 30)
            {
                _ForeColor = Color.DarkRed;
            }
            else
            {
                _ForeColor = Color.Coral;
            }
        }
    }
}

    

