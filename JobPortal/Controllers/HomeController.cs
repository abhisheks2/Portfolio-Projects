using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.Web.Script.Serialization;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        JobPortalDBContext db = new JobPortalDBContext();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User currentUser = db.Users.SingleOrDefault(user => user.username == username && user.password == password);
            if (currentUser != null)
            {
                Session["UserName"] = username;
                Session["UserRole"] = currentUser.role;
                switch (currentUser.role)
                {
                    case "recruiter":
                        return RedirectToAction("Index", "Recruiter", new { area = "Recruiter" });
                    case "jobseeker":
                        return RedirectToAction("Index", "JobSeeker", new { area = "JobSeeker" });
                    default:
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
            }
            else
            {
                ModelState.AddModelError("username", "Invalid credentials, please enter valid credentials");
                return View();
            }
        }

        public JsonResult IsUserNameAvailable(string UserName)
        {
            return Json(!db.Users.Any(x => x.username == UserName), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult NewRecruiter()
        {
            ViewBag.Question = new SelectList(db.Questions, "quesId", "ques");
            return View();
        }

        [HttpPost]
        public ActionResult NewRecruiter(Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                //insert into users - populate user fields
                User newUser = new User();
                newUser.username = recruiter.username;
                newUser.password = recruiter.password;
                newUser.role = "recruiter";
                db.Users.Add(newUser);

                //insert into Company - populate company fields
                Company newCompany = new Company();
                newCompany.companyName = recruiter.companyName;
                newCompany.companyAddr = recruiter.companyAddr;
                newCompany.companyContact = recruiter.companyContact;
                newCompany.contactPerson = recruiter.contactPerson;
                newCompany.companyEmail = recruiter.Email;
                newCompany.companyDetails = recruiter.companyDetails;
                newCompany.username = recruiter.username;
                newCompany.quesId = recruiter.Question;
                newCompany.ansr = recruiter.Answer;
                db.Companies.Add(newCompany);

                //commit changes to database
                db.SaveChanges();

                //store user name and role in session cookies and redirect to recruiter index page
                Session["UserName"] = recruiter.username;
                Session["UserRole"] = "recruiter";
                return RedirectToAction("Index", "Recruiter", new { area = "Recruiter" });
            }
            ViewBag.Question = new SelectList(db.Questions, "quesId", "ques");
            return View();
        }

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

        [HttpPost]
        public string GetJobTitle(string areaId)
        {
            int aId;
            aId = Convert.ToInt32(areaId);
            var jobtitleList = db.JobTitles.Where(j => j.jobtitleAreaID == aId).Select(x => new { jobtitleId = x.jobtitleId, jobtitleName = x.jobtitleName }).ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jobtitleJSON = js.Serialize(jobtitleList);
            return jobtitleJSON;
        }

        [HttpGet]
        public ActionResult NewJobSeeker()
        {
            ViewBag.Question = new SelectList(db.Questions, "quesId", "ques");
            ViewBag.industry = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        [HttpPost]
        public ActionResult NewJobSeeker(JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                //insert into users - populate user fields
                User newUser = new User();
                newUser.username = jobSeeker.username;
                newUser.password = jobSeeker.password;
                newUser.role = "jobseeker";
                db.Users.Add(newUser);
                db.SaveChanges();

                //insert into Candidate Basic
                CandidateBasic candidateBasic = new CandidateBasic();
                //code to copy data from jobSeeker to candidateBasic
                candidateBasic.username = jobSeeker.username;
                candidateBasic.quesId = jobSeeker.Question;
                candidateBasic.ansr = jobSeeker.Answer;
                candidateBasic.profileDate = System.DateTime.Now;
                candidateBasic.firstName = jobSeeker.firstName;
                candidateBasic.lastName = jobSeeker.lastName;
                candidateBasic.candidateAddr = jobSeeker.candidateAddr;
                candidateBasic.city = jobSeeker.city;
                candidateBasic.gender = jobSeeker.gender;
                candidateBasic.dob = jobSeeker.dob;
                candidateBasic.contactNo = jobSeeker.contactNo;
                candidateBasic.emailId = jobSeeker.emailId;
                db.CandidateBasic.Add(candidateBasic);
                int newCandidateId = candidateBasic.candidateId;

                //insert into Candidate Education
                CandidateEducation candidateEducation = new CandidateEducation();
                //code to copy data from jobSeeker to candidateEducation
                candidateEducation.candidateId = newCandidateId;
                candidateEducation.aLevelSubject1 = jobSeeker.aLevelSubject1;
                candidateEducation.aLevelSubject2 = jobSeeker.aLevelSubject2;
                candidateEducation.aLevelSubject3 = jobSeeker.aLevelSubject3;
                candidateEducation.aLevelGrade1 = jobSeeker.aLevelGrade1;
                candidateEducation.aLevelGrade2 = jobSeeker.aLevelGrade2;
                candidateEducation.aLevelGrade3 = jobSeeker.aLevelGrade3;
                candidateEducation.graduation = jobSeeker.graduation;
                candidateEducation.instituteGrad = jobSeeker.instituteGrad;
                candidateEducation.percentageGrad = jobSeeker.percentageGrad;
                candidateEducation.postGrad = jobSeeker.postGrad;
                candidateEducation.institutePostGrad = jobSeeker.institutePostGrad;
                candidateEducation.percentagePostGrad = jobSeeker.percentagePostGrad;
                candidateEducation.certification = jobSeeker.certification;
                db.CandidateEducation.Add(candidateEducation);

                //insert into Candidate Profiessional
                CandidateProfessional candidateProfessional = new CandidateProfessional();
                //code to copy data from jobSeeker to candidateProfessional
                candidateProfessional.candidateId = newCandidateId;
                int catId;
                catId = Convert.ToInt32(jobSeeker.industry);
                var selectedIndustry = db.Categories.Single(i => i.category_id == catId);
                candidateProfessional.industry = selectedIndustry.category_name;
                candidateProfessional.industryRole = jobSeeker.industryRole;
                candidateProfessional.skills = jobSeeker.skills;
                candidateProfessional.areaId = Convert.ToInt32(jobSeeker.Area);
                db.CandidateProfessional.Add(candidateProfessional);

                //commit changes to database
                db.SaveChanges();

                //store user name and role in session cookies and redirect to recruiter index page
                Session["UserName"] = jobSeeker.username;
                Session["UserRole"] = "jobseeker";
                return RedirectToAction("Index", "JobSeeker", new { area = "JobSeeker" });
            }

            ViewBag.Question = new SelectList(db.Questions, "quesId", "ques");
            ViewBag.industry = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        public ActionResult JobSearch()
        {
            HttpCookie myCookie = new HttpCookie("mycookie");
            myCookie.Value = "";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookie);

            HttpCookie myCookieLoc = new HttpCookie("mycookieLoc");
            myCookieLoc.Value = "";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookieLoc);

            HttpCookie myCookieInd = new HttpCookie("mycookieInd");
            myCookieInd.Value = "";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookieInd);
            return View();
        }

        public PartialViewResult DisplayJobs(string searchBy, string searchValue)
        {
            List<JobPost> model = new List<JobPost>();
            if (searchBy == "location")
            {
                model = db.JobPosts.Where(j => j.location == searchValue).OrderBy(x => x.postedDate).ToList();
                HttpCookie myCookieLoc = new HttpCookie("mycookieLoc");
                myCookieLoc.Value = searchValue;
                //myCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(myCookieLoc);
            }
            else if (searchBy == "industry")
            {
                int industry;
                int.TryParse(searchValue, out industry);
                model = db.JobPosts.Where(j => j.categoryId == industry).OrderBy(x => x.postedDate).ToList();
                HttpCookie myCookieInd = new HttpCookie("mycookieInd");
                myCookieInd.Value = searchValue;
                //myCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(myCookieInd);
            }
            return PartialView("_Jobs", model);
        }

        public PartialViewResult JobsByLocation()
        {
            List<DynamicActionLink> links = new List<DynamicActionLink>();
            var jobLocations = db.JobPosts.OrderBy(l => l.location).Select(x => x.location).Distinct().ToList();
            foreach (var joblocation in jobLocations)
            {
                DynamicActionLink link = new DynamicActionLink();
                link.LinkName = joblocation;
                link.LinkController = "Home";
                link.LinkAction = "DisplayJobs";
                link.LinkSearchBy = "location";
                link.LinkSearchValue = joblocation;
                links.Add(link);
            }

            return PartialView("_JobLinks", links);
        }

        public PartialViewResult JobsByIndustry()
        {
            List<DynamicActionLink> links = new List<DynamicActionLink>();
            var industries = db.Categories.OrderBy(c => c.category_name).ToList();
            foreach (var industry in industries)
            {
                DynamicActionLink link = new DynamicActionLink();
                link.LinkName = industry.category_name;
                link.LinkController = "Home";
                link.LinkAction = "DisplayJobs";
                link.LinkSearchBy = "industry";
                link.LinkSearchValue = industry.category_id.ToString();
                links.Add(link);
            }

            return PartialView("_JobLinks", links);
        }

        public ActionResult JobDetails(int id)
        {
            var job = db.JobPosts.Single(j => j.jobPostId == id);
            return View(job);
        }

        public PartialViewResult QuickSearch(string industry, string area1, string jobType, string location)
        {
            ViewBag.Industry = new SelectList(db.Categories.OrderBy(c => c.category_name), "category_id", "category_name", industry);
            ViewBag.Area = new SelectList(db.Areas.OrderBy(a => a.area_name), "area_id", "area_name", area1);
            ViewBag.JobType = new SelectList(Enum.GetNames(typeof(JobType)), jobType);
            ViewBag.Location = new SelectList(db.JobPosts.OrderBy(l => l.location).Select(x => x.location).Distinct().ToList(), location);
            return PartialView("_QuickSearch");
        }

        public PartialViewResult QuickSearchJobs(string Industry, string Area, string JobType, string Location)
        {
            int catId = 0;
            int aId = 0;
            if (!string.IsNullOrEmpty(Industry))
            {
                catId = Convert.ToInt32(Industry);
            }
            if (!string.IsNullOrEmpty(Area))
            {
                aId = Convert.ToInt32(Area);
            }

            var model = db.JobPosts.Where(j =>
                                (Industry == "" || j.categoryId == catId)
                            && (Area == "" || j.areaid == aId)
                            && (JobType == "" || j.type == JobType)
                            && (Location == "" || j.location == Location))
                            .ToList();

            HttpCookie myCookie = new HttpCookie("mycookie");
            myCookie.Value = Industry + "-" + Area + "-" + JobType + "-" + Location;
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookie);

            return PartialView("_Jobs", model);
        }
    }
}