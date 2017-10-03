using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    class Segment
    {
        private string _messageText;
        private string[] messageMatrix = new string[12];
        
        public Segment(string segmentText)
        {

        }

        //TODO: add getter/setter for _messageText

        public string[] getMessageMatrix()
        {

        }

        public void setMessageMatrix(string messageText)
        {

        }

        //Contains the library of character builds,  TODO: Fill out all supported characters; Brooks
        public string[] characterBuild(char character)
        {
            string[] returnString;

            switch (character)
            {
                case 'A':
                    returnString = new string[] {   "000001000000",
                                                    "000011100000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000",
                                                    "000000000000"};
                    break;
                case 'B':
                    returnString = new string[] { }; //ETC
                    break;
                default:
                    returnString = new string[12];
                    break;
            }
            return returnString;
        }
    }
}
