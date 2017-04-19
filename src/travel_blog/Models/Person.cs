using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace travel_blog.Models
{
    [Table("persons")]
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int thingId { get; set;}
        public virtual Thing Thing { get; set; }
    }
}
