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
        public Image(Bitmap imageBitmap, Rectangle rectangle, Int32 pixelateSize)
        {
            //creates the image from file
            imageBitmap = new Bitmap(filename);

            Bitmap pixelated = new System.Drawing.Bitmap(imageBitmap.Width, imageBitmap.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = System.Drawing.Graphics.FromImage(pixelated))
                graphics.DrawImage(imageBitmap, new System.Drawing.Rectangle(0, 0, imageBitmap.Width, imageBitmap.Height),
                    new Rectangle(0, 0, imageBitmap.Width, imageBitmap.Height), GraphicsUnit.Pixel);

            // look at every pixel in the rectangle while making sure we're within the image bounds
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < imageBitmap.Width; xx += pixelateSize)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < imageBitmap.Height; yy += pixelateSize)
                {
                    Int32 offsetX = pixelateSize / 2;
                    Int32 offsetY = pixelateSize / 2;

                    // make sure that the offset is within the boundry of the image
                    while (xx + offsetX >= imageBitmap.Width) offsetX--;
                    while (yy + offsetY >= imageBitmap.Height) offsetY--;

                    // get the pixel color in the center of the soon to be pixelated area
                    Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

                    // for each pixel in the pixelate size, set it to the center color
                    for (Int32 x = xx; x < xx + pixelateSize && x < imageBitmap.Width; x++)
                        for (Int32 y = yy; y < yy + pixelateSize && y < imageBitmap.Height; y++)
                            pixelated.SetPixel(x, y, pixel);
                }


            }
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
