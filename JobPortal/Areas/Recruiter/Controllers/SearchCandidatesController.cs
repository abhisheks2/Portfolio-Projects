using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Areas.Recruiter.Controllers
{
    public class SearchCandidatesController : Controller
    {
        JobPortalDBContext db = new JobPortalDBContext();

        // GET: Recruiter/SearchCandidates
        public ActionResult CandidateSearch(string Industry, string Skills, string MinExp, string MaxExp)
        {
            HttpCookie myCookie2 = new HttpCookie("mycookie2");
            myCookie2.Value = "CandidateSearchcookie";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookie2);

            HttpCookie myCookieInd2 = new HttpCookie("mycookieInd2");
            myCookieInd2.Value = "Creating cookie";
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookieInd2);

            return View();
        }

        public PartialViewResult DisplayCandidates(string searchBy, string searchValue)
        {
            HttpCookie myCookieInd2 = new HttpCookie("mycookieInd2");
            myCookieInd2.Value = searchValue;
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookieInd2);

            var model = db.CandidateProfessional.Where(c => c.industry == searchValue);
            
            return PartialView("_SearchCandidates", model);
        }

        public PartialViewResult CandidatesByIndustry()
        {
            List<DynamicActionLink> links = new List<DynamicActionLink>();
            var industries = db.Categories.ToList();
            foreach (var industry in industries)
            {
                DynamicActionLink link = new DynamicActionLink();
                link.LinkName = industry.category_name;
                link.LinkController = "SearchCandidates";
                link.LinkAction = "DisplayCandidates";
                link.LinkSearchBy = "industry";
                link.LinkSearchValue = industry.category_name;
                links.Add(link);
            }

            return PartialView("_IndustryLinks", links);
        }

        public PartialViewResult QuickSearch(string Industry, string Skills, string MinExp, string MaxExp)
        {
            ViewBag.skills = Skills;
            ViewBag.minexp = MinExp;
            ViewBag.maxexp = MaxExp;
            ViewBag.Industry = new SelectList(db.Categories, "category_id", "category_name", Industry);
            return PartialView("_QuickSearchCandidates");
        }


        public PartialViewResult QuickSearchCandidates(string Industry, string Skills, string MinExp, string MaxExp)
        {
            HttpCookie myCookie2 = new HttpCookie("mycookie2");
            myCookie2.Value = Industry + "-" + Skills + "-" + MinExp + "-" + MaxExp;
            //myCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(myCookie2);

            int minimumExp = Convert.ToInt32(MinExp);
            int maximumExp = Convert.ToInt32(MaxExp);
            if (Industry != "")
            {
                int catId = Convert.ToInt32(Industry);
                var searchIndustry = db.Categories.Single(i => i.category_id == catId);
                Industry = searchIndustry.category_name;
            }
            var model = db.CandidateProfessional.Where(c =>
                (Industry == "" || c.industry == Industry) &&
                (MinExp == "0" || c.experienceYears >= minimumExp) &&
                (MaxExp == "0" || c.experienceYears <= maximumExp) &&
                (Skills == "" || c.skills.Contains(Skills))
            ).ToList();

            return PartialView("_SearchCandidates", model);
        }

        public ActionResult CandidateDetails(int id)
        {
            CandidateBasic candidate = db.CandidateBasic.Single(c => c.candidateId == id);
            return View(candidate);
        }
    }
}