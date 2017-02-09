using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transit.Entities
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public City City { get; set; }
        public int CityID { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
