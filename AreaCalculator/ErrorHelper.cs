namespace AreaCalculator
{
    /// <summary>
    /// Since error messages are similar, their processing was extracted to separate class
    /// </summary>
    public static class ErrorHelper
    {
        private static string ShouldBePositive => "It should be > 0.";

        public static string ArgumentShouldBePositive(string argumentDescription, double value, string customInfo = null)
        {
            return $"{customInfo} {argumentDescription} = {value}. {ShouldBePositive}";
        }
    }
}