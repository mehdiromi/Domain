
namespace Domain.Core
{
    /// <summary>
    /// Here are the Extension methods for Property Class
    /// </summary>
    static class PropertyExtentions
    {
        /// <summary>
        /// DistanceFrom is an Extention Method to Property Class to calculate the distance between 2 propery
        /// Usage:   Property1.DistanceFrom(Property2)
        /// </summary>
        /// <param name="first">Fist Property</param>
        /// <param name="second">Second Property</param>
        /// <returns>Distance between first property and second property</returns>
        public static double DistanceFrom(this Property firstProperty, Property secondProperty)
        {
            //Calling MapHelper.Distance Helper method to claculate the distance by passing the latitude nad longitude of the 2 properties.
            return MapHelper.Distance(firstProperty.Latitude, firstProperty.Longitude, secondProperty.Latitude, secondProperty.Longitude);
        }
    }

}