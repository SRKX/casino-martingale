using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteOOLib;

namespace RouletteOOTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NumberTest()
        {
            Number zero = new Number(0);
            Assert.AreEqual(NumberColor.None, zero.Color);
            Number one = new Number(1);
            Assert.AreEqual(NumberColor.Red, one.Color);
            Number two = new Number(2);
            Assert.AreEqual(NumberColor.Black, two.Color);
        }
    }
}
