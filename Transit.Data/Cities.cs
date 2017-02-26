using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Entities;

namespace Transit.Data
{
    public class Cities
    {
        DataContext db = new DataContext();

        public List<City> GetAll()
        {
            return db.Cities.ToList();
        }

        public bool Add(City city)
        {
            try
            {
                db.Cities.Add(city);

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(City city)
        {
            try
            {
                City cityInDB = db.Cities.Where(t => t.ID == city.ID).FirstOrDefault();

                if (cityInDB != null)
                {
                    cityInDB.Name = city.Name;
                    cityInDB.CountryID = city.CountryID;
                    cityInDB.IsActive = city.IsActive;
                    cityInDB.ModifiedBy = city.ModifiedBy;
                    cityInDB.ModifiedOn = city.ModifiedOn;

                    db.Entry(cityInDB).State = System.Data.Entity.EntityState.Modified;  //should be updated.

                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(City city)
        {
            try
            {
                City cityInDB = db.Cities.Where(t => t.ID == city.ID).FirstOrDefault();

                if (cityInDB != null)
                {
                    db.Entry(cityInDB).State = System.Data.Entity.EntityState.Deleted;

                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
