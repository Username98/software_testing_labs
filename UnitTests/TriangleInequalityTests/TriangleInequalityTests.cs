using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleInequalityTests
{
    [TestClass]
    public class TriangleInequalityTests
    {
        [TestMethod]
        public void AllSidesAreEqual_TrueReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();

            Assert.AreEqual(true, t.TriangleInequality(5, 5, 5));
        }
        [TestMethod]
        public void MinSidesDifference_TrueReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 5;
            double b = 5;
            double c = 9.99999999;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = true;
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void MinSidesDifference_FalseReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 4.99999999;
            double b = 5;
            double c = 10;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ZeroLengthSides_FalseReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 4.99999999;
            double b = 5;
            double c = 0;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NegativeLengthSides_FalseReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 4.99999999;
            double b = -5;
            double c = 10;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecimalLengthSides_TrueReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 4.99999999;
            double b = 0b1010;
            double c = 10;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void HexLengthSides_TrueReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 4.99999999;
            double b = 0b1010;
            double c = 0xd;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MoreThanMaxDoubleLengthSides_FalseReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = double.MaxValue+100;
            double b = double.MaxValue;
            double c = double.MaxValue;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LessThanMinLengthSides_falseReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = double.MinValue;
            double b = double.MinValue;
            double c = double.MinValue;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NaNSides_FalseReturned()
        {
            TriangleInequality.Triangle t = new TriangleInequality.Triangle();
            double a = 4.99999999;
            double b = double.NaN;
            double c = double.NaN;
            bool actual = t.TriangleInequality(a, b, c);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

    }
}
