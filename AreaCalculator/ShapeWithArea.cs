namespace AreaCalculator
{
    /// <summary>
    /// Main interface for the shapes with areas
    /// </summary>
    public interface IShapeWithArea
    {
        double GetArea();
    }

    /// <summary>
    /// Base implementation of IShapeWithArea supporting validation of shapes
    /// </summary>
    public abstract class BaseShapeWithArea : IShapeWithArea
    {
        /// <summary>
        /// In case the shape is invalid error message should explain why it is invalid
        /// </summary>
        /// <param name="errorMessage">error message</param>
        /// <returns>true if shape is valid, false otherwise</returns>
        protected abstract bool IsValid(ref string errorMessage);

        /// <summary>
        /// Calculates area of valid shapes
        /// </summary>
        /// <returns>Area of shape</returns>
        protected abstract double CalculateArea();

        /// <summary>
        /// IShapeWithArea implementation
        /// </summary>
        public double GetArea()
        {
            string errorMessage = null;
            if (!IsValid(ref errorMessage)) throw new InvalidShapeException(errorMessage);
            return CalculateArea();
        }
    }
}
