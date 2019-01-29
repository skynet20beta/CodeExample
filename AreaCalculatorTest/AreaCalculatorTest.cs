using System;
using AreaCalculator;
using NUnit.Framework;

namespace AreaCalculatorTest
{
    [TestFixture]
    public class AreaCalculatorTest
    {
        private const double DELTA = 1e-6;

        [Test]
        public void CircleWithNegativeRadius()
        {
            Assert.Throws(typeof(InvalidShapeException), () => new Circle(-1.5));
        }

        [Test]
        public void TriangleWithNegativeSide()
        {
            Assert.Throws(typeof(InvalidShapeException), () => new Triangle(-1.5, 2.0, 3.0));
        }

        [Test]
        public void TriangleWithInequalityViolated()
        {
            Assert.Throws(typeof(InvalidShapeException), () => new Triangle(1.5, 2.0, 13.0));
        }

        [Test]
        public void CircleIsOk()
        {
            var shape = new Circle(3);
            var expectedArea = Math.PI * 3 * 3;
            Assert.AreEqual(shape.Area, expectedArea, DELTA);
        }

        [Test]
        //no additinal test required since there are no special cases in implementation of triangle area
        public void TriangleIsOk()
        {
            var shape = new Triangle(3, 4, 5);
            Assert.AreEqual(shape.Area, 6.0, DELTA);
        }
    }
}
