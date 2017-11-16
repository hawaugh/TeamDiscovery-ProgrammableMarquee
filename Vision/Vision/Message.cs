/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: Message.cs
// Description: 
//
// Name: Logan
// Last Edit: 11/6
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vision
{
    class Message
    {
        private Segment[] segmentArray;  //Contains one segment for non subsegmented message
        private Color _backgroundColor;
        private Color _borderColor;
        private int _borderEffect;
        private int _segmentSpeed;    

        //Constructor
        public Message(Segment[] newSegmentArray, Color backgroundColor, Color borderColor, int borderEffect, int segmentSpeed)
        {
            segmentArray = newSegmentArray;
            _backgroundColor = backgroundColor;
            _borderColor = borderColor;
            _borderEffect = borderEffect;
            _segmentSpeed = segmentSpeed;
        }

        public Segment[] getSegmentArray()
        {
            return segmentArray;
        }

        //getter/setter for backgroundColor
        public Color backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        //getter/setter for borderColor
        public Color borderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        //getter/setter for borderEffect
        public int borderEffect
        {
            get { return _borderEffect; }
            set { _borderEffect = value; }
        }

        //getter/setter for segmentSpeed
        public int segmentSpeed
        {
            get { return _segmentSpeed; }
            set { _segmentSpeed = value; }
        }
    }
}
