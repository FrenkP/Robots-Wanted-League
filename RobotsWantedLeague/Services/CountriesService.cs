using System.Collections.Generic;
using RobotsWantedLeague.Models;
using System.Linq;

namespace RobotsWantedLeague.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries = CountryData.data;

        private readonly List<Country> _regions = CountryData.data;

        public List<string> GetCountriesByRegion(string region)
        {
            List<string> regionCountries = new List<string>();
            foreach (Country country in _countries)
            {
                if (country.Region == region)
                {
                    regionCountries.Add(country.Name);
                }
            }
            return regionCountries;
        }

        public List<string> GetRegionsByCountry(string country)
        {
         List<string> countryRegions = new List<string>();
         foreach (Country region in _regions)
          {
           if (region.Name == country)
            {
            countryRegions.Add(region.Region);
            }
          }
         return countryRegions;
        }


        public string GetData()
        {
            return GenerateData().ToString();
        }

        public string GetNameById(int id)
        {
            if (id < 0 || id >= _countries.Count)
            {
                return "Invalid ID";
            }
            return _countries[id].Name;
        }

        public int GetIdByName(string name)
        {
            int index = GetIndexOfCountryByData(name);
            if (index == -1)
            {
                return -1;
            }
            return index;
        }

        public List<string> GetCountries()
        {
            List<string> countryNames = new List<string>();
            foreach (Country country in _countries)
            {
                countryNames.Add(country.Name);
            }
            return countryNames;
        }

        public List<string> GetRegions()
        {
            List<string> regions = new List<string>();
            foreach (Country country in _countries)
            {
                if (!regions.Contains(country.Region))
                {
                    regions.Add(country.Region);
                }
            }
            return regions;
        }

        public bool IsCountryValid(string country)
        {
            // Vérifie si pays spécifié fait partie des pays valides
            return _countries.Any(c => string.Equals(c.Name, country, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsRegionValid(string region)
        {

            return _regions.Any(c => string.Equals(c.Region, region, StringComparison.OrdinalIgnoreCase));
        }

        private int dataGenerator = 0;

        private int GenerateData()
        {
            dataGenerator++;
            return dataGenerator;
        }

        private int GetIndexOfCountryByData(string data)
        {
            int datax = 0;
            foreach (Country country in _countries)
            {
                if (country.Name == data)
                {
                    return datax;
                }
                datax++;
            }
            return -1;
        }
    }
}
