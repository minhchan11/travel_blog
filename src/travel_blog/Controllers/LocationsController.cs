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
    public class Locations : Controller
    {
        private TravelContext db = new TravelContext();
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public IActionResult Details(int id)
        {
          var thisLocation = db.Locations.Include(locations => locations.Things).FirstOrDefault(locations => locations.id == id);
          return View(thisLocation);
        }

        public IActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public IActionResult Create (Location location)
        {
          db.Locations.Add(location);
          db.SaveChanges();
          return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
          var thisLocation = db.Locations.Include(locations => locations.Things).FirstOrDefault(locations => locations.id == id);
          return View(thisLocation);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
          db.Entry(location).State = EntityState.Modified;
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
          var thisLocation = db.Locations.Include(locations => locations.Things).FirstOrDefault(locations => locations.id == id);
          return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
          var thisLocation = db.Locations.Include(locations => locations.Things).FirstOrDefault(locations => locations.id == id);
          db.Locations.Remove(thisLocation);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
    }
}
