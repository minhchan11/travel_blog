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
    public class NewThings : Controller
    {
      private TravelContext db = new TravelContext();
      public IActionResult Index()
      {

          return View(db.NewThings.ToList());
      }

      public IActionResult Details(int id)
      {
            var thisThing = db.NewThings.Include(things => things.ThingsPersons)
                .ThenInclude(thingspersons => thingspersons.NewPerson)
                .Where(things => things.thingId == id).ToList()
                .FirstOrDefault(things => things.thingId == id);
          return View(thisThing);
      }
    }
}
