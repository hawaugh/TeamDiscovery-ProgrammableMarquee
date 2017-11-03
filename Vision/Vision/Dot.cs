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
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(ForeColor);
            e.Graphics.FillPie(myBrush, Point.Empty.X, Point.Empty.Y, Width - 1, Height - 1, 0, 360);
        }
    }
}

    

