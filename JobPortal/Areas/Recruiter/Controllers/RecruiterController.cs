using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.Recruiter.Controllers
{
    public class RecruiterController : Controller
    {
        JobPortalDBContext db = new JobPortalDBContext();

        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                if (Session["UserRole"].ToString() == "recruiter")
                {
                    ViewBag.UserName = Session["UserName"];
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            else
            {
                ViewBag.UserName = "Recruiter";
                Session["UserName"] = "rec1";
                Session["UserRole"] = "recruiter";
                return View();
                //return RedirectToAction("Login", "Home", new { area = "" });
            }
        }

        public ActionResult RecruiterProfile()
        {
            string UserName = Session["UserName"].ToString();
            Company company = db.Companies.Single(c => c.username == UserName);
            return View(company);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Company company = db.Companies.Single(c => c.companyId == Id);
            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                Company companyToBeUpdated = db.Companies.Find(company.companyId);
                UpdateModel(companyToBeUpdated);
                db.SaveChanges();
                return RedirectToAction("RecruiterProfile");
            }
            return View();
        }

        public ActionResult SignOut()
        {
            Session["UserName"] = null;
            Session["UserRole"] = null;
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}