using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transit.Web.Models
{
    public class CitiesViewModel : PageViewModel
    {
        public List<CityViewModel> Cities { get; set; }
    }

    public class CityViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string CountryName { get; set; }
        public int CountryID { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}