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
        private Dictionary<char, CharacterBuild> characterLibrary;  //Need to populate dictionary

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
    }
}
