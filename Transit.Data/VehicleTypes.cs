using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Entities;

namespace Transit.Data
{
    public class VehicleTypes
    {
        DataContext db = new DataContext();

        public List<VehicleType> GetAll()
        {
            return db.VehicleTypes.Where(t=>t.IsActive == true).ToList();
        }

        public List<VehicleType> GetAllForAdmin()
        {
            return db.VehicleTypes.ToList();
        }

        public bool Add(VehicleType vehicleType)
        {
            try
            {
                db.VehicleTypes.Add(vehicleType);

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(VehicleType vehicleType)
        {
            try
            {
                VehicleType VehicleTypeInDB = db.VehicleTypes.Where(t => t.ID == vehicleType.ID).FirstOrDefault();

                if (VehicleTypeInDB != null)
                {
                    VehicleTypeInDB = vehicleType;

                    db.Entry(VehicleTypeInDB).State = System.Data.Entity.EntityState.Modified;  //should be updated.
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


        public bool Delete(VehicleType vehicleType)
        {
            try
            {
                VehicleType VehicleTypeInDB = db.VehicleTypes.Where(t => t.ID == vehicleType.ID).FirstOrDefault();

                if (VehicleTypeInDB != null)
                {
                    VehicleTypeInDB.IsActive = false; //we will not delete. Just change status to false.

                    db.Entry(VehicleTypeInDB).State = System.Data.Entity.EntityState.Modified;  //should be updated.
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
