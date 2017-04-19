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
    public class Persons : Controller
    {
        private TravelContext db = new TravelContext();
        public IActionResult Index()
        {

            return View(db.Persons.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPerson = db.Persons.Include(persons => persons.Thing).FirstOrDefault(persons => persons.id == id);
            return View(thisPerson);
        }

        public IActionResult Create()
        {
            ViewBag.things = new SelectList(db.Things, "id", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(persons => persons.id == id);
            return View(thisPerson);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(persons => persons.id == id);
            db.Persons.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.things = new SelectList(db.Things, "id", "name");
            var thisPerson = db.Persons.FirstOrDefault(persons => persons.id == id);
            return View(thisPerson);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
