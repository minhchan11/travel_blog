using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_blog.Models
{
  [Table("ThingsPersons")]
    public class ThingPerson
    {
      [Key]
        public int personId { get; set; }
        public virtual NewPerson NewPerson { get; set; }

        public int thingId { get; set; }
        public virtual NewThing NewThing { get; set; }
    }
}
