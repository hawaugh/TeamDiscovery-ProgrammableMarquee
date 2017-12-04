/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Segment.cs
// Description: 
//
// Name: Logan
// Last Edit: 11/2
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    public class Segment
    {
        private string _messageText;
        private string[] messageMatrix = new string[12];
        private Color _onColor;

        private bool _isImage;
        private Bitmap _scaledBitmap;
        private float _imageAspect;
        private const float ASPECT_RATIO = 6;

        private int _entranceEffect;        
        private int _middleEffect;        
        private int _exitEffect;
        
        //Default Constructor
        public Segment()
        {
            _messageText = "";
            _onColor = Color.Black;
            _isImage = false;
            _entranceEffect = 0;
            _middleEffect = 0;
            _exitEffect = 0;
        }

        //Text Constructor
        public Segment(string segmentText, Color onColor, int entranceEffect, int middleEffect, int exitEffect)
        {
            _messageText = segmentText;
            setMessageMatrix(_messageText);
            _onColor = onColor;
            _entranceEffect = entranceEffect;
            _middleEffect = middleEffect;
            _exitEffect = exitEffect;
            _isImage = false;
        }

        //Image Constructor
        public Segment(string filename)
        {
            _isImage = true;
            //creates the image from file
            Bitmap imageBitmap = new Bitmap(filename);
            _imageAspect = ((float)imageBitmap.Width) / ((float)imageBitmap.Height);

            if (_imageAspect < ASPECT_RATIO)  //Scaled if ratio taller than marquee
            {
                _scaledBitmap = new Bitmap(imageBitmap, (int)Math.Round(16 * _imageAspect), 16);
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

        

        /*
         * 
         *   Text Segment
         * 
         */
        #region Text Segment
        public string messageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                setMessageMatrix(_messageText);
            }
        }

        public String[] getMessageMatrix()
        {
            return messageMatrix; 
        }

        public void setMessageMatrix(string messageText)
        {
            messageMatrix = new String[12];
            string[] currentLetter;
            foreach (char c in messageText)
            {
                currentLetter = characterBuild(c);
                for (int i = 0; i < 12; i++)
                {
                    messageMatrix[i] = messageMatrix[i] + currentLetter[i] + "0";
                }
            }
        }

        //getter/setter for onColor
        public Color onColor
        {
            get { return _onColor; }
            set { _onColor = value; }
        }
        #endregion

        /*
         * 
         *   Image Segment
         * 
         */
        #region Image Segment

        public bool isImage
        {
            get { return _isImage; }
            set { _isImage = value; }
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
            set { }
        }

        //getter/setter for scaledBitmap
        public Bitmap scaledBitmap
        {
            get { return _scaledBitmap; }
            set { }
        }

        #endregion

        /*
         * 
         *   Effect Options
         * 
         */
        #region Effect Options
        //getter/setter for entranceEffect
        public int entranceEffect
        {
            get { return _entranceEffect; }
            set { _entranceEffect = value; }
        }

        //getter/setter for middleEffect
        public int middleEffect
        {
            get { return _middleEffect; }
            set { _middleEffect = value; }
        }

        //getter/setter for exitEffect
        public int exitEffect
        {
            get { return _exitEffect; }
            set { _exitEffect = value; }
        }
        #endregion

        /*
         * 
         *   Character Build Library
         * 
         */
        #region Character Build Library
        //Contains the library of character builds
        public string[] characterBuild(char character)
        {
            string[] returnString;

            switch (character)
            {
                case ' ':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '!':
                    returnString = new string[] {   "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000000000",
                                                    "000000000",
                                                    "000111000",
                                                    "000111000"};
                    break;
                case '"':
                    returnString = new string[] {   "000000000",
                                                    "001101100",
                                                    "001101100",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '#':
                    returnString = new string[] {   "000000000",
                                                    "001101100",
                                                    "001101100",
                                                    "011111110",
                                                    "011111110",
                                                    "001101100",
                                                    "001101100",
                                                    "011111110",
                                                    "011111110",
                                                    "001101100",
                                                    "001101100",
                                                    "000000000"};
                    break;
                case '$':
                    returnString = new string[] {   "000010000",
                                                    "001111100",
                                                    "011010110",
                                                    "001110000",
                                                    "000110000",
                                                    "000010000",
                                                    "000010000",
                                                    "000011000",
                                                    "000011100",
                                                    "011010110",
                                                    "001111100",
                                                    "000010000"};
                    break;
                case '%':
                    returnString = new string[] {   "000000100",
                                                    "000000100",
                                                    "001101000",
                                                    "010011000",
                                                    "001101000",
                                                    "000001000",
                                                    "000010000",
                                                    "000011100",
                                                    "000110010",
                                                    "000101100",
                                                    "001000000",
                                                    "001000000"};
                    break;
                case '&':
                    returnString = new string[] {   "000111000",
                                                    "001101100",
                                                    "011000110",
                                                    "011000110",
                                                    "001101100",
                                                    "000111011",
                                                    "001101110",
                                                    "011000110",
                                                    "110000011",
                                                    "011000110",
                                                    "001101100",
                                                    "000111000"};
                    break;
                case '\'':
                    returnString = new string[] {   "000000000",
                                                    "000110000",
                                                    "000110000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '(':
                    returnString = new string[] {   "000000100",
                                                    "000001100",
                                                    "000011000",
                                                    "000110000",
                                                    "000110000",
                                                    "001100000",
                                                    "001100000",
                                                    "000110000",
                                                    "000110000",
                                                    "000011000",
                                                    "000001100",
                                                    "000000100"};
                    break;
                case ')':
                    returnString = new string[] {   "010000000",
                                                    "011000000",
                                                    "001100000",
                                                    "000110000",
                                                    "000110000",
                                                    "000011000",
                                                    "000011000",
                                                    "000110000",
                                                    "000110000",
                                                    "001100000",
                                                    "011000000",
                                                    "010000000"};
                    break;
                case '*':
                    returnString = new string[] {   "000000000",
                                                    "001010100",
                                                    "001010100",
                                                    "000111000",
                                                    "001010100",
                                                    "001010100",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '+':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "011111110",
                                                    "011111110",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case ',':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "001111000",
                                                    "001100000",
                                                    "000000000"};
                    break;
                case '-':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "011111110",
                                                    "011111110",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '.':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "011000000",
                                                    "011000000",
                                                    "000000000"};
                    break;
                case '/':
                    returnString = new string[] {   "000000111",
                                                    "000001110",
                                                    "000001110",
                                                    "000011100",
                                                    "000011100",
                                                    "000111000",
                                                    "000111000",
                                                    "001110000",
                                                    "001110000",
                                                    "011100000",
                                                    "011100000",
                                                    "111000000"};
                    break;
                case '0':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "111001110",
                                                    "111000111",
                                                    "110000011",
                                                    "110000011",
                                                    "110000111",
                                                    "011101110",
                                                    "001111100",
                                                    "000111000",
                                                    "000111000"};
                    break;
                case '1':
                    returnString = new string[] {   "000111000",
                                                    "001111000",
                                                    "011111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "111111111",
                                                    "111111111"};
                    break;
                case '2':
                    returnString = new string[] {   "000011000",
                                                    "000111100",
                                                    "001111110",
                                                    "011100111",
                                                    "111000111",
                                                    "000001110",
                                                    "000001110",
                                                    "000011100",
                                                    "000111000",
                                                    "001110000",
                                                    "111111111",
                                                    "111111111"};
                    break;
                case '3':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "111100111",
                                                    "111000111",
                                                    "000001110",
                                                    "000001110",
                                                    "111000111",
                                                    "111100111",
                                                    "011100110",
                                                    "000111100",
                                                    "000011000"};
                    break;
                case '4':
                    returnString = new string[] {   "110000011",
                                                    "110000011",
                                                    "110000011",
                                                    "110000011",
                                                    "110000011",
                                                    "110000011",
                                                    "111111111",
                                                    "111111111",
                                                    "000000011",
                                                    "000000011",
                                                    "000000011",
                                                    "000000011"};
                    break;
                case '5':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "111100000",
                                                    "111100000",
                                                    "111111100",
                                                    "000011110",
                                                    "000000111",
                                                    "000000011",
                                                    "000000011",
                                                    "000000111",
                                                    "111111110",
                                                    "011111100"};
                    break;
                case '6':
                    returnString = new string[] {   "001111000",
                                                    "011111110",
                                                    "011000011",
                                                    "110000000",
                                                    "111000000",
                                                    "111111110",
                                                    "111000111",
                                                    "110000011",
                                                    "110000011",
                                                    "011000110",
                                                    "001111110",
                                                    "000011100"};
                    break;
                case '7':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "000000111",
                                                    "000001110",
                                                    "000001110",
                                                    "000011100",
                                                    "000111000",
                                                    "000111000",
                                                    "001110000",
                                                    "011100000",
                                                    "011100000",
                                                    "111000000"};
                    break;
                case '8':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "111000111",
                                                    "011101110",
                                                    "001111100",
                                                    "001111100",
                                                    "011101110",
                                                    "111000111",
                                                    "011101110",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case '9':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "111000111",
                                                    "111000111",
                                                    "011101110",
                                                    "001111110",
                                                    "000000110",
                                                    "000000110",
                                                    "011100110",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case ':':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case ';':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000",
                                                    "000110000",
                                                    "000000000"};
                    break;
                case '<':
                    returnString = new string[] {   "000001110",
                                                    "000011100",
                                                    "000111000",
                                                    "001110000",
                                                    "011100000",
                                                    "111000000",
                                                    "111000000",
                                                    "011100000",
                                                    "001110000",
                                                    "000111000",
                                                    "000011100",
                                                    "000001110"};
                    break;
                case '=':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111111111",
                                                    "111111111",
                                                    "000000000",
                                                    "000000000",
                                                    "111111111",
                                                    "111111111",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '>':
                    returnString = new string[] {   "011100000",
                                                    "001110000",
                                                    "000111000",
                                                    "000011100",
                                                    "000001110",
                                                    "000000111",
                                                    "000000111",
                                                    "000001110",
                                                    "000011100",
                                                    "000111000",
                                                    "001110000",
                                                    "011100000"};
                    break;
                case '?':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "111000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000001110",
                                                    "000001100",
                                                    "000011000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000"};
                    break;
                case '@':
                    returnString = new string[] {   "000000000",
                                                    "001111100",
                                                    "011000110",
                                                    "100000001",
                                                    "100010001",
                                                    "100101001",
                                                    "100101001",
                                                    "100101001",
                                                    "100011111",
                                                    "010000110",
                                                    "001111100",
                                                    "000000000"};
                    break;
                case 'A':
                    returnString = new string[] {   "000111000",
                                                    "000111000",
                                                    "001111100",
                                                    "001111100",
                                                    "011101110",
                                                    "011101110",
                                                    "011111110",
                                                    "011111110",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111"};
                    break;
                case 'B':
                    returnString = new string[] {   "111111000",
                                                    "111111100",
                                                    "111001110",
                                                    "111000111",
                                                    "111001110",
                                                    "111111100",
                                                    "111111100",
                                                    "111001110",
                                                    "111000111",
                                                    "111001110",
                                                    "111111100",
                                                    "111111100"};
                    break;
                case 'C':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "011100111",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "011100111",
                                                    "011101110",
                                                    "001111100",
                                                    "000111000" };
                    break;
                case 'D':
                    returnString = new string[] {   "111111000",
                                                    "111111100",
                                                    "111001110",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111001110",
                                                    "111111100",
                                                    "111111000"};
                    break;
                case 'E':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111111100",
                                                    "111111100",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111111111",
                                                    "111111111"};
                    break;
                case 'F':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111111110",
                                                    "111111110",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000"};
                    break;
                case 'G':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "011100111",
                                                    "111000000",
                                                    "111000000",
                                                    "111011111",
                                                    "111011111",
                                                    "011100111",
                                                    "011101110",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case 'H':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111111111",
                                                    "111111111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111"};
                    break;
                case 'I':
                    returnString = new string[] {   "011111110",
                                                    "011111110",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "011111110",
                                                    "011111110"};
                    break;
                case 'J':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "000011100",
                                                    "000011100",
                                                    "000011100",
                                                    "000011100",
                                                    "000011100",
                                                    "000011100",
                                                    "111011100",
                                                    "111011100",
                                                    "011111100",
                                                    "001111000"};
                    break;
                case 'K':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "111001110",
                                                    "111001110",
                                                    "111011110",
                                                    "111111100",
                                                    "111111100",
                                                    "111011110",
                                                    "111001110",
                                                    "111001110",
                                                    "111000111",
                                                    "111000111"};
                    break;
                case 'L':
                    returnString = new string[] {   "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111111111",
                                                    "111111111"};
                    break;
                case 'M':
                    returnString = new string[] {   "001101100",
                                                    "011111110",
                                                    "111111111",
                                                    "111010111",
                                                    "111010111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111"};
                    break;
                case 'N':
                    returnString = new string[] {   "111000111",
                                                    "111100111",
                                                    "111100111",
                                                    "111100111",
                                                    "111110111",
                                                    "111111111",
                                                    "111111111",
                                                    "111011111",
                                                    "111001111",
                                                    "111001111",
                                                    "111001111",
                                                    "111000111"};
                    break;
                case 'O':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "011101110",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "011101110",
                                                    "011101110",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case 'P':
                    returnString = new string[] {   "111111000",
                                                    "111111100",
                                                    "111001110",
                                                    "111000111",
                                                    "111000111",
                                                    "111001110",
                                                    "111111100",
                                                    "111111000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000"};
                    break;
                case 'Q':
                    returnString = new string[] {   "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "011101110",
                                                    "111000111",
                                                    "111000111",
                                                    "111010111",
                                                    "111011111",
                                                    "011101110",
                                                    "011101111",
                                                    "001111111",
                                                    "000111001"};
                    break;
                case 'R':
                    returnString = new string[] {   "111111000",
                                                    "111111100",
                                                    "111001110",
                                                    "111000111",
                                                    "111000111",
                                                    "111001110",
                                                    "111111100",
                                                    "111111000",
                                                    "111111000",
                                                    "111011100",
                                                    "111001110",
                                                    "111000111"};
                    break;
                case 'S':
                    returnString = new string[] {   "001111000",
                                                    "011101110",
                                                    "111000111",
                                                    "011100000",
                                                    "001110000",
                                                    "000111000",
                                                    "000011000",
                                                    "000011100",
                                                    "000001110",
                                                    "111000111",
                                                    "011101110",
                                                    "001111100"};
                    break;
                case 'T':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000"};
                    break;
                case 'U':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "011111110",
                                                    "001111100"};
                    break;
                case 'V':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "011101110",
                                                    "011101110",
                                                    "011101110",
                                                    "001111100",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case 'W':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111000111",
                                                    "111010111",
                                                    "111010111",
                                                    "111111111",
                                                    "111111111",
                                                    "011101110"};
                    break;
                case 'X':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "011101110",
                                                    "011101110",
                                                    "001111100",
                                                    "001111100",
                                                    "001111100",
                                                    "001111100",
                                                    "011101110",
                                                    "011101110",
                                                    "111000111",
                                                    "111000111"};
                    break;
                case 'Y':
                    returnString = new string[] {   "111000111",
                                                    "111000111",
                                                    "011101110",
                                                    "011101110",
                                                    "001111100",
                                                    "001111100",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000"};
                    break;
                case 'Z':
                    returnString = new string[] {   "111111111",
                                                    "111111111",
                                                    "000000110",
                                                    "000000110",
                                                    "000001100",
                                                    "000011000",
                                                    "000110000",
                                                    "001100000",
                                                    "011000000",
                                                    "011000000",
                                                    "111111111",
                                                    "111111111"};
                    break;
                case '[':
                    returnString = new string[] {   "111111000",
                                                    "111111000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111000000",
                                                    "111111000",
                                                    "111111000"};
                    break;
                case '\\':
                    returnString = new string[] {   "111000000",
                                                    "011100000",
                                                    "011100000",
                                                    "001110000",
                                                    "001110000",
                                                    "000111000",
                                                    "000111000",
                                                    "000011100",
                                                    "000011100",
                                                    "000001110",
                                                    "000001110",
                                                    "000000111"};
                    break;
                case ']':
                    returnString = new string[] {   "000111111",
                                                    "000111111",
                                                    "000000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000000111",
                                                    "000111111",
                                                    "000111111"};
                    break;
                case '^':
                    returnString = new string[] {   "000010000",
                                                    "000111000",
                                                    "001111100",
                                                    "011101110",
                                                    "011101110",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '_':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111111111"};
                    break;
                case '`':
                    returnString = new string[] {   "000000000",
                                                    "001110000",
                                                    "000111000",
                                                    "000011100",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case '{':
                    returnString = new string[] {   "000001110",
                                                    "000011100",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "011110000",
                                                    "011110000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000011100",
                                                    "000001110"};
                    break;
                case '|':
                    
                    //I know this character is going to be used as a line break
                    //But i included it in case there's any use for it
                    returnString = new string[] {   "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000"};
                    break;
                case '}':
                    returnString = new string[] {   "011100000",
                                                    "001110000",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "000011110",
                                                    "000011110",
                                                    "000111000",
                                                    "000111000",
                                                    "000111000",
                                                    "001110000",
                                                    "011100000"};
                    break;
                case '~':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "001100011",
                                                    "010110100",
                                                    "100011000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000"};
                    break;
                case 'a':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "011111110",
                                                    "011111110",
                                                    "000000011",
                                                    "011111111",
                                                    "111111111",
                                                    "110000011",
                                                    "111111111",
                                                    "011111111"};
                    break;
                case 'b':
                    returnString = new string[] {   "000000000",
                                                    "111000000",
                                                    "011000000",
                                                    "011000000",
                                                    "011000000",
                                                    "011111110",
                                                    "011111111",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "011111111",
                                                    "111111110"};
                    break;
                case 'c':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "011111110",
                                                    "111111111",
                                                    "110000011",
                                                    "110000000",
                                                    "110000000",
                                                    "110000011",
                                                    "111111111",
                                                    "011111110"};
                    break;
                case 'd':
                    returnString = new string[] {   "000000000",
                                                    "000000111",
                                                    "000000011",
                                                    "000000011",
                                                    "000000011",
                                                    "011111111",
                                                    "111111111",
                                                    "110000011",
                                                    "110000011",
                                                    "110000011",
                                                    "111111111",
                                                    "011111111"};
                    break;
                case 'e':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "011111110",
                                                    "111111111",
                                                    "110000011",
                                                    "111111111",
                                                    "111111111",
                                                    "110000000",
                                                    "111111111",
                                                    "011111110"};
                    break;
                case 'f':
                    returnString = new string[] {   "000000000",
                                                    "000011110",
                                                    "000111110",
                                                    "000110000",
                                                    "000110000",
                                                    "011111100",
                                                    "011111100",
                                                    "000110000",
                                                    "000110000",
                                                    "000110000",
                                                    "000110000",
                                                    "001110000"};
                    break;
                case 'g':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "011111111",
                                                    "111111111",
                                                    "110000011",
                                                    "111111111",
                                                    "011111111",
                                                    "000000011",
                                                    "111111111",
                                                    "011111110"};
                    break;
                case 'h':
                    returnString = new string[] {   "000000000",
                                                    "111000000",
                                                    "011000000",
                                                    "011000000",
                                                    "011000000",
                                                    "011000000",
                                                    "011111110",
                                                    "011111111",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "111000011"};
                    break;
                case 'i':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000",
                                                    "000000000",
                                                    "000111000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000111000"};
                    break;
                case 'j':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000001100",
                                                    "000001100",
                                                    "000000000",
                                                    "000011100",
                                                    "000001100",
                                                    "000001100",
                                                    "000001100",
                                                    "001101100",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case 'k':
                    returnString = new string[] {   "0000000000",
                                                    "0111000000",
                                                    "0011000000",
                                                    "0011000110",
                                                    "0011001100",
                                                    "0011011000",
                                                    "0011110000",
                                                    "0011100000",
                                                    "0011110000",
                                                    "0011011000",
                                                    "0011001100",
                                                    "0111000110",};
                    break;
                case 'l':
                    returnString = new string[] {   "000000000",
                                                    "000111000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000111000"};
                    break;
                case 'm':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111111110",
                                                    "011111111",
                                                    "011011011",
                                                    "011011011",
                                                    "011011011",
                                                    "011011011",
                                                    "011011011",
                                                    "111011011"};
                    break;
                case 'n':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111000000",
                                                    "011111110",
                                                    "011111111",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "111000011"};
                    break;
                case 'o':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000111000",
                                                    "001111100",
                                                    "011000110",
                                                    "110000011",
                                                    "110000011",
                                                    "011000110",
                                                    "001111100",
                                                    "000111000"};
                    break;
                case 'p':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111111100",
                                                    "011111110",
                                                    "011000111",
                                                    "011111110",
                                                    "011111100",
                                                    "011000000",
                                                    "011000000",
                                                    "111000000"};
                    break;
                case 'q':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "001111111",
                                                    "011111110",
                                                    "110000110",
                                                    "011111110",
                                                    "001111110",
                                                    "000000110",
                                                    "000000110",
                                                    "000000111"};
                    break;
                case 'r':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111011100",
                                                    "011111110",
                                                    "011100110",
                                                    "011000000",
                                                    "011000000",
                                                    "011000000",
                                                    "011000000",
                                                    "111000000"};
                    break;
                case 's':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000111110",
                                                    "001111111",
                                                    "011000000",
                                                    "111111110",
                                                    "001111111",
                                                    "000000110",
                                                    "111111100",
                                                    "011111000"};
                    break;
                case 't':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000011000",
                                                    "000011000",
                                                    "001111110",
                                                    "001111110",
                                                    "000011000",
                                                    "000011000",
                                                    "000011000",
                                                    "000011110",
                                                    "000001110"};
                    break;
                case 'u':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111000111",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "011111111",
                                                    "001111111"};
                    break;
                case 'v':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111000111",
                                                    "011000011",
                                                    "011000011",
                                                    "011000011",
                                                    "001100110",
                                                    "001100110",
                                                    "000111100",
                                                    "000011000"};
                    break;
                case 'w':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111000111",
                                                    "011000011",
                                                    "011000011",
                                                    "011011011",
                                                    "011111111",
                                                    "011100111",
                                                    "011100111",
                                                    "111000011"};
                    break;
                case 'x':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111000111",
                                                    "011000110",
                                                    "001101100",
                                                    "000111000",
                                                    "000111000",
                                                    "001101100",
                                                    "011000110",
                                                    "111000111"};
                    break;
                case 'y':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111000011",
                                                    "001100110",
                                                    "000111100",
                                                    "000011000",
                                                    "000110000",
                                                    "001100000",
                                                    "011000000",
                                                    "110000000"};
                    break;
                case 'z':
                    returnString = new string[] {   "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "000000000",
                                                    "111111111",
                                                    "011111111",
                                                    "000001110",
                                                    "000011000",
                                                    "000110000",
                                                    "011100000",
                                                    "111111110",
                                                    "111111111"};
                    break;
                default:
                    returnString = new string[12];
                    break;
            }
            return returnString;
        }
        #endregion
    }
}
