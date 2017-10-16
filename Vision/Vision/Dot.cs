/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Dot.cs
// Description: Creates the dots for the Marquee
//
// Name: Ahmad
// Last Edit: 9/24
/////////////////////////////////////////////////////﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
   
        class Dot
        {
            private string _dotColor;
            private static bool _setActive;


            //Constructor
            public Dot()
            {
                //this.Active = false this will make Active value = false but with the example at the bottom it will change 
                // to true
                
            }

            public bool Active
            {
                get { return _setActive; }
                set { _setActive = value; }
            }

            public string dotColor
            {
                get { return _dotColor; }
                set { _dotColor = value; }
            }
        }
}

/*class Program
{
    static void Main()
    {
        Vision.Dot D = new Vision.Dot();
        D.Active = true;
        System.Console.WriteLine(D.Active);
    }

}*/
