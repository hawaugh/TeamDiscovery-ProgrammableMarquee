using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    class Message
    {
        private string _messageContent;
        private Segment[] segmentArray;  //Contains one segment for non subsegmented message
        private string _backgroundColor;
        private string _borderColor;
        private double _dotRadius;
        private double _deadSpace;
        private int _specialEffect; 
        /*
         * Special Effect int values:
         * 0: static message
         * 1: scrolling message
         * 2: subsegment message
         * 3: upper/lower split
         * 4: random color message
         * 5: up/down disappear message
         * 6: border Highlight message
        */


        //Constructor
        public Message(string messageContent, string backgroundColor, string borderColor, double dotRadius, double deadSpace, int specialEffect)
        {
            _messageContent = messageContent;
            _backgroundColor = backgroundColor;
            _borderColor = borderColor;
            _dotRadius = dotRadius;
            _deadSpace = deadSpace;
            _specialEffect = specialEffect;
            //set the matrix
            compileMessageMatrix(_messageContent);            
        }

        //Calls compileMessageMatrix to create the new matrix each time message is changed
        public string messageContent
        {
            get { return _messageContent; }
            set
            {
                _messageContent = value;
                compileMessageMatrix(_messageContent);
            }
        }

        //Builds the segmentArray to hold matrix information about message
        public void compileMessageMatrix(string messageContent)
        {
            if (_specialEffect == 2)
            {
                //process message for '|' and create seperate segments accordingly
            }
            else
            {
                segmentArray = new Segment[] { new Segment(messageContent) };
            }
        }

        //getter/setter for backgroundColor
        public string backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        //getter/setter for borderColor
        public string borderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        //getter/setter for dotRadius
        public double dotRadius
        {
            get { return _dotRadius; }
            set { _dotRadius = value; }
        }

        //getter/setter for deadSpace
        public double deadSpace
        {
            get { return _deadSpace; }
            set { _deadSpace = value; }
        }

        //getter/setter for specialEffect, also recompiles message matrix
        public int specialEffect
        {
            get { return _specialEffect; }
            set
            {
                _specialEffect = value;
                compileMessageMatrix(_messageContent);
            }
        }
    }
}
