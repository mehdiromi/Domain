using Domain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CoreTest
{
    /// <summary>
    /// Feature: Implementation of "Location Real Estate" matching rules.
    /// A property is considered to be a match if the agency code is the same and the property is within 200 metres or less of the actual property location
    /// </summary>
    [TestClass]
    public class PropertyMatcherLRE_Tests
    {
        /// <summary>
        /// Senario 1:
        ///     Agency code is the same and property is within 200 metres of actual property
        /// Given
        ///     There is an agnecy property and a database property and PropertyMatcherLRE that implements "Location Real Estate" Property matching rules,
        ///     1 degree of latitude or longitute is 111KM.
        /// When
        ///     Agency property AgencyCode matches database property AgencyCode and agency property is within 200 metres of database property,
        /// Then
        ///     IsMatch should return true
        /// </summary>
        [TestMethod]
        public void PropertyMatcherLRE_MatchingAgencyCodeANDWithing200Metres()
        {
            //arrange
            //IPropertyMatcher locationRealEstate = new PropertyMatcherLRE(); 
            PropertyMatcherLRE locationRealEstate = new PropertyMatcherLRE(); 
            Property agencyProperty = new Property();
            Property dbProperty = new Property();

            agencyProperty.AgencyCode = "LRE";

            agencyProperty.Latitude = 43;
            agencyProperty.Longitude = -80;

            dbProperty.AgencyCode = "LRE";
            dbProperty.Latitude = 35;
            dbProperty.Longitude = 135;
            
            
            //act:
            bool expected = locationRealEstate.IsMatch(agencyProperty, dbProperty);

            //assert:  
            Assert.IsFalse(expected, "Agency property did not match with database property with good data.");


        }

       

    }
}




