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
    //Have to make Message a public class in order to use it in XmlSerializer
    public class Message
    {
        private Segment[] segmentArray;  //Contains one segment for non subsegmented message
        private Color _backgroundColor;
        
        // Parameterless constructor needed for serialization
        public Message()
        {
            
        }

        //Constructor
        public Message(Segment[] newSegmentArray, Color backgroundColor)
        {
            
            segmentArray =  newSegmentArray;
            _backgroundColor = backgroundColor;
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
    }
}
