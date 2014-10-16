using Domain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CoreTest
{
    /// <summary>
    /// Feature: Implementation of PropertyMatcher
    /// A property is considered to be a match if Any of the 3 agency rules match
    /// </summary>
    [TestClass]
    public class PropertyMatcher_Test
    {



        /// <summary>
        /// Senario 1:
        ///     Name and Address in both Agency and Database Properties are match.
        /// Given
        ///     There are agnecy property and database property and PropertyMatcherOTBRE implements "Only The Best Real Estate!" Property matching rules,
        /// When
        ///     Agency property address matches database property address and agency property name matches database property name
        /// Then
        ///     IsMatch should return true
        /// </summary>
        [TestMethod]
        public void PropertyMatcher_OnlyTheBestRealEstateRealEstate()
        {
            //arrange
            IPropertyMatcher pm = new PropertyMatcher();

            Property agencyPropertyWithPunctuation = new Property();
            Property dbProperty = new Property();

            agencyPropertyWithPunctuation.AgencyCode = "OTBRE";

            agencyPropertyWithPunctuation.Name = "*Super*-­‐High! APARTMENTS (Sydney)";
            agencyPropertyWithPunctuation.Address = "32 Sir John-­Young Crescent, Sydney, NSW.";

            dbProperty.Name = "Super High Apartments, Sydney";
            dbProperty.Address = "32 Sir John Young Crescent, Sydney NSW";

            //act:
            bool expected = pm.IsMatch(agencyPropertyWithPunctuation, dbProperty);

            //assert:            
            Assert.IsTrue(expected);

        }


        /// <summary>
        /// Senario 2:
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
        public void PropertyMatcher_LocationRealEstate()
        {
            //arrange
            IPropertyMatcher pm = new PropertyMatcher();


            Property agencyProperty = new Property();
            Property dbProperty = new Property();

            agencyProperty.AgencyCode = "LRE";

            agencyProperty.Latitude = 43;
            agencyProperty.Longitude = -80;

            dbProperty.AgencyCode = "LRE";
            dbProperty.Latitude = 35;
            dbProperty.Longitude = 135;


            //act:
            bool expected = pm.IsMatch(agencyProperty, dbProperty);

            //assert:  
            Assert.IsFalse(expected);


        }
        
        
        
        /// <summary>
        /// Senario 3:
        ///     Agency code is the same and property is within 200 metres of actual property
        /// Given
        ///     There is an agnecy property and a database property and PropertyMatcherOTBRE that implements "Location Real Estate" Property matching rules,
        ///     1 degree of latitude or longitute is 111KM.
        /// When
        ///     Agency property AgencyCode matches database property AgencyCode and agency property is within 200 metres of database property,
        /// Then
        ///     IsMatch should return true
        /// </summary>
        [TestMethod]
        public void PropertyMatcher_ContraryRealEstate()
        {
            //arrange
            IPropertyMatcher pm = new PropertyMatcher();

            Property agencyProperty = new Property();
            Property dbProperty = new Property();
            
            agencyProperty.AgencyCode = "CRE";
            agencyProperty.Name = "One Two  Three Four   FIVE  Six ";
            agencyProperty.Latitude = 43;
            agencyProperty.Longitude = -80;

            dbProperty.AgencyCode = "LRE";
            dbProperty.Name = "Six FIVE Four Three Two One";
            dbProperty.Latitude = 35;
            dbProperty.Longitude = 135;
            
            //act:
            bool expected = pm.IsMatch(agencyProperty, dbProperty);

            //assert:  
           Assert.IsTrue(expected);
        }

       

    }
}




