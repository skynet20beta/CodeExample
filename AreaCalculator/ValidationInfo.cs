namespace AreaCalculator
{
    /// <summary>
    /// class represents info about shape validness and first error if it is not valid
    /// </summary>
    public class ValidationInfo
    {
        /// <summary>
        /// true if shape is valid, false otherwise
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// first error encountered in validation process
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}