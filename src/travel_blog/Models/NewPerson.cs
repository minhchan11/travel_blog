using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travel_blog.Models
{
    [Table("NewPersons")]
    public class NewPerson
    {
        [Key]
        public int personId { get; set; }
        public string name { get; set; }

        public ICollection<ThingPerson> ThingsPersons { get; set; }
    }
}
