using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace travel_blog.Models
{
    [Table("things")]
    public class Thing
    {
        public Thing()
        {
        this.Persons = new HashSet<Person>();
        }

        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public virtual Location Location { get; set; }

    }
}
