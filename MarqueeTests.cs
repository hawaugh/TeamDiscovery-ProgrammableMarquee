using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vision.Tests
{
    [TestClass()]
    public class MarqueeTests
    {
        [TestMethod()]
        public void MarqueeTest()
        {
            Marquee m = new Marquee();

            Assert.IsNotNull(m);
        }

        [TestMethod()]
        public void SetDotTest()
        {
            Marquee m = new Marquee();
            m.setDot(1, 1,Color.Red);
            Color c = m.getDotFore(1, 1);
            Assert.AreEqual(c,Color.Red);
        }

        [TestMethod()]
        public void getDotForeTest()
        {
            Marquee m = new Marquee();
            m.setDot(1, 1, Color.Red);
            Color c = m.getDotFore(1, 1);
            Assert.AreEqual(c, Color.Red);
        }

        [TestMethod()]
        public void clearMarqueeTest()
        {
            Marquee m = new Marquee();
            m.clearMarquee(Color.Black);
            Color c = m.getDotFore(1, 1);
            Assert.AreEqual(c, Color.Black);
        }

        [TestMethod()]
        public void displayMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displaySegmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayStaticEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displaySplitEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayUpEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayDownEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayUpsideDownEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displaySidewayEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayRandomEntranceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayScrollingSegmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayRandomColorsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayFadeEffectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayWaveEffectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displaySpotlightEffectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displaySplitExitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayUpExitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayDownExitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayUpsideDownExitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displaySidewayExitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayRandomExitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void borderThreadAbortTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void borderThreadSuspendTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void borderThreadResumeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void clearBorderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayBorderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void noBorderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void staticBorderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayBorderHighlightTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayRandomColorBorderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayRandomShootingBorderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void displayImageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void randomColorTest()
        {

            Dot d = new Dot();


            Color[] colorArray = new Color[31];
            colorArray[0] = Color.Aqua;
            colorArray[1] = Color.Blue;
            colorArray[2] = Color.BlueViolet;
            colorArray[3] = Color.Cyan;
            colorArray[4] = Color.Fuchsia;
            colorArray[5] = Color.DeepPink;
            colorArray[6] = Color.Gold;
            colorArray[7] = Color.GreenYellow;
            colorArray[8] = Color.HotPink;
            colorArray[9] = Color.LightCoral;
            colorArray[10] = Color.Lime;
            colorArray[11] = Color.MediumSpringGreen;
            colorArray[12] = Color.Navy;
            colorArray[13] = Color.OrangeRed;
            colorArray[14] = Color.Purple;
            colorArray[15] = Color.Red;
            colorArray[16] = Color.Snow;
            colorArray[17] = Color.SpringGreen;
            colorArray[18] = Color.Turquoise;
            colorArray[19] = Color.Violet;
            colorArray[20] = Color.Yellow;
            colorArray[21] = Color.Aquamarine;
            colorArray[22] = Color.Maroon;
            colorArray[23] = Color.MediumOrchid;
            colorArray[24] = Color.MediumSeaGreen;
            colorArray[25] = Color.OliveDrab;
            colorArray[26] = Color.Firebrick;
            colorArray[27] = Color.Crimson;
            colorArray[28] = Color.Magenta;
            colorArray[29] = Color.LightPink;
            colorArray[30] = Color.DarkRed;

            d.randColor();
            Color c = d.ForeColor;
            Assert.IsTrue(colorArray.Contains(c));

            d.randColor();
            Color c2 = d.ForeColor;
            Assert.IsTrue(colorArray.Contains(c2));

            Assert.AreNotEqual(c, c2);
        }
    }
}