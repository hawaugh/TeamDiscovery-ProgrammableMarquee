//Edited on 9/24 Ahmad

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
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
        Testing.Dot D = new Testing.Dot();
        D.Active = true;
        System.Console.WriteLine(D.Active);
    }

}*/
