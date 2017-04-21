using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using travel_blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace travel_blog.Controllers
{
    public class Things : Controller
    {
        private TravelContext db = new TravelContext();
        public IActionResult Index()
        {

            return View(db.Things.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisThing = db.Things.Include(things => things.Persons).Include(things => things.Location).FirstOrDefault(things => things.id == id);
            return View(thisThing);
        }

    }
}
