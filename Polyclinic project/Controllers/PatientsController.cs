using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Polyclinic_project.Models;

namespace Polyclinic_project
{
    public class PatientsController : Controller
    {
        private PolyclinicContext db = new PolyclinicContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patient.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patient.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medcard_num,Pat_fnln,Age,Address,Phone,Insur_num,Passport")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                db.Patient.Add(patients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patients);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patient.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medcard_num,Pat_fnln,Age,Address,Phone,Insur_num,Passport")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patient.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patients patients = db.Patient.Find(id);
            db.Patient.Remove(patients);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
