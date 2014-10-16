
namespace Domain.Core
{
    /// <summary>
    /// An Implementation of Domain.Core.IPropertyMatcher with "Location Real Estate" matching rules.
    /// </summary>
    /// <seealso cref="Domain.Core.IPropertyMatcher">
    /// <seealso cref="Domain.Core.Property">
    /// <remarks> 
    /// A property is considered to be a match if the agency code is the same and the property is within 200 metres or less of the actual property location
    /// </remarks>
    public class PropertyMatcherLRE : IPropertyMatcher
    {
        //Agency code this particular concrete implementation
        const string AGENCY_CODE = "LRE";  //Location Real Estate
        //Max distance in metres to consider the properties are same
        const double MAX_DISTANCE = 200; 

        /// <summary>
        /// An Implementation of Domain.Core.IPropertyMatcher.IsMatch with "Location Real Estate" matching rules.
        /// A property is considered to be a match if the agency code is the same and the property is within 200 metres or less of the actual property location
        /// </summary>
        /// <seealso cref="Domain.Core.PropertyExtentions.DistanceFrom">
        /// <seealso cref="Domain.Core.DecimalExtentions.IsUnder">
        /// <param name="agencyProperty">Agency Property</param>
        /// <param name="databaseProperty">Domain Database Property</param>
        /// <returns>Returns a Boolean value that indicates whether agency property in within 200 metres of the database property</returns>
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
           
            //DistanceFrom and IsUnder are 2 extension methods that help the code to read like plain English
            return
                agencyProperty.AgencyCode == AGENCY_CODE &&
                agencyProperty.AgencyCode.Equals(databaseProperty.AgencyCode) &&
                agencyProperty.DistanceFrom(databaseProperty).IsUnder(MAX_DISTANCE);
        }

    }
}