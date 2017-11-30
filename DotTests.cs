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
    public class DotTests
    { 
        [TestMethod()]
        public void DotTest()
        {
            Dot d = new Dot();
            Assert.AreEqual(d.ForeColor, Color.DarkGray);
        }

        [TestMethod()]
        public void randColorTest()
        {
            Dot d = new Dot();
           

            Color[] colorArray  = new Color[31];
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
    
