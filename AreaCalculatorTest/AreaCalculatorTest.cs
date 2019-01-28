using System;
using AreaCalculator;
using NUnit.Framework;

namespace AreaCalculatorTest
{
    [TestFixture]
    public class AreaCalculatorTest
    {
        private static void AssertShapeIsInvalid(IShapeWithArea shape)
        {
            Assert.Throws(typeof(InvalidShapeException), () => shape.GetArea());
        }

        [Test]
        //circle with negative radius
        public void InvalidCircle()
        {
            var shape = new Circle(-1.5);
            AssertShapeIsInvalid(shape);
        }

        [Test]
        public void TriangleWithNegativeSide()
        {
            var shape = new Triangle(-1.5, 2.0, 3.0);
            AssertShapeIsInvalid(shape);
        }

        [Test]
        public void TriangleWithInequalityViolated()
        {
            var shape = new Triangle(1.5, 2.0, 13.0);
            AssertShapeIsInvalid(shape);
        }

        [Test]
        public void CircleIsOk()
        {
            var shape = new Circle(3);
            var expectedArea = Math.PI * 3 * 3;
            Assert.AreEqual(shape.GetArea(), expectedArea);
        }

        [Test]
        //no additinal test required since there are no special cases in implementation of triangle area
        public void TriangleIsOk()
        {
            var shape = new Triangle(3, 4, 5);
            Assert.AreEqual(shape.GetArea(), 6.0);
        }
    }
}
