//Ahmad

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vision
{
    class Image
    {
        private Bitmap imageBitmap;
        private string filename;
        private double dotRadius;
        private double deadSpace;
        private string bitmapString;

        //Constructor
        public Image()
        {

        }

        public double getDotRadius()
        {
            return dotRadius;
        }

        public void setDotRadius(double newDotRadius)
        {
            dotRadius = newDotRadius;
        }

        public double getDeadSpace()
        {
            return deadSpace;
        }

        public void setDeadSpace(double newDeadSpace)
        {
            deadSpace = newDeadSpace; 
        }
    }
}
