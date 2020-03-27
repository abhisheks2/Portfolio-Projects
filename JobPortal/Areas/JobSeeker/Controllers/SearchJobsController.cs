using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.JobSeeker.Controllers
{
    public class SearchJobsController : Controller
    {
        JobPortalDBContext db = new JobPortalDBContext();

        public ActionResult JobSearch()
        {
            HttpCookie myCookie1 = new HttpCookie("mycookie1");
            myCookie1.Value = "";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookie1);

            HttpCookie myCookieLoc1 = new HttpCookie("mycookieLoc1");
            myCookieLoc1.Value = "";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookieLoc1);

            HttpCookie myCookieInd1 = new HttpCookie("mycookieInd1");
            myCookieInd1.Value = "";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookieInd1);

            return View();
        }

        public PartialViewResult DisplayJobs(string searchBy, string searchValue)
        {
            List<JobPost> model = new List<JobPost>();
            if (searchBy == "location")
            {
                model = db.JobPosts.Where(j => j.location == searchValue).ToList();
                HttpCookie myCookieLoc1 = new HttpCookie("mycookieLoc1");
                myCookieLoc1.Value = searchValue;
                //myCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(myCookieLoc1);
            }
            else if (searchBy == "industry")
            {
                int industry = Convert.ToInt32(searchValue);
                model = db.JobPosts.Where(j => j.categoryId == industry).ToList();
                HttpCookie myCookieInd1 = new HttpCookie("mycookieInd1");
                myCookieInd1.Value = searchValue;
                //myCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(myCookieInd1);
            }
            //Session["SearchBy"] = searchBy;
            //Session["SearchValue"] = searchValue;
            return PartialView("_Jobs", model);
        }

        public PartialViewResult JobsByLocation()
        {
            List<DynamicActionLink> links = new List<DynamicActionLink>();
            var jobLocations = db.JobPosts.Select(x => x.location).Distinct().ToList();
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
            var industries = db.Categories.ToList();
            foreach (var industry in industries)
            {
                DynamicActionLink link = new DynamicActionLink();
                link.LinkName = industry.category_name;
                link.LinkController = "SearchJobs";
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
            ViewBag.Industry = new SelectList(db.Categories, "category_id", "category_name", industry);
            ViewBag.Area1 = new SelectList(db.Areas, "area_id", "area_name", area1);
            ViewBag.JobType = new SelectList(Enum.GetNames(typeof(JobType)), jobType);
            ViewBag.Location = new SelectList(db.JobPosts.Select(x => x.location).Distinct().ToList(), location);
            return PartialView("_QuickSearch");
        }

        public PartialViewResult QuickSearchJobs(string Industry, string Area1, string JobType, string Location)
        {
            int catId = 0;
            int aId = 0;
            if (!string.IsNullOrEmpty(Industry))
            {
                catId = Convert.ToInt32(Industry);
            }
            if (!string.IsNullOrEmpty(Area1))
            {
                aId = Convert.ToInt32(Area1);
            }
            var model = db.JobPosts.Where(j =>
                                (Industry == "" || j.categoryId == catId)
                            && (Area1 == "" || j.areaid == aId)
                            && (JobType == "" || j.type == JobType)
                            && (Location == "" || j.location == Location))
                            .ToList();
            
            HttpCookie myCookie1 = new HttpCookie("mycookie1");
            myCookie1.Value = Industry + "-" + Area1 + "-" + JobType + "-" + Location;
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookie1);
            
            return PartialView("_Jobs", model);
        }
    }
}