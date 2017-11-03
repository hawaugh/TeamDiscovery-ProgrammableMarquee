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
    class Dot : Control
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(ForeColor);
            e.Graphics.FillEllipse(myBrush, new Rectangle(Point.Empty, new Size(Width - 1, Height - 1)));
        }
    }
}

    

