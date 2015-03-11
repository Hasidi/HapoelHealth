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
    public class PatientsPermanentDrugsController : Controller
    {
        private HealthServicesContext db = new HealthServicesContext();

        //
        // GET: /PatientsPermanentDrugs/

        public ActionResult Index()
        {
            var patientsdrugs = db.PatientsPermanentDrugs.Include(p => p.Patients).Include(p => p.Drugs);
            return View(patientsdrugs.ToList());
        }

        //
        // GET: /PatientsPermanentDrugs/Details/5

        public ActionResult Details(int id = 0, int drug_id = 0)
        {
            PatientPermanentDrugs patientpermanentdrugs = db.PatientsPermanentDrugs.Find(id, drug_id);
            if (patientpermanentdrugs == null)
            {
                return HttpNotFound();
            }
            return View(patientpermanentdrugs);
        }

        //
        // GET: /PatientsPermanentDrugs/Create

        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Patients, "ID", "ID");
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name");
            return View();
        }

        //
        // POST: /PatientsPermanentDrugs/Create

        [HttpPost]
        public ActionResult Create(PatientPermanentDrugs patientpermanentdrugs)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    string doc = User.Identity.Name;

                    Perscription perscription = addToPerscripsiotns(int.Parse(doc), patientpermanentdrugs.ID, patientpermanentdrugs.drug_ID);
                    TempData["perscription"] = perscription;
                    TempData["patientpermanentdrugs"] = patientpermanentdrugs;
                    return RedirectToAction("CreateFroPermanentDrugs", "Perscriptions");
                    
                    /*
                    ViewBag.patientID = perscription.patientID;
                    ViewBag.therapistID = perscription.therapistID;
                    ViewBag.drug_ID = perscription.drug_ID;
                    ViewBag.date = perscription.date;
                    return Redirect("../Perscriptions/CreateFroPermanentDrugs");
                   */
                    /*
                    db.PatientsPermanentDrugs.Add(patientpermanentdrugs);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");*/
                }
                ViewBag.ID = new SelectList(db.GeneralEmployees, "ID", "f_name", patientpermanentdrugs.ID);
                ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", patientpermanentdrugs.drug_ID);
                ViewBag.error = "please log in as doc first";
                ModelState.AddModelError("CustomError", "Please identify first as Doctor, go to Log in screen");
                return View(patientpermanentdrugs);

            }

            ViewBag.ID = new SelectList(db.GeneralEmployees, "ID", "f_name", patientpermanentdrugs.ID);
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", patientpermanentdrugs.drug_ID);
            return View(patientpermanentdrugs);
        }

        //
        // GET: /PatientsPermanentDrugs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PatientPermanentDrugs patientpermanentdrugs = db.PatientsPermanentDrugs.Find(id);
            if (patientpermanentdrugs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.GeneralEmployees, "ID", "f_name", patientpermanentdrugs.ID);
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", patientpermanentdrugs.drug_ID);
            return View(patientpermanentdrugs);
        }

        //
        // POST: /PatientsPermanentDrugs/Edit/5

        [HttpPost]
        public ActionResult Edit(PatientPermanentDrugs patientpermanentdrugs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientpermanentdrugs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.GeneralEmployees, "ID", "f_name", patientpermanentdrugs.ID);
            ViewBag.drug_ID = new SelectList(db.Drugs, "drug_ID", "drug_name", patientpermanentdrugs.drug_ID);
            return View(patientpermanentdrugs);
        }

        //
        // GET: /PatientsPermanentDrugs/Delete/5

        public ActionResult Delete(int id = 0, int drug_ID= 0)
        {
            PatientPermanentDrugs patientpermanentdrugs = db.PatientsPermanentDrugs.Find(id, drug_ID);
            if (patientpermanentdrugs == null)
            {
                return HttpNotFound();
            }
            return View(patientpermanentdrugs);
        }

        //
        // POST: /PatientsPermanentDrugs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientPermanentDrugs patientpermanentdrugs = db.PatientsPermanentDrugs.Find(id);
            db.PatientsPermanentDrugs.Remove(patientpermanentdrugs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        private Perscription addToPerscripsiotns(int docID, int patientID, int drugID)
        {
            PerscriptionsController pc = new PerscriptionsController();
            Perscription per = new Perscription();
            per.drug_ID = drugID; per.patientID = patientID; per.therapistID = docID;
            per.date = DateTime.Now.Date;
            per.dosage = 0;
            per.expiration_date = DateTime.Now.Date;

            return per;

            //pc.CreateFroPermanentDrugs(per);

        }

    }
}