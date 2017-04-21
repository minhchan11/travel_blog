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
    public class JointController : Controller
    {
        private TravelContext db = new TravelContext();
        public IActionResult Index()
        {
            ViewBag.personId = new SelectList(db.NewPersons, "personId", "name");
            ViewBag.thingId = new SelectList(db.NewThings, "thingId", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Index(ThingPerson joint)
        {
            db.ThingsPersons.Add(joint);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
