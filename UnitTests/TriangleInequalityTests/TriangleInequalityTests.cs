using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleInequalityTests
{
    [TestClass]
    public class TriangleInequalityTests
    {
        TriangleInequality.Triangle t = new TriangleInequality.Triangle();
        [TestMethod]
        public void AllSidesAreEqual_TrueReturned()
        {
            Assert.AreEqual(true, t.TriangleInequality(5, 5, 5));
        }
        [TestMethod]
        public void MinSidesDifference_TrueReturned()
        {
            Assert.AreEqual(true, t.TriangleInequality(5, 5, 9.999999));
        }
        [TestMethod]
        public void MinSidesDifference_FalseReturned()
        {
          Assert.AreEqual(false, t.TriangleInequality(4.99999, 5, 10));
        }
        [TestMethod]
        public void ZeroLengthSides_FalseReturned()
        {
            Assert.AreEqual(false, t.TriangleInequality(4.99999, 5, 0));
        }
        [TestMethod]
        public void NegativeLengthSides_FalseReturned()
        {
            Assert.AreEqual(false, t.TriangleInequality(4.99999, -5, 10));
        }
        [TestMethod]
        public void DecimalLengthSides_TrueReturned()
        {
            Assert.AreEqual(true, t.TriangleInequality(4.99999, 0b1010,10));
        }
        [TestMethod]
        public void HexLengthSides_TrueReturned()
        {
            Assert.AreEqual(true, t.TriangleInequality(4.99999, 0b1010, 0xd));
        }
        [TestMethod]
        public void MoreThanMaxDoubleLengthSides_FalseReturned()
        {
            Assert.AreEqual(false, t.TriangleInequality(double.MaxValue+100, double.MaxValue, double.MaxValue));
        }
        [TestMethod]
        public void LessThanMinLengthSides_falseReturned()
        {
            Assert.AreEqual(false, t.TriangleInequality(double.MinValue, double.MinValue, double.MinValue));
        }
        [TestMethod]
        public void NaNSides_FalseReturned()
        {
            Assert.AreEqual(false, t.TriangleInequality(4.99999,double.NaN,double.NaN));
        }
    }
}
