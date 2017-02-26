using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Data;
using Transit.Entities;

namespace Transit.Services
{
    public class CitiesService
    {
        Cities cities = new Cities();

        #region Define as Singleton
        private static CitiesService _Instance;

        public static CitiesService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CitiesService();
                }

                return (_Instance);
            }
        }

        private CitiesService()
        {
        }
        #endregion

        public List<City> GetAllCities()
        {
            return cities.GetAll();
        }

        public City GetCityByID(int ID)
        {
            return cities.GetAll().Where(t => t.ID == ID).FirstOrDefault();
        }

        public City GetCityByName(string Name)
        {
            return cities.GetAll().Where(t => t.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public bool IsUpdateAllowed(int ID, int CountryID, string Name)
        {
            if (cities.GetAll().Where(t => t.Name == Name).Where(t => t.CountryID != CountryID).Where(t => t.ID != ID).FirstOrDefault() != null)
            {
                return false;
            }
            else return true;
        }

        public bool AddNewCity(City city)
        {
            return cities.Add(city);
        }

        public bool UpdateCity(City city)
        {
            return cities.Update(city);
        }

        public bool DeleteCity(City city)
        {
            return cities.Delete(city);
        }

        public bool DeleteCityByID(int ID)
        {
            return cities.Delete(new City() { ID = ID });
        }
    }
}
