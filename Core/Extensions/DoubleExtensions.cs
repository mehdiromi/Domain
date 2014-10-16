using System;
namespace Domain.Core
{
    /// <summary>
    /// Extension methods for double type that are used in this project
    /// </summary>
    static class DoubleExtentions
    {
        /// <summary>
        /// checks if a double value is less than another double value.
        /// The purpose of this extension method is to make the code more readable like plain english :   distance.IsUnder(MaxDistance) 
        /// </summary>
        /// <param name="distance">Distance</param>
        /// <param name="maxDistance">maximum distance</param>
        /// <returns>boolean value if distance is less than max distance</returns>
        public static bool IsUnder(this double distance, double maxDistance)
        {
            return distance <= maxDistance;
        }
        /// <summary>
        /// Converts a double Radians value to Degree.
        /// </summary>
        /// <param name="input">Radians</param>
        /// <returns>Degree</returns>
        public static double ToDegree(this double input)
        {
            return input * 180 / Math.PI;
        }
    }
}