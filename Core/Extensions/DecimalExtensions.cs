using System;
namespace Domain.Core
{
    /// <summary>
    /// Extension methods to double type that are used in this project.
    /// </summary>
    static class DecimalExtentions
    {
        /// <summary>
        /// Converts a decimal latitude or longitude to radians 
        /// </summary>
        /// <param name="input">latitude or longitude</param>
        /// <returns>radians value for the input</returns>
        public static double ToRadians(this decimal input)
        {
            return Convert.ToDouble((double)input * Math.PI / 180);
        }
    }
}