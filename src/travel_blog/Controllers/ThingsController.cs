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
            var thisThing = db.Things.Include(things => things.Persons).Include(things => things.Location).FirstOrDefault(things => things.thingId == id);
            return View(thisThing);
        }

        public IActionResult Create()
        {
            ViewBag.locations = new SelectList(db.Locations, "id", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Thing thing)
        {
            db.Things.Add(thing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisThing = db.Things.FirstOrDefault(things => things.thingId == id);
            return View(thisThing);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisThing = db.Things.FirstOrDefault(things => things.thingId == id);
            db.Things.Remove(thisThing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         public IActionResult Edit(int id)
        {
            ViewBag.locations = new SelectList(db.Locations, "id", "name");
            var thisThing = db.Things.FirstOrDefault(things => things.thingId == id);
            return View(thisThing);
        }

        [HttpPost]
        public IActionResult Edit(Thing thing)
        {
            db.Entry(thing).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
