namespace Domain.Core
{
    /// <summary>
    /// A more generic implementation of IPropertyMatcher that uses 3 other implementation of IPropertyMatcher as per each Agency rule.
    /// This implementation uses all concrete implementation of IPropertyMatcherlisted in IPropertyMatcher[] propertyMatchers. 
    /// </summary>
    /// <seealso cref="Domain.Core.IPropertyMatcher">
    /// <seealso cref="Domain.Core.PropertyMatcherOTBRE">
    /// <seealso cref="Domain.Core.PropertyMatcherLRE">
    /// <seealso cref="Domain.Core.PropertyMatcherCRE">
    /// <seealso cref="Domain.Core.Property">    
    public class PropertyMatcher : IPropertyMatcher
    {
        //Array of all concrete IPropertyMatcher
        public IPropertyMatcher[] propertyMatchers = { 
            new PropertyMatcherOTBRE(),  //Implementation of Only The Best Real Estate!
            new PropertyMatcherLRE(),    //Implementation of Location Real Estate
            new PropertyMatcherCRE()     //Implementation of Contrary Real Estate 
        };
        /// <summary>
        /// Matches agency property with databases property by calling IsMatch of all the implementations.
        /// This method does not use swith of if statements. Instead it employs polymorphism. 
        /// </summary>
        /// <param name="agencyProperty">Agency Property</param>
        /// <param name="databaseProperty">Domain Database Property</param>
        /// <returns>Returns a Boolean value that indicates whether there is a match between the agency property and database property</returns>
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            bool returnValue = false;
            foreach (var propertyMatcher in propertyMatchers)
            {
                returnValue = returnValue || propertyMatcher.IsMatch(agencyProperty, databaseProperty);
            }
            return returnValue;
        }

    }


}
