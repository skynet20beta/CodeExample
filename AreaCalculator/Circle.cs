using System;

namespace AreaCalculator
{
    public class Circle : BaseShapeWithArea
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        protected override bool IsValid(ref string errorMessage)
        {
            if (_radius > 0) return true;
            errorMessage = ErrorHelper.ArgumentShouldBePositive("Circle radius", _radius);
            return false;
        }

        protected override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}