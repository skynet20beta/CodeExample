using System;

namespace AreaCalculator
{
    /// <summary>
    /// Main interface for the shapes with areas
    /// </summary>
    public interface IShapeWithArea
    {
        double Area { get; }
    }

    /// <summary>
    /// Base implementation of IShapeWithArea supporting validation of shapes
    /// </summary>
    public abstract class BaseShapeWithArea : IShapeWithArea
    {
        /// <summary>
        /// Invalid shape should not be constructed. If shape is invalid according to provided validator it throws InvalidShapeException
        /// </summary>
        /// <param name="validator">func which determines shape validness</param>
        protected BaseShapeWithArea(Func<ValidationInfo> validator)
        {
            var shapeValidnessInfo = validator();
            if (!shapeValidnessInfo.IsValid) throw new InvalidShapeException(shapeValidnessInfo.ErrorMessage);
        }

        /// <summary>
        /// IShapeWithArea implementation
        /// </summary>
        public abstract double Area { get; }
    }
}
