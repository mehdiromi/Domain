namespace Domain.Core
{
    /// <summary>
    /// An Implementation of Domain.Core.IPropertyMatcher with "Only The Best Real Estate!" Property matching rules.
    /// </summary>
    /// <seealso cref="Domain.Core.IPropertyMatcher">
    /// <seealso cref="Domain.Core.Property">
    /// <remarks> 
    /// A property is considered to be a match if both the property name and address match when punctuation is excluded.
    /// </remarks>
    public class PropertyMatcherOTBRE : IPropertyMatcher
    {
        //Agency code this particular concrete implementation
        const string AGENCY_CODE = "OTBRE";  //Only The Best Real Estate!
        
        /// <summary>
        /// An Implementation of Domain.Core.IPropertyMatcher.IsMatch with "Only The Best Real Estate!" Property matching rules.
        /// A property is considered to be a match if both the property name and address match when punctuation is excluded.
        /// </summary>
        /// <seealso cref="Domain.Core.StringExtensions.StripPunctuation">    
        /// <param name="agencyProperty">Agency Property</param>
        /// <param name="databaseProperty">Domain Database Property</param>
        /// <returns>Returns a Boolean value that indicates whether there is a match between the name and address of agency property and database property</returns>
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return
                agencyProperty.AgencyCode == AGENCY_CODE &&
                agencyProperty.Address.StripPunctuation().ToLower().Equals(databaseProperty.Address.StripPunctuation().ToLower()) &&
                agencyProperty.Name.StripPunctuation().ToLower().Equals(databaseProperty.Name.StripPunctuation().ToLower());
        }
    }
}
