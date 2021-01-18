using Polyclinic_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polyclinic_project.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        PolyclinicContext db = new PolyclinicContext();

        public ActionResult Index()
        {

            ViewBag.city = db.City.ToList();
            

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Polyclinics Polyclinic)
        {
          
            db.Polyclinic.Add(Polyclinic);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}