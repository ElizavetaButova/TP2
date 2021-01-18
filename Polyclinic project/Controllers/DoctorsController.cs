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
    public class DoctorsController : Controller
    {
        private PolyclinicContext db = new PolyclinicContext();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctor = db.Doctor.Include(d => d.Department);
            return View(doctor.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctor.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.Dep_num = new SelectList(db.Department, "Dep_num", "Dep_name");
            return View();
        }

        // POST: Doctors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Doc_id,Dep_num,Doc_fnln,Doc_spec,Doc_office")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Doctor.Add(doctors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dep_num = new SelectList(db.Department, "Dep_num", "Dep_name", doctors.Dep_num);
            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctor.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dep_num = new SelectList(db.Department, "Dep_num", "Dep_name", doctors.Dep_num);
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Doc_id,Dep_num,Doc_fnln,Doc_spec,Doc_office")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dep_num = new SelectList(db.Department, "Dep_num", "Dep_name", doctors.Dep_num);
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctor.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctors doctors = db.Doctor.Find(id);
            db.Doctor.Remove(doctors);
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
