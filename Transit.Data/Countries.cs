using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Entities;

namespace Transit.Data
{
    public class Countries
    {
        DataContext db = new DataContext();

        public List<Country> GetAll()
        {
            return db.Countries.ToList();
        }

        public bool Add(Country country)
        {
            try
            {
                db.Countries.Add(country);

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Country country)
        {
            try
            {
                Country countryInDB = db.Countries.Where(t => t.ID == country.ID).FirstOrDefault();

                if (countryInDB != null)
                {
                    countryInDB.Name = country.Name;
                    countryInDB.IsActive = country.IsActive;
                    countryInDB.ModifiedBy = country.ModifiedBy;
                    countryInDB.ModifiedOn = country.ModifiedOn;

                    db.Entry(countryInDB).State = System.Data.Entity.EntityState.Modified;  //should be updated.

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

        public bool Delete(Country country)
        {
            try
            {
                Country countryInDB = db.Countries.Where(t => t.ID == country.ID).FirstOrDefault();

                if (countryInDB != null)
                {
                    db.Entry(countryInDB).State = System.Data.Entity.EntityState.Deleted;

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
