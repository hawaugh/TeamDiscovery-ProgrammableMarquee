using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;

namespace Vision.Tests


{
    
    [TestClass()]
    public class SegmentTests
    {
        [TestMethod()]
        public void SegmentTest()
        {
            Segment s = new Segment();
            Assert.IsNotNull(s);
        }

        [TestMethod()]
        public void SegmentTest1()
        {
            Segment s = new Segment("test",Color.Black,true, 20,Color.Black,1);
            Assert.IsNotNull(s);
        }

        [TestMethod()]
        public void SegmentTest2()
        {
            Segment s = new Segment("test", Color.Black,20,20,20,20,Color.Black, 1);
            Assert.IsNotNull(s);
            
        }

        [TestMethod()]
        public void IgnoreTest()
        {
            Segment s = new Segment();
            s.ignore = true;
            Assert.IsTrue(s.ignore);
        }

        [TestMethod()]
        public void SegmentSpeed()
        {
            Segment s = new Segment();
            s.segmentSpeed = 20;
            Assert.AreEqual(s.segmentSpeed,20);
        }

        [TestMethod()]
        public void MessageText()
        {
            Segment s = new Segment();
            s.messageText = "test";
            Assert.AreEqual(s.messageText, "test");
            String[] matrix = s.getMessageMatrix();
            Assert.IsTrue(matrix.Length > 0);
        }

        [TestMethod()]
        public void OnColorTest()
        {
            Segment s = new Segment();
            s.onColor = Color.Black;
            Assert.AreEqual(s.onColor, Color.Black);
        }

        [TestMethod()]
        public void IsScrollingTest()
        {
            Segment s = new Segment();
            s.isScrolling = true;
            Assert.IsTrue(s.isScrolling);
        }

        [TestMethod()]
        public void IsRandomColorScrollingTest()
        {
            Segment s = new Segment();
            s.isRandomColorScrolling = true;
            Assert.IsTrue(s.isRandomColorScrolling);
        }

        [TestMethod()]
        public void ScrollSpeedTest()
        {
            Segment s = new Segment();
            s.scrollSpeed = 20;
            Assert.AreEqual(s.scrollSpeed, 20);
        }

        [TestMethod()]
        public void IsImageTest()
        {
            Segment s = new Segment();
            s.isImage = true;
            Assert.IsTrue(s.isImage);
            
        }

        [TestMethod()]
        public void ImageAspectTest()

        {
            Segment s = new Segment();
            s.imageAspect = 0;
            Assert.AreEqual(s.imageAspect, 0);
        }

        [TestMethod()]
        public void EntranceEffectTest()
        {
            Segment s = new Segment();
            s.entranceEffect = 1;
            Assert.AreEqual(s.entranceEffect, 1);
        }

        [TestMethod()]
        public void MiddleEffectTest()
        {
            Segment s = new Segment();
            s.middleEffect = 1;
            Assert.AreEqual(s.middleEffect,1);
        }

        [TestMethod()]
        public void ExitEffectTest()
        {
            Segment s = new Segment();
            s.exitEffect = 1;
            Assert.AreEqual(s.exitEffect, 1);
        }
        [TestMethod()]
        public void BorderEffectTest()
        {
            Segment s = new Segment();
            s.borderEffect = 1;
            Assert.AreEqual(s.borderEffect, 1);
        }
        [TestMethod()]
        public void BorderColorTest()
        {
            Segment s = new Segment();
            s.borderColor = Color.Yellow;
            Assert.AreEqual(s.borderColor, Color.Yellow);
        }
        [TestMethod()]
        public void CharacterBuildTest()
        {
            Segment s = new Segment();

            string[] letter = s.characterBuild('!');
            string [] returnString = new string[] { "000111000",
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
            CollectionAssert.AreEqual(letter, returnString);

        }

    }
}