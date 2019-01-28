using System;

namespace AreaCalculator
{
    public class Triangle : BaseShapeWithArea
    {
        private readonly double _sideAB;
        private readonly double _sideBC;
        private readonly double _sideCA;
        private const string TRIANGLE_INEQUALITY_VIOLATED = "Triangle inequality is violated.";

        public Triangle(double sideAB, double sideBC, double sideCA)
        {
            _sideAB = sideAB;
            _sideBC = sideBC;
            _sideCA = sideCA;
        }

        protected override bool IsValid(ref string errorMessage)
        {
            if (_sideAB <= 0) errorMessage = ErrorHelper.ArgumentShouldBePositive("AB", _sideAB);
            else if (_sideBC <= 0) errorMessage = ErrorHelper.ArgumentShouldBePositive("BC", _sideBC);
            else if (_sideCA <= 0) errorMessage = ErrorHelper.ArgumentShouldBePositive("CA", _sideCA);
            if (_sideAB >= _sideBC + _sideCA)
                errorMessage = ErrorHelper.ArgumentShouldBePositive("BC + CA - AB", _sideBC + _sideCA - _sideAB, TRIANGLE_INEQUALITY_VIOLATED);
            if (_sideBC >= _sideCA + _sideAB)
                errorMessage = ErrorHelper.ArgumentShouldBePositive("CA + AB - BC", _sideCA + _sideAB - _sideBC, TRIANGLE_INEQUALITY_VIOLATED);
            if (_sideCA >= _sideAB + _sideBC)
                errorMessage = ErrorHelper.ArgumentShouldBePositive("AB + BC - CA", _sideAB + _sideBC - _sideCA, TRIANGLE_INEQUALITY_VIOLATED);
            return errorMessage == null;
        }

        protected override double CalculateArea()
        {
            //Heron formula is applied
            var halfPerimeter = (_sideAB + _sideBC + _sideCA) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - _sideAB) * (halfPerimeter - _sideBC) * (halfPerimeter - _sideCA));
        }
    }
}