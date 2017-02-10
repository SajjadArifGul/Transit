using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Data;
using Transit.Entities;

namespace Transit.Services
{
    public class VehicleTypesService
    {
        VehicleTypes vehicleTypes = new VehicleTypes();

        #region Define as Singleton
        private static VehicleTypesService _Instance;

        public static VehicleTypesService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VehicleTypesService();
                }

                return (_Instance);
            }
        }

        private VehicleTypesService()
        {
        }
        #endregion

        public List<VehicleType> GetAllVehicleTypes()
        {
            return vehicleTypes.GetAll();
        }

        public VehicleType GetVehicleTypeByID(int ID)
        {
            return vehicleTypes.GetAll().Where(t=>t.ID == ID).FirstOrDefault();
        }

        public VehicleType GetVehicleTypeByName(string Name)
        {
            return vehicleTypes.GetAll().Where(t => t.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public bool AddNewVehicleType(VehicleType vehicleType)
        {
            return vehicleTypes.Add(vehicleType);
        }

        public bool UpdateVehicleType(VehicleType vehicleType)
        {
            return vehicleTypes.Update(vehicleType);
        }

        public bool DeleteVehicleType(VehicleType vehicleType)
        {
            return vehicleTypes.Delete(vehicleType);
        }
    }
}
