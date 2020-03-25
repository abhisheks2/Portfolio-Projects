using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.Admin.Controllers
{
    public class JobTitlesController : Controller
    {
        private JobPortalDBContext db = new JobPortalDBContext();

        // GET: Admin/JobTitles
        public ActionResult Index()
        {
            var jobTitles = db.JobTitles.Include(j => j.Area).Include(j => j.Category);
            return View(jobTitles.ToList());
        }

        // GET: Admin/JobTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitle jobTitle = db.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return HttpNotFound();
            }
            return View(jobTitle);
        }

        // GET: Admin/JobTitles/Create
        public ActionResult Create()
        {
            //ViewBag.jobtitleAreaID = new SelectList(db.Areas, "area_id", "area_name");
            ViewBag.jobtitleCategoryId = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        // POST: Admin/JobTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobtitleId,jobtitleName,jobtitleAreaID,jobtitleCategoryId")] JobTitle jobTitle)
        {
            if (ModelState.IsValid)
            {
                db.JobTitles.Add(jobTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobtitleAreaID = new SelectList(db.Areas, "area_id", "area_name", jobTitle.jobtitleAreaID);
            ViewBag.jobtitleCategoryId = new SelectList(db.Categories, "category_id", "category_name", jobTitle.jobtitleCategoryId);
            return View(jobTitle);
        }

        // GET: Admin/JobTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitle jobTitle = db.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return HttpNotFound();
            }
            //ViewBag.jobtitleAreaID = new SelectList(db.Areas, "area_id", "area_name", jobTitle.jobtitleAreaID);
            ViewBag.jobtitleCategoryId = new SelectList(db.Categories, "category_id", "category_name", jobTitle.jobtitleCategoryId);
            return View(jobTitle);
        }

        // POST: Admin/JobTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobtitleId,jobtitleName,jobtitleAreaID,jobtitleCategoryId")] JobTitle jobTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobtitleAreaID = new SelectList(db.Areas, "area_id", "area_name", jobTitle.jobtitleAreaID);
            ViewBag.jobtitleCategoryId = new SelectList(db.Categories, "category_id", "category_name", jobTitle.jobtitleCategoryId);
            return View(jobTitle);
        }

        // GET: Admin/JobTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitle jobTitle = db.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return HttpNotFound();
            }
            return View(jobTitle);
        }

        // POST: Admin/JobTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobTitle jobTitle = db.JobTitles.Find(id);
            db.JobTitles.Remove(jobTitle);
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
