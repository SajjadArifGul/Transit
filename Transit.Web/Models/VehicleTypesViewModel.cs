using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transit.Web.Models
{
    public class VehicleTypesViewModel : PageViewModel
    {
        public List<VehicleTypeViewModel> VehicleTypes { get; set; }
    }

    public class VehicleTypeViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}