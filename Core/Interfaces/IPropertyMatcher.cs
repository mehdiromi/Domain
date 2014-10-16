namespace Domain.Core
{
    /// <summary>
    /// Domain.Core namespace contains Domain core interfaces, base classes and implementations for all Domain Products.
    /// </summary>
    public static class NamespaceDoc
    {
        //This static class is created for the purposes of documentation and does not need any implementation.
    }

    /// <summary>
    /// IPropertyMatcher is an interface to match whether properties from agencies inventory matches with Domain database inventory for a particular agency.
    /// </summary>
    /// <seealso cref="Domain.Core.Property">
    /// Type of agencyProperty and databaseProperty that are used in IsMatch method.
    /// </seealso>     
    public interface IPropertyMatcher
    {
        /// <summary>
        /// IsMatch matches an agency property with Domain database property to determine whether an insert or an update is needed 
        /// </summary>
        /// <param name="agencyProperty">Agency Property</param>
        /// <param name="databaseProperty">Domain Database Property</param>
        /// <seealso cref="Domain.Core.AgencyInventory.Property">
        /// <returns>Return value is Boolean that indicates whether there is a match between agency property and database property</returns>
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}
