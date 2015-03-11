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
    public class PerscriptionsController : Controller
    {
        private HealthServicesContext db = new HealthServicesContext();

        private static bool _per_build = false;
        private static Perscription PERSCRIPTION;
        private static PatientPermanentDrugs PATIENT_PERMANENT_DRUG;

        //
        // GET: /Perscriptions/

        public ActionResult Index()
        {
            var perscriptions = db.Perscriptions.Include(p => p.Patients).Include(p => p.Therapists).Include(p => p.Drugs);
            return View(perscriptions.ToList());
        }

        //
        // GET: /Perscriptions/Details/5

        public ActionResult Details(int id = 0)
        {
            Perscription perscription = db.Perscriptions.Find(id);
            if (perscription == null)
            {
                return HttpNotFound();
            }
            return View(perscription);
        }

        //
        // GET: /Perscriptions/Create

        public ActionResult Create()
        {
            ViewBag.patientID = new SelectList(db.Patients, "ID", "f_name");
            ViewBag.therapistID = new SelectList(db.Therapists, "ID", "f_name");
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name");
            return View();
        }

        //
        // POST: /Perscriptions/Create

        [HttpPost]
        public ActionResult Create(Perscription perscription)
        {
            if (ModelState.IsValid)
            {
                db.Perscriptions.Add(perscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.patientID = new SelectList(db.Patients, "ID", "f_name", perscription.patientID);
            ViewBag.therapistID = new SelectList(db.Therapists, "ID", "f_name", perscription.therapistID);
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", perscription.drug_ID);
            return View(perscription);
        }



        //--------------------------------------------------------------------------------------------------------

        public ActionResult CreateFroPermanentDrugs(Perscription perscription)
        {
            if (_per_build)
            {
                if (ModelState.IsValid)
                {
                    if (PATIENT_PERMANENT_DRUG == null)
                        PATIENT_PERMANENT_DRUG = (PatientPermanentDrugs)TempData["patientPermanentDrugs"];
                    PERSCRIPTION.expiration_date = perscription.expiration_date;
                    PERSCRIPTION.dosage = perscription.dosage;
                    PERSCRIPTION.was_printed = perscription.was_printed;
                    if (PERSCRIPTION.expiration_date < PERSCRIPTION.date)
                    {
                        perscription.drug_ID = PERSCRIPTION.drug_ID;
                        perscription.patientID = PERSCRIPTION.patientID;
                        perscription.therapistID = PERSCRIPTION.therapistID;
                        perscription.date = PERSCRIPTION.date;
                        ViewBag.patientID = PERSCRIPTION.patientID;
                        ViewBag.therapistID = PERSCRIPTION.therapistID;
                        ViewBag.drug_ID = PERSCRIPTION.drug_ID;
                        ViewBag.date = PERSCRIPTION.date;
                        ViewBag.error = "expiration_date must be greater than  curr date";
                        ModelState.AddModelError("dateError", "expiration_date must be greater than  curr date");
                        return View();
                    }
                    //Perscription perModel = (Perscription)TempData["perscription"];

                    db.Perscriptions.Add(PERSCRIPTION);
                    _per_build = false;
                    db.PatientsPermanentDrugs.Add(PATIENT_PERMANENT_DRUG);
                    db.SaveChanges();
                    
                    
                }
                return RedirectToAction("Index");
            }
            else
            {

                PERSCRIPTION = (Perscription)TempData["perscription"];

                ViewBag.patientID = PERSCRIPTION.patientID;
                ViewBag.therapistID = PERSCRIPTION.therapistID;
                ViewBag.drug_ID = PERSCRIPTION.drug_ID;
                ViewBag.date = PERSCRIPTION.date;
                /*
                perscription.expiration_date = DateTime.Now.Date;
                perscription.dosage = 2323;*/
                _per_build = true;
                return View();
            }

            
        }
        //--------------------------------------------------------------------------------------------------------

        //
        // GET: /Perscriptions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Perscription perscription = db.Perscriptions.Find(id);
            if (perscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.patientID = new SelectList(db.Patients, "ID", "f_name", perscription.patientID);
            ViewBag.therapistID = new SelectList(db.Therapists, "ID", "f_name", perscription.therapistID);
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", perscription.drug_ID);
            return View(perscription);
        }

        //
        // POST: /Perscriptions/Edit/5

        [HttpPost]
        public ActionResult Edit(Perscription perscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.patientID = new SelectList(db.Patients, "ID", "f_name", perscription.patientID);
            ViewBag.therapistID = new SelectList(db.Therapists, "ID", "f_name", perscription.therapistID);
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", perscription.drug_ID);
            return View(perscription);
        }

        //
        // GET: /Perscriptions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Perscription perscription = db.Perscriptions.Find(id);
            if (perscription == null)
            {
                return HttpNotFound();
            }
            return View(perscription);
        }

        //
        // POST: /Perscriptions/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Perscription perscription = db.Perscriptions.Find(id);
            db.Perscriptions.Remove(perscription);
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