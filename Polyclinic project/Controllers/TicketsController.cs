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
    public class TicketsController : Controller
    {
        private PolyclinicContext db = new PolyclinicContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var ticket = db.Ticket.Include(t => t.Doctor).Include(t => t.Patient).Include(t => t.Reception);
            return View(ticket.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Ticket.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.Doc_id = new SelectList(db.Doctor, "Doc_id", "Doc_fnln");
            ViewBag.Medcard_num = new SelectList(db.Patient, "Medcard_num", "Pat_fnln");
            ViewBag.App_time = new SelectList(db.Reception, "App_time", "App_time");
            return View();
        }

        // POST: Tickets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tick_num,Doc_id,App_time,pat_fnln,Medcard_num")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(tickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doc_id = new SelectList(db.Doctor, "Doc_id", "Doc_fnln", tickets.Doc_id);
            ViewBag.Medcard_num = new SelectList(db.Patient, "Medcard_num", "Pat_fnln", tickets.Medcard_num);
            ViewBag.App_time = new SelectList(db.Reception, "App_time", "App_time", tickets.App_time);
            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Ticket.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doc_id = new SelectList(db.Doctor, "Doc_id", "Doc_fnln", tickets.Doc_id);
            ViewBag.Medcard_num = new SelectList(db.Patient, "Medcard_num", "Pat_fnln", tickets.Medcard_num);
            ViewBag.App_time = new SelectList(db.Reception, "App_time", "App_time", tickets.App_time);
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tick_num,Doc_id,App_time,pat_fnln,Medcard_num")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doc_id = new SelectList(db.Doctor, "Doc_id", "Doc_fnln", tickets.Doc_id);
            ViewBag.Medcard_num = new SelectList(db.Patient, "Medcard_num", "Pat_fnln", tickets.Medcard_num);
            ViewBag.App_time = new SelectList(db.Reception, "App_time", "App_time", tickets.App_time);
            return View(tickets);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Ticket.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tickets tickets = db.Ticket.Find(id);
            db.Ticket.Remove(tickets);
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
