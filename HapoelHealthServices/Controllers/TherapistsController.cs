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
    public class TherapistsController : Controller
    {
        private HealthServicesContext db = new HealthServicesContext();

        //
        // GET: /Therapists/

        public ActionResult Index()
        {
            return View(db.Therapists.ToList());
        }

        //
        // GET: /Therapists/Details/5

        public ActionResult Details(int id = 0)
        {
            Therapist therapist = db.Therapists.Find(id);
            if (therapist == null)
            {
                return HttpNotFound();
            }
            return View(therapist);
        }

        //
        // GET: /Therapists/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Therapists/Create

        [HttpPost]
        public ActionResult Create(Therapist therapist)
        {
            if (ModelState.IsValid)
            {
                db.Therapists.Add(therapist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(therapist);
        }

        //
        // GET: /Therapists/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Therapist therapist = db.Therapists.Find(id);
            if (therapist == null)
            {
                return HttpNotFound();
            }
            return View(therapist);
        }

        //
        // POST: /Therapists/Edit/5

        [HttpPost]
        public ActionResult Edit(Therapist therapist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(therapist);
        }

        //
        // GET: /Therapists/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Therapist therapist = db.Therapists.Find(id);
            if (therapist == null)
            {
                return HttpNotFound();
            }
            return View(therapist);
        }

        //
        // POST: /Therapists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Therapist therapist = db.Therapists.Find(id);
            db.Therapists.Remove(therapist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult TherapistSearch(string specialization, string therapistString)
        {
            var specList = new List<string>();

            var specQry = from d in db.Therapists
                          orderby d.specialization
                          select d.specialization;
            specList.AddRange(specQry.Distinct());
            ViewBag.specialization = new SelectList(specList);

            var therapists = from m in db.Therapists
                             select m;

            if (!String.IsNullOrEmpty(therapistString))
            {
                therapists = therapists.Where(s => s.f_name.Contains(therapistString) || s.l_name.Contains(therapistString));
            }

            if (string.IsNullOrEmpty(specialization))
                return View(therapists);
            else
            {
                return View(therapists.Where(x => x.specialization == specialization));
            }

        }

    }
}