using System;

namespace AreaCalculator
{
    /// <summary>
    /// If shape with given parameters cannot exist, this exception is thrown
    /// </summary>
    public class InvalidShapeException : Exception
    {
        public InvalidShapeException(string errorMessage) : base(errorMessage)
        {
        }
    }
}