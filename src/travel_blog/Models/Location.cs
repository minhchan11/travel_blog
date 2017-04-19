using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace travel_blog.Models
{
    [Table("locations")]
    public class Location
    {
        public Location()
        {
            this.Things = new HashSet<Thing>();
        }

        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Thing> Things { get; set; }
    }
}
