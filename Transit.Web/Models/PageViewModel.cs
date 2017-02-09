using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transit.Web.Models
{
    public class PageViewModel
    {
        public string Title { get; set; }

        public List<string> BreadCrumbs { get; set; }
    }
}