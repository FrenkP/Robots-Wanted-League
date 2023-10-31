using System.Collections.Generic;

namespace RobotsWantedLeague.Services
{
    public interface ICountriesService
    {
        List<string> GetCountriesByRegion(string region);
        List<string> GetRegionsByCountry(string country);

        string GetData();
        string GetNameById(int id);
        int GetIdByName(string name);
        List<string> GetCountries();
        List<string> GetRegions();
        bool IsCountryValid(string country);
    }
}
