using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotsWantedLeague.Services;

namespace RobotsWantedLeague.Test.Services
{
    [TestClass]
    public class CountryServiceTest
    {
        [TestMethod]
        public void TestIsCountryValid_ValidCountry()
        {
            
            ICountriesService countriesService = new CountriesService();
            bool isValid = countriesService.IsCountryValid("Canada");
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestIsCountryValid_InvalidCountry()
        {
            ICountriesService countriesService = new CountriesService();
            bool isValid = countriesService.IsCountryValid("InvalidCountry");
            Assert.IsFalse(isValid);
        }
    }
}
