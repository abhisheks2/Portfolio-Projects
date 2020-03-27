using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.Recruiter.Controllers
{
    public class JobPostsController : Controller
    {
        private JobPortalDBContext db = new JobPortalDBContext();

        // GET: Recruiter/JobPosts
        public ActionResult Index()
        {
            string UserName = Session["UserName"].ToString();
            Company company = db.Companies.Single(c => c.username == UserName);
            var jobPosts = db.JobPosts.Where(p => p.companyId == company.companyId).Include(j => j.Area).Include(j => j.Category).Include(j => j.JobTitle);
            return View(jobPosts.ToList());
        }

        // GET: Recruiter/JobPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: Recruiter/JobPosts/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        // POST: Recruiter/JobPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobPostId,categoryId,areaid,companyId,jobTitleId,type,location,postedDate,skillsReq,educationReq,description,contactEmail,salary,isAvailable")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                string UserName = Session["UserName"].ToString();
                Company company = db.Companies.Single(c => c.username == UserName);
                jobPost.companyId = company.companyId;
                jobPost.postedDate = System.DateTime.Now;
                jobPost.type = Enum.GetName(typeof(JobType), Convert.ToInt32(jobPost.type));
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.Categories, "category_id", "category_name", jobPost.categoryId);
            return View(jobPost);
        }

        // GET: Recruiter/JobPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.areaid = new SelectList(db.Areas, "area_id", "area_name", jobPost.areaid);
            ViewBag.categoryId = new SelectList(db.Categories, "category_id", "category_name", jobPost.categoryId);
            ViewBag.jobTitleId = new SelectList(db.JobTitles, "jobtitleId", "jobtitleName", jobPost.jobTitleId);
            return View(jobPost);
        }

        // POST: Recruiter/JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobPostId,categoryId,areaid,companyId,jobTitleId,type,location,postedDate,skillsReq,educationReq,description,contactEmail,salary,isAvailable")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.areaid = new SelectList(db.Areas, "area_id", "area_name", jobPost.areaid);
            ViewBag.categoryId = new SelectList(db.Categories, "category_id", "category_name", jobPost.categoryId);
            ViewBag.jobTitleId = new SelectList(db.JobTitles, "jobtitleId", "jobtitleName", jobPost.jobTitleId);
            return View(jobPost);
        }

        // GET: Recruiter/JobPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: Recruiter/JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
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
