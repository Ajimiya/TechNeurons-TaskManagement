using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagementProject.Models;

namespace TaskManagementProject.Controllers
{
    public class AdminsController : Controller
    {
        private TaskDbEntities db = new TaskDbEntities();

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin a)
        {
            int logVar = db.Admins.Where(x => x.Name == a.Name && x.Password == a.Password).Count();


            if (logVar > 0)
            {
                Session["IsLoggedIn"] = true;
                return RedirectToAction("Dashboard", "Admins");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
                return View();
            }

        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
