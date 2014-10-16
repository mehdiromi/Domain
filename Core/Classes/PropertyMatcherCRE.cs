namespace Domain.Core
{
    /// <summary>
    /// An Implementation of Domain.Core.IPropertyMatcher with "Contrary Real Estate!" Property matching rules.
    /// </summary>
    /// <seealso cref="Domain.Core.IPropertyMatcher">
    /// <seealso cref="Domain.Core.Property">
    /// <remarks> 
    /// property is considered a match if the names match when the words in the name of the property are reversed.
    /// </remarks>
    public class PropertyMatcherCRE : IPropertyMatcher
    {
        //Agency code this particular concrete implementation
        const string AGENCY_CODE = "CRE";  //Conterary Real Estate
        
        /// <summary>
        /// An Implementation of Domain.Core.IPropertyMatcher.IsMatch with "Contrary Real Estate!" Property matching rules.
        /// property is considered a match if the names match when the words in the name of the property are reversed.
        /// </summary>
        /// <seealso cref="Domain.Core.StringExtensions.Reversed">    
        /// <param name="agencyProperty">Agency Property</param>
        /// <param name="databaseProperty">Domain Database Property</param>
        /// <returns>Returns a Boolean value that indicates whether there is a match when the agency property name is reversed</returns>
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return 
                agencyProperty.AgencyCode == AGENCY_CODE &&
                agencyProperty.Name.Reversed().Equals(databaseProperty.Name);
                //Reversed is an  extention method that reverses a given string.
        }

       
    }

}
