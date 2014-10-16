using Domain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.CoreTest
{
    /// <summary>
    /// Feature: Implementation of "Only The Best Real Estate!" Property matching rules.
    /// A property is considered to be a match if both the property name and address match when punctuation is excluded.
    /// </summary>
    [TestClass]
    public class PropertyMatcherOTBRE_Tests
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
        public void PropertyMatcherOTBRE_MatchingNamesAndAddresses()
        {
            //arrange
            IPropertyMatcher onlyTheBestRealEstate = new PropertyMatcherOTBRE(); 
            Property agencyPropertyWithPunctuation = new Property();
            Property dbCleanProperty = new Property();

            agencyPropertyWithPunctuation.AgencyCode = "OTBRE";

            agencyPropertyWithPunctuation.Name = "*Super*-­‐High! APARTMENTS (Sydney)";
            agencyPropertyWithPunctuation.Address = "32 Sir John-­Young Crescent, Sydney, NSW.";
            
            dbCleanProperty.Name = "Super High Apartments, Sydney";
            dbCleanProperty .Address = "32 Sir John Young Crescent, Sydney NSW";

            //act:
            bool expected = onlyTheBestRealEstate
                .IsMatch(agencyPropertyWithPunctuation, dbCleanProperty);

            //assert:            
            Assert.IsTrue(expected, "agency property did not match with database property.");

        }

        /// <summary>
        /// Senario 2: 
        ///     Names are match but Addresses
        /// Given 
        ///     There are agnecy property and database property and PropertyMatcherOTBRE implements "Only The Best Real Estate!" Property matching rules,
        /// When 
        ///     Agency property address does not match database property address but agency property name matches database property name
        /// Then 
        ///     IsMatch should return false
        /// </summary>
        [TestMethod]
        public void PropertyMatcherOTBRE_MatchingNamesButAddresses()
        {
            //arrange
            IPropertyMatcher onlyTheBestRealEstate = new PropertyMatcherOTBRE();
            Property agencyPropertyWithPunctuation = new Property();
            Property dbCleanProperty = new Property();

            agencyPropertyWithPunctuation.AgencyCode = "OTBRE"; 
            agencyPropertyWithPunctuation.Name = "*Super*-­‐High! APARTMENTS (Sydney)";
            agencyPropertyWithPunctuation.Address = "32 Sir John-­Young Crescent, Sydney, NSW.";

            dbCleanProperty.Name = "Super High Apartments, Sydney";
            dbCleanProperty.Address = "32 Sir John Young , Sydney NSW";

            //act:
            bool expected = onlyTheBestRealEstate
                .IsMatch(agencyPropertyWithPunctuation, dbCleanProperty);

            //assert:            
            Assert.IsFalse(expected);

        }

        /// <summary>
        /// Senario 3:
        ///     Addresses are match but Names
        /// Given 
        ///     There are agnecy property and database property and PropertyMatcherOTBRE implements "Only The Best Real Estate!" Property matching rules,
        /// When
        ///     Agency property address matches database property address but agency property name does not matches database property name
        /// Then
        ///     IsMatch should return false
        /// </summary>
        [TestMethod]
        public void PropertyMatcherOTBRE_MatchingAddressesButNames()
        {
            //arrange
            IPropertyMatcher onlyTheBestRealEstate = new PropertyMatcherOTBRE();
            Property agencyPropertyWithPunctuation = new Property();
            Property dbCleanProperty = new Property();

            agencyPropertyWithPunctuation.AgencyCode = "OTBRE"; 
            agencyPropertyWithPunctuation.Name = "*Super*-­‐High! APARTMENTS (Sydney)";
            agencyPropertyWithPunctuation.Address = "32 Sir John-­Young Crescent, Sydney, NSW.";

            dbCleanProperty.Name = "High Apartments";
            dbCleanProperty.Address = "32 Sir John Young Crescent, Sydney NSW";

            //act:
            bool expected = onlyTheBestRealEstate
                .IsMatch(agencyPropertyWithPunctuation, dbCleanProperty);

            //assert:            
            Assert.IsFalse(expected);

        }
        /// <summary>
        /// Senario 4:
        ///     Undefined properties
        /// Given
        ///     There are agnecy property and database property and PropertyMatcherOTBRE implements "Only The Best Real Estate!" Property matching rules,
        /// When
        ///     Agency property address does not have value,
        /// Then
        ///     IsMatch should throw a NullReferenceException Exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PropertyMatcherOTBRE_HandleNoValue()
        {
            //arrange
            IPropertyMatcher onlyTheBestRealEstate = new PropertyMatcherOTBRE();
            Property agencyPropertyWithPunctuation = new Property();
            Property dbCleanProperty = new Property();

            agencyPropertyWithPunctuation.AgencyCode = "OTBRE"; 
            agencyPropertyWithPunctuation.Name = "*Super*-­‐High! APARTMENTS (Sydney)";

            dbCleanProperty.Name = "Super High Apartments, Sydney";
            dbCleanProperty.Address = "32 Sir John Young Crescent, Sydney NSW";

            //act:
            bool expected = onlyTheBestRealEstate
                   .IsMatch(agencyPropertyWithPunctuation, dbCleanProperty);

            // assert is handled by ExpectedException
        }

        /// <summary>
        /// Senario 5:
        ///     Expect an Exception when IsMatch is called with invalid params 
        /// Given
        ///     There is a PropertyMatcherOTBRE implements "Only The Best Real Estate!" Property matching rules,
        /// When
        ///     IsMatch is called with null params,
        /// Then
        ///     IsMatch should throw an exception
        /// </summary>
        [TestMethod]
        public void PropertyMatcherOTBRE_HandleNoValue2()
        {
            //arrange
            IPropertyMatcher onlyTheBestRealEstate = new PropertyMatcherOTBRE();
            try
            {
                //act:
                bool expected = onlyTheBestRealEstate
                       .IsMatch(null, null);
            }
            catch (Exception e)
            {
                // assert
                Assert.IsNotNull(e);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

    }
}