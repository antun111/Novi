using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonskiImenik.Models;

namespace TelefonskiImenik.Controllers
{
    public class OsobeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Osobe
        public ActionResult Index()
        {
            List<Osoba> iOsobe = (from k in _db.Osobe where k.Aktivan select k).ToList();
            return View(iOsobe);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = _db.Osobe.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _db.Osobe.Add(osoba);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osoba);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = _db.Osobe.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }
        [HttpPost]
        public ActionResult Edit(Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(osoba).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osoba);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoba osoba = _db.Osobe.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Osoba osoba = _db.Osobe.Find(id);
            _db.Osobe.Remove(osoba);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}