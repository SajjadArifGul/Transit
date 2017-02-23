using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transit.Commons;

namespace Transit.Web.Models
{
    public class PageViewModel
    {
        public string Title { get; set; }
        public List<Link> BreadCrumbs { get; set; }
        public bool BreadCrumbsExternal { get; set; }
        public string BreadCrumbsExternalLink { get; set; }
    }
}