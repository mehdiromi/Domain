namespace Domain.Core
{
    /// <summary>
    /// Property class definition. 
    /// Property is a base class that is assumed to be consumed as a base type in Interfaces such as IPropertyMatcher    
    /// <seealso cref="Domain.Core.PropertyExtentions.DistanceFrom">
    /// </summary>
    public class Property
    {
        /// <summary>Address property.</summary> 
        /// <value>A property address. Example: 88 Vista st, Mosman, NSW</value>
        /// <seealso cref="System.String">
        public string Address { get; set; }

        /// <summary>AgencyCode property.</summary> 
        /// <value>A unique code to identify real estate agency for this Property</value>
        public string AgencyCode { get; set; }

        /// <summary>Name property.</summary> 
        /// <value>Property name</value>
        public string Name { get; set; }

        /// <summary>Latitude property.</summary> 
        /// <value>Property address latitude on the map</value>
        public decimal Latitude { get; set; }

        /// <summary>Longitude property.</summary> 
        /// <value>Property address Longitude on the map</value>
        public decimal Longitude { get; set; }
    }
}