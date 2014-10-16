using System;

namespace Domain.Core
{
    /// <summary>
    /// Static methods 
    /// </summary>
    static class MapHelper
    {
        
        const double ONE_DEGREE_METRES = 111000;  // In metres 111km = 111,000 metres
        
        
        /// <summary>
        ///  Calculate distance (in km) between two points specified by latitude/longitude (in numeric degrees)
        /// </summary>
        /// <param name="lat1">first point latitude</param>
        /// <param name="lon1">first point longitude</param>
        /// <param name="lat2">second point latitude</param>
        /// <param name="lon2">second point longitude</param>
        /// <returns>distance between 2 points in metres</returns>
        public static double Distance(decimal lat1, decimal long1, decimal lat2, decimal long2)
        {
            
            //Calculates the cos distance based on the collowing formula:
            //Cos(distnace) = sin(lat1) X sin (lat2) + cos(lat1) X  cos(lat2) X cos( long2 - long1)
            double cosDistanct = 
                Math.Sin(lat1.ToRadians()) * Math.Sin(lat2.ToRadians()) +
                Math.Cos(lat1.ToRadians()) * 
                Math.Cos(lat2.ToRadians()) * 
                Math.Cos((long2.ToRadians() - long1.ToRadians()));

            //To calcualte the distance in metres we use Arccoss(cosDistance) in Degree X 111KM X 1000  
            double distance = Math.Acos(cosDistanct).ToDegree() *  ONE_DEGREE_METRES;
            
            return distance;
        }
    }
}
