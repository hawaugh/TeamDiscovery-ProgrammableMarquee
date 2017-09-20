using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    class Message
    {
        private string messageContent;
        private Segment[] segmentArray;  //Contains one segment for non subsegmented message
        private string backgroundColor;
        private string borderColor;
        private double dotRadius;
        private double deadSpace;
        private int specialEffect; //Numbers 0-5, each corresponding to a special effect (0 being static message)


        //Constructor
        public Message()
        {

        }

        public string getMessageContent()
        {

        }

        //Calls compileMessageMatrix to create the new matrix each time message is changed
        public void setMessageContent(string newMessageContent)
        {
            compileMessageMatrix(newMessageContent);
        }

        public void compileMessageMatrix(string messageContent)
        {

        }

        public string getBackgroundColor()
        {

        }

        public void setBackgroundColor(string newBackgroundColor)
        {

        }

        public string getBorderColor()
        {

        }

        public void setBorderColor(string newBorderColor)
        {

        }

        public double getDotRadius()
        {

        }

        public void setDotRadius(double newDotRadius)
        {

        }

        public double getDeadSpace()
        {

        }

        public void setDeadSpace(double newDeadSpace)
        {

        }
    }
}
