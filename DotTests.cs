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
            Color _ForeColor;
            _ForeColor = Color.DarkGray;
            Assert.AreEqual(_ForeColor, Color.DarkGray);
        }

        [TestMethod()]
        public void randColorTest()
        {
            Assert.Fail();
        }
    }
}