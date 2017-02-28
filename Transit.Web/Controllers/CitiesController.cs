using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transit.Commons;
using Transit.Entities;
using Transit.Services;
using Transit.Web.Models;

namespace Transit.Web.Controllers
{
    public class CitiesController : Controller
    {
        public bool VerifyModel(CityViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name) && model.CountryID > 0)
            {
                return true;
            }
            return false;
        }

        public CitiesViewModel GetCitiesModel()
        {
            CitiesViewModel model = new CitiesViewModel();

            model.Title = "Cities";
            model.BreadCrumbs = new List<Link>{
                new Link() { Text="Transit", URL="/" },
                new Link() { Text="Cities" },
            };

            model.Cities = new List<CityViewModel>();
            foreach (City city in CitiesService.Instance.GetAllCities())
            {
                model.Cities.Add(new CityViewModel()
                {
                    ID = city.ID,
                    Name = city.Name,
                    CountryID = city.CountryID,
                    IsActive = city.IsActive,
                    CreatedBy = city.CreatedBy,
                    CreatedOn = city.CreatedOn,
                    ModifiedBy = city.ModifiedBy,
                    ModifiedOn = city.ModifiedOn
                });
            }

            return model;
        }
        
        public ActionResult Index()
        {
            return View(GetCitiesModel());
        }
        
        [HttpGet]
        public JsonResult GetAllCitiesAJAX()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = new CityRecord()
            {
                CitiesList = CitiesService.Instance.GetAllCities()
            };

            return result;
        }

        [HttpGet]
        public JsonResult GetCitiesByCountryIDAJAX(int CountryID)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (CountryID > 0)
            {
                result.Data = new CityRecord()
                {
                    Successful = true,
                    Country = CountriesService.Instance.GetCountryByID(CountryID),
                    CitiesList = CitiesService.Instance.GetCitiesByCountryID(CountryID)
                };
            }
            else
            {
                result.Data = new CityRecord()
                {
                    Successful = false,
                    Exception = "No Country ID Passed."
                };
            }

            return result;
        }

        [HttpGet]
        public JsonResult GetAllCountriesAJAX()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            //result.Data = new CountryRecord();
            //{
            //    Successful = true,
            //    CountriesArray = new string[ CountriesService.Instance.GetAllCountries()
            //};

            CountryRecord record = new CountryRecord();

            List<Country> countries = CountriesService.Instance.GetAllCountries();

            if (countries.Count > 0)
            {
                record.Successful = true;
                record.CountryItems = new CountryItem[countries.Count];
                int i= 0;
                foreach (Country country in countries)
                {
                    record.CountryItems[i] = new CountryItem() {
                        value = country.ID,
                        label = country.Name
                    };
                    i++;
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "No countries found";
            }

            result.Data = record;
            return result;
        }
        
        [HttpPost]
        public JsonResult AddNewCityAJAX(CityViewModel model)
        {
            JsonResult result = new JsonResult();

            CityRecord record = new CityRecord();

            if (VerifyModel(model))
            {
                if (CitiesService.Instance.GetCityByName(model.Name) != null)
                {
                    record.Successful = false;
                    record.Exception = "City with name " + model.Name + " already exists.";
                }
                else
                {
                    City newCity = new City()
                    {
                        Name = model.Name,
                        CountryID = model.CountryID,
                        IsActive = model.IsActive,
                        CreatedBy = User.Identity.GetUserName(),
                        CreatedOn = DateTime.Now,
                        ModifiedBy = User.Identity.GetUserName(),
                        ModifiedOn = DateTime.Now
                    };

                    if (CitiesService.Instance.AddNewCity(newCity))
                    {
                        record.Successful = true;
                        record.City = CitiesService.Instance.GetCityByName(newCity.Name);
                    }
                    else
                    {
                        record.Successful = false;
                        record.Message = "An error occurred while adding " + newCity.Name + " City record.";
                    }
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "City Data is incomplete.";
            }

            result.Data = record;
            return result;
        }

        [HttpPost]
        public JsonResult UpdateCityAJAX(CityViewModel model)
        {
            JsonResult result = new JsonResult();

            CityRecord record = new CityRecord();

            if (VerifyModel(model) && model.ID != 0)
            {
                if (CitiesService.Instance.IsUpdateAllowed(model.ID, model.CountryID, model.Name))
                {
                    City updateCity = new City()
                    {
                        ID = model.ID,
                        Name = model.Name,
                        CountryID = model.CountryID,
                        IsActive = model.IsActive,
                        ModifiedBy = User.Identity.GetUserName(),
                        ModifiedOn = DateTime.Now
                    };

                    if (CitiesService.Instance.UpdateCity(updateCity))
                    {
                        record.Successful = true;
                        record.City = CitiesService.Instance.GetCityByID(model.ID);
                    }
                    else
                    {
                        record.Successful = false;
                        record.Message = "An error occurred while updating City record.";
                    }
                }
                else
                {
                    record.Successful = false;
                    record.Exception = "City with name " + model.Name + " already exists.";
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "City Data is incomplete.";
            }

            result.Data = record;
            return result;
        }

        [HttpPost]
        public JsonResult DeleteCityAJAX(int ID)
        {
            JsonResult result = new JsonResult();

            CityRecord record = new CityRecord();

            if (ID > 0)
            {
                if (CitiesService.Instance.DeleteCityByID(ID))
                {
                    record.Successful = true;
                }
                else
                {
                    record.Successful = false;
                    record.Message = "An error occurred while deleting City record.";
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "City Data is incomplete.";
            }

            result.Data = record;
            return result;
        }
    }
}