using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Vision.Test
{
    [TestClass()]
    public class MessageTests
    {

        [TestMethod()]
        public static void MessageTest()

        {

            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.IsNotNull(msg);
        }

        [TestMethod()]
        public void TestGetSegmentArrayTest()
        {
            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.AreEqual(newSegmentArray.Length, msg.getSegmentArray().Length);
        }
        [TestMethod()]
        public void TestBackgroundColor()
        {
            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.AreEqual(msg.backgroundColor, Color.Black);

            msg.backgroundColor = Color.Red;

            Assert.AreEqual(msg.backgroundColor, Color.Red);
        }

        [TestMethod()]
        public void TestBorderColor()
        {
            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.AreEqual(msg.borderColor, Color.Red);

            msg.borderColor = Color.Black;

            Assert.AreEqual(msg.borderColor, Color.Black);

        }

        [TestMethod()]
        public void TestBorderEffect()
        {
            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.AreEqual(msg.borderEffect, 1);

            msg.borderEffect = 2;

            Assert.AreEqual(msg.borderEffect, 2);

        }

        [TestMethod()]
        public void TestScrollSpeed()
        {
            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.AreEqual(msg.scrollSpeed, 50);

            msg.scrollSpeed = 51;

            Assert.AreEqual(msg.scrollSpeed, 51);

        }

        [TestMethod()]
        public void TestSegmentSpeed()
        {
            Segment[] newSegmentArray = new Segment[5];

            Message msg = new Message(newSegmentArray, Color.Black, Color.Red, 1, 50, 50);

            Assert.AreEqual(msg.segmentSpeed, 50);

            msg.segmentSpeed = 51;

            Assert.AreEqual(msg.segmentSpeed, 51);

        }


    }
}