using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using JobPortal.Models;
using System.Web.Script.Serialization;

namespace JobPortal.Areas.JobSeeker.Controllers
{
    public class JobSeekerController : Controller
    {
        JobPortalDBContext db = new JobPortalDBContext();

        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                if (Session["UserRole"].ToString() == "jobseeker")
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

        public ActionResult ViewEducation(int candidateId)
        {
            CandidateEducation candidate = db.CandidateEducation.Single(c => c.candidateId == candidateId);
            return View(candidate);
        }

        [HttpGet]
        public ActionResult EditEducation(int candidateId)
        {
            CandidateEducation candidate = db.CandidateEducation.Single(c => c.candidateId == candidateId);
            return View(candidate);
        }
        [HttpPost]
        public ActionResult EditEducation(CandidateEducation candidate)
        {
            if (ModelState.IsValid)
            {
                CandidateEducation candidateToBeUpdated = db.CandidateEducation.Find(candidate.candidateEduId);
                UpdateModel(candidateToBeUpdated);
                db.SaveChanges();
                return RedirectToAction("ViewEducation", new { candidateId = candidate.candidateId });
            }
            return View();
        }


        public ActionResult ExperienceList(int candidateId)
        {
            var candidateExp = db.CandidateProfessional.Where(c => c.candidateId == candidateId);
            return View(candidateExp.ToList());
        }

        public ActionResult ExperienceDetail(int candidateId)
        {
            CandidateProfessional candidate = db.CandidateProfessional.Single(c => c.candidateId == candidateId);
            Area area = db.Areas.Single(a => a.area_id == candidate.areaId);
            ViewBag.Area = area.area_name;
            return View(candidate);
        }

        //[HttpGet]
        //public ActionResult ExperienceDelete(int id)
        //{
        //    CandidateProfessional candidate = db.CandidateProfessional.Find(id);
        //    Area area = db.Areas.Single(a => a.area_id == candidate.areaId);
        //    ViewBag.Area = area.area_name;
        //    return View(candidate);
        //}

        //[HttpPost, ActionName("ExperienceDelete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExperienceDeleteConfirmed(int id)
        //{
        //    CandidateProfessional candidate = db.CandidateProfessional.Find(id);
        //    db.CandidateProfessional.Remove(candidate);
        //    db.SaveChanges();
        //    return RedirectToAction("ExperienceList", new { candidateId = candidate.candidateId });
        //}

        [HttpPost]
        public string GetArea(string categoryId)
        {
            int catId;
            catId = Convert.ToInt32(categoryId);
            var areaList = db.Areas.Where(a => a.category_id == catId).Select(x => new { areaId = x.area_id, areaName = x.area_name }).ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string areaJSON = js.Serialize(areaList);
            return areaJSON;
        }

        [HttpGet]
        public ActionResult ExperienceEdit(int candidateId)
        {
            var candidate = db.CandidateProfessional.Single(c => c.candidateId == candidateId);
            var selectedIndustry = db.Categories.Single(cat => cat.category_name == candidate.industry);
            candidate.industry = selectedIndustry.category_id.ToString();
            ViewBag.industry = new SelectList(db.Categories, "category_id", "category_name", candidate.industry);
            ViewBag.areaId = new SelectList(db.Areas, "area_id", "area_name", candidate.areaId);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult ExperienceEdit(CandidateProfessional canditate)
        {
            if (ModelState.IsValid)
            {
                int catId;
                catId = Convert.ToInt32(canditate.industry);
                var selectedIndustry = db.Categories.Single(i => i.category_id == catId);
                canditate.industry = selectedIndustry.category_name;
                db.Entry(canditate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ExperienceDetail", new { candidateId = canditate.candidateId });
            }
            ViewBag.industry = new SelectList(db.Categories, "category_id", "category_name");
            ViewBag.areaId = new SelectList(db.Areas, "area_id", "area_name");
            return View();
        }

        //[HttpGet]
        //public ActionResult NewExperience()
        //{
        //    string UserName = Session["UserName"].ToString();
        //    CandidateBasic candidateBasic = db.CandidateBasic.Single(c => c.username == UserName);
        //    ViewBag.CandidateId = candidateBasic.candidateId;
        //    ViewBag.industry = new SelectList(db.Categories, "category_id", "category_name");
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult NewExperience(CandidateProfessional canditate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string UserName = Session["UserName"].ToString();
        //        CandidateBasic candidateBasic = db.CandidateBasic.Single(c => c.username == UserName);
        //        canditate.candidateId = candidateBasic.candidateId;
        //        int catId;
        //        catId = Convert.ToInt32(canditate.industry);
        //        var selectedIndustry = db.Categories.Single(i => i.category_id == catId);
        //        canditate.industry = selectedIndustry.category_name;
        //        db.CandidateProfessional.Add(canditate);
        //        db.SaveChanges();

        //        return RedirectToAction("ExperienceList", new { candidateId = canditate.candidateId });
        //    }

        //    ViewBag.industry = new SelectList(db.Categories, "category_id", "category_name");
        //    return View();
        //}

        public ActionResult JobSeekerProfile()
        {
            string UserName = Session["UserName"].ToString();
            CandidateBasic candidateBasic = new CandidateBasic();
            candidateBasic = db.CandidateBasic.Single(c => c.username == UserName);
            return View(candidateBasic);
        }


        [HttpGet]
        public ActionResult EditProfile(int candidateId)
        {
            CandidateBasic candidate = db.CandidateBasic.Single(c => c.candidateId == candidateId);
            return View(candidate);
        }

        [HttpPost]
        public ActionResult EditProfile(CandidateBasic candidate)
        {
            if (ModelState.IsValid)
            {
                CandidateBasic candidateToBeUpdated = db.CandidateBasic.Find(candidate.candidateId);
                UpdateModel(candidateToBeUpdated);
                db.SaveChanges();
                return RedirectToAction("JobSeekerProfile");
            }
            return View();
        }

        [HttpGet]
        public ActionResult UploadResume()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadResume(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension.ToLower() == ".doc" || fileExtension.ToLower() == ".docx" ||
                        fileExtension.ToLower() == ".pdf")
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _Path = Path.Combine(Server.MapPath("~/Resumes"), _FileName);
                        file.SaveAs(_Path);
                        ViewBag.Message = "Resume uploaded successfully!!";
                        CandidateBasic cb = new CandidateBasic();
                        string currentUser = Session["UserName"].ToString();
                        cb = db.CandidateBasic.Single(c => c.username == currentUser);
                        if (!string.IsNullOrEmpty(cb.resumePath))
                        {
                            if (System.IO.File.Exists(Server.MapPath(cb.resumePath)))
                            {
                                System.IO.File.Delete(Server.MapPath(cb.resumePath));
                            }
                        }
                        cb.resumePath = "~/Resumes/" + _FileName;
                        db.Entry(cb).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Message = "Only doc, docx or pdf allowed";
                    }
                }
                else
                {
                    ViewBag.Message = "Upload failed";
                }
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