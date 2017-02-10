using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transit.Entities
{
    public class Route
    {
        [Key]
        public int ID { get; set; }

        public Vehicle Vehicle { get; set; }
        public int VehicleID { get; set; }

        public IEnumerable<BusStop> BusStops { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
