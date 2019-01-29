using System;

namespace AreaCalculator
{
    public class Circle : BaseShapeWithArea
    {
        private readonly double _radius;

        /// <summary>
        /// Creates circle with given radius
        /// </summary>
        /// <param name="radius">radius</param>
        public Circle(double radius) : base(() => CheckRadius(radius))
        {
            _radius = radius;
        }

        private static ValidationInfo CheckRadius(double radius)
        {
            return radius > 0
                ? new ValidationInfo {IsValid = true}
                : new ValidationInfo {ErrorMessage = ErrorHelper.ArgumentShouldBePositive("Circle radius", radius)};
        }

        public override double Area => Math.PI * _radius * _radius;
    }
}