using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HapoelHealthServices.Models;
using HapoelHealthServices.DAL;

namespace HapoelHealthServices.Controllers
{
    public class DrugsController : Controller
    {
        private HealthServicesContext db = new HealthServicesContext();

        //
        // GET: /Drugs/

        public ActionResult Index()
        {
            return View(db.Drugs.ToList());
        }

        //
        // GET: /Drugs/Details/5

        public ActionResult Details(int id = 0)
        {
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        //
        // GET: /Drugs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Drugs/Create

        [HttpPost]
        public ActionResult Create(Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Drugs.Add(drug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drug);
        }

        //
        // GET: /Drugs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        //
        // POST: /Drugs/Edit/5

        [HttpPost]
        public ActionResult Edit(Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drug);
        }

        //
        // GET: /Drugs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        //
        // POST: /Drugs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug drug = db.Drugs.Find(id);
            db.Drugs.Remove(drug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}