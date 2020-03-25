using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        JobPortalDBContext db = new JobPortalDBContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                if (Session["UserRole"].ToString() == "admin")
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
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }

        public JsonResult IsUserNameAvailable(string UserName)
        {
            return Json(!db.Users.Any(x => x.username == UserName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOut()
        {
            Session["UserName"] = null;
            Session["UserRole"] = null;
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}