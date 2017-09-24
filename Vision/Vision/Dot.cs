//Edited on 9/24 Ahmad

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
                //This was just added to test that I would be able to find and test the Active getter and setter
                this.Active = true;
            }

            //Most c# getter/setters are written in this fashion
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
    
    
 // Original   
 /* class Dot
    {
        private string dotColor;
        private bool active;

        //Constructor
        public Dot()
        {

        }

        public bool getActive()
        {

        }

        public void setActive()
        {

        }

        public string getDotColor()
        {

        }

        public void setDotColor()
        {

        }
    }*/
