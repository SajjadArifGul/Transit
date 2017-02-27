using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Data;
using Transit.Entities;

namespace Transit.Services
{
    public class CountriesService
    {
        Countries countries = new Countries();

        #region Define as Singleton
        private static CountriesService _Instance;

        public static CountriesService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CountriesService();
                }

                return (_Instance);
            }
        }

        private CountriesService()
        {
        }
        #endregion

        public List<Country> GetAllCountries()
        {
            return countries.GetAll();
        }

        public Country GetCountryByID(int ID)
        {
            return countries.GetAll().Where(t => t.ID == ID).FirstOrDefault();
        }

        public Country GetCountryByName(string Name)
        {
            return countries.GetAll().Where(t => t.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public bool IsUpdateAllowed(int ID, string Name)
        {
            if (countries.GetAll().Where(t => t.Name == Name).Where(t => t.ID != ID).FirstOrDefault() != null)
            {
                return false;
            }
            else return true;
        }

        public bool AddNewCountry(Country country)
        {
            return countries.Add(country);
        }

        public bool UpdateCountry(Country country)
        {
            return countries.Update(country);
        }

        public bool DeleteCountry(Country country)
        {
            return countries.Delete(country);
        }

        public bool DeleteCountryByID(int ID)
        {
            return countries.Delete(new Country() { ID = ID });
        }
    }
}
