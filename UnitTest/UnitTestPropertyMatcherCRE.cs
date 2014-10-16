using Domain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CoreTest
{
    /// <summary>
    /// Feature: Implementation of "Contrary Real Estate" matching rules.
    /// property is considered a match if the names match when the words in the name of the property are reversed.
    /// </summary>
    [TestClass]
    public class PropertyMatcherCRE_Tests
    {
        /// <summary>
        /// Senario 1:
        ///     agency name and darabase name match
        /// Given
        ///     There is an agnecy property and a database property and PropertyMatcherCRE that implements "Contrary Real Estate" Property matching rules,     
        /// When
        ///     Reversed Agency property name matches the  database property name,
        /// Then
        ///     IsMatch should return true
        /// </summary>
        [TestMethod]
        public void PropertyMatcherCRE_ReversedNameMatch()
        {
            //arrange
            //IPropertyMatcher locationRealEstate = new PropertyMatcherLRE(); 
            PropertyMatcherCRE ContraryRealEstate = new PropertyMatcherCRE(); 
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
            bool expected = ContraryRealEstate.IsMatch(agencyProperty, dbProperty);

            //assert:  
           Assert.IsTrue(expected);


        }

       

    }
}




