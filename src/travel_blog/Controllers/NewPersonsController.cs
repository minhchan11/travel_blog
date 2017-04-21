using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using travel_blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace travel_blog.Controllers
{
    public class NewPersons : Controller
    {
        private TravelContext db = new TravelContext();
        public IActionResult Index()
        {

            return View(db.NewPersons.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPerson = db.NewPersons
                .Include(persons => persons.ThingsPersons)
                .ThenInclude(thingspersons => thingspersons.NewThing)
                 // .ThenInclude(experience => experience.Place) if want to include more object
                 .Where(persons => persons.personId == id).ToList()
                 .FirstOrDefault(persons => persons.personId == id);
            return View(thisPerson);
        }

    }
}
