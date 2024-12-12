using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Chef
    {
        public int ChefId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<ChefSocial> ChefSocials { get; set; }
    }
}