using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transit.Entities;

namespace Transit.Commons
{
    public class Record
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }

    public class VehicleTypeRecord : Record
    {
        public List<VehicleType> VehicleTypesList { get; set; }
        public VehicleType VehicleType { get; set; }
    }

    public class CityRecord : Record
    {
        public List<City> CitiesList { get; set; }
        public City City { get; set; }
    }
}
