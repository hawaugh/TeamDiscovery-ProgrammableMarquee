/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Dot.cs
// Description: Creates the dots for the Marquee
//
// Name: Ahmad
// Last Edit: 10/22 - Heather
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
    }
}

    

