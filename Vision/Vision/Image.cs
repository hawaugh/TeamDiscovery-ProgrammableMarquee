/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Image.cs
// Description: 
//
// Name: Ahmad
// Last Edit: 
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vision
{
    
    class Image : Segment
    {
        private Bitmap _scaledBitmap;
        private float _imageAspect;
        private const float ASPECT_RATIO = 6;

        //Constructor
        public Image(string filename)
        {
            //creates the image from file
            Bitmap imageBitmap = new Bitmap(filename);
            _imageAspect = imageBitmap.Width / imageBitmap.Height;

            if (_imageAspect < ASPECT_RATIO)  //Scaled if ratio taller than marquee
            {
                _scaledBitmap = new Bitmap(imageBitmap,(int) Math.Round(16 * _imageAspect), 16);
            }
            else if (_imageAspect > ASPECT_RATIO) //Scaled if ratio wider than marquee
            {
                _scaledBitmap = new Bitmap(imageBitmap, 96, (int)Math.Round(96 / _imageAspect));
            }
            else //Aspect ratio equals marquee
            {
                _scaledBitmap = new Bitmap(imageBitmap, 96, 16);
            }
        }

        public Color getPixel(int c, int r)
        {
            return _scaledBitmap.GetPixel(c, r);
        }

        public int getWidth()
        {
            return _scaledBitmap.Width;
        }

        public int getHeight()
        {
            return _scaledBitmap.Height;
        }

        //getter/setter for scaledBitmap
        public float imageAspect 
        {
            get { return _imageAspect; }
            set {}
        }

        //getter/setter for scaledBitmap
        public Bitmap scaledBitmap
        {
            get { return _scaledBitmap; }
            set {}
        }
    }
}
