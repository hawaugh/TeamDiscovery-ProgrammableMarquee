//Edited on 9/24 Ahmad

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


/*namespace Vision
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
