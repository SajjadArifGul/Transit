using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Entities;

namespace Transit.Data
{
    public class TransitURLs
    {
        DataContext db = new DataContext();

        public List<TransitURL> GetAll()
        {
            return db.TransitURLs.ToList();
        }

        public bool Add(TransitURL transitURL)
        {
            try
            {
                db.TransitURLs.Add(transitURL);

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TransitURL transitURL)
        {
            try
            {
                TransitURL transitURLInDB = db.TransitURLs.Where(t => t.ID == transitURL.ID).FirstOrDefault();

                if (transitURLInDB != null)
                {
                    transitURLInDB.Name = transitURL.Name;
                    transitURLInDB.Value = transitURL.Value;
                    transitURLInDB.Description = transitURL.Description;
                    transitURLInDB.IsActive = transitURL.IsActive;
                    transitURLInDB.ModifiedBy = transitURL.ModifiedBy;
                    transitURLInDB.ModifiedOn = transitURL.ModifiedOn;

                    db.Entry(transitURLInDB).State = System.Data.Entity.EntityState.Modified;  //should be updated.

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

        public bool Delete(TransitURL transitURL)
        {
            try
            {
                TransitURL transitURLInDB = db.TransitURLs.Where(t => t.ID == transitURL.ID).FirstOrDefault();

                if (transitURLInDB != null)
                {
                    db.Entry(transitURLInDB).State = System.Data.Entity.EntityState.Deleted;

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
