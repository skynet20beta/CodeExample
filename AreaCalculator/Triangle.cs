using System;

namespace AreaCalculator
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class Triangle : BaseShapeWithArea
    {
        private readonly double _sideAB;
        private readonly double _sideBC;
        private readonly double _sideCA;
        private const string TRIANGLE_INEQUALITY_VIOLATED = "Triangle inequality is violated.";

        /// <summary>
        /// Creates triangle ABC by 3 sides
        /// </summary>
        /// <param name="sideAB">side AB</param>
        /// <param name="sideBC">side BC</param>
        /// <param name="sideCA">side CA</param>
        public Triangle(double sideAB, double sideBC, double sideCA) : base(() => CheckSidesAndInequality(sideAB, sideBC, sideCA))
        {
            _sideAB = sideAB;
            _sideBC = sideBC;
            _sideCA = sideCA;
        }

        private static ValidationInfo CheckSidesAndInequality(double sideAB, double sideBC, double sideCA)
        {
            //checking sides
            if (sideAB <= 0) return new ValidationInfo {ErrorMessage = ErrorHelper.ArgumentShouldBePositive("AB", sideAB)};
            if (sideBC <= 0) return new ValidationInfo { ErrorMessage = ErrorHelper.ArgumentShouldBePositive("BC", sideBC)};
            if (sideCA <= 0) return new ValidationInfo { ErrorMessage = ErrorHelper.ArgumentShouldBePositive("CA", sideCA)};

            //checking inequality
            if (sideAB >= sideBC + sideCA)
                return new ValidationInfo { ErrorMessage = ErrorHelper.ArgumentShouldBePositive("BC + CA - AB", sideBC + sideCA - sideAB, TRIANGLE_INEQUALITY_VIOLATED)};
            if (sideBC >= sideCA + sideAB)
                return new ValidationInfo { ErrorMessage = ErrorHelper.ArgumentShouldBePositive("CA + AB - BC", sideCA + sideAB - sideBC, TRIANGLE_INEQUALITY_VIOLATED)};
            if (sideCA >= sideAB + sideBC)
                return new ValidationInfo { ErrorMessage = ErrorHelper.ArgumentShouldBePositive("AB + BC - CA", sideAB + sideBC - sideCA, TRIANGLE_INEQUALITY_VIOLATED)};

            //triangle is ok
            return new ValidationInfo{IsValid = true};
        }

        public override double Area
        {
            get
            {
                //Heron formula is applied
                var halfPerimeter = (_sideAB + _sideBC + _sideCA) / 2;
                return Math.Sqrt(halfPerimeter * (halfPerimeter - _sideAB) * (halfPerimeter - _sideBC) * (halfPerimeter - _sideCA));
            }
        }
    }
}