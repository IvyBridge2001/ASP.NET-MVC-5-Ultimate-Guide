using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpName(int EmpId)
        {
            var employees = new[]
            {
                new {EmpId = 1, EmpName = "Scott", Salary = 8000},
                new {EmpId = 2, EmpName = "Smith", Salary = 2540},
                new {EmpId = 3, EmpName = "Allen", Salary = 9400},

            };

            string matchEmpName = string.Empty;
            foreach (var item in employees)
            {
                if (item.EmpId == EmpId)
                {
                    matchEmpName = item.EmpName;
                }
            }
            //return new ContentResult() { Content = matchEmpName, ContentType = "text/plain" };
            return Content(matchEmpName, "text/plain");            
        }

        public ActionResult GetPaySlip(int EmpId)
        {
            string fileName = "~/PaySlip" + EmpId + ".pdf";
            return File(fileName, "application/pdf");
        }

        public ActionResult EmpFacebookPage(string profileName)
        {
            string fbUrl = "https://facebook.com/" + profileName + "/";

            if (fbUrl == null)
            {
                return Content("Invalid Profile Name");
            }

            return Redirect(fbUrl);
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Scott";
            ViewBag.Marks = 80;
            ViewBag.Semesters = 6;
            ViewBag.Subjects = new List<string>() { "Maths", "Physics", "Chemistry" };
            return View();
        }

        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.HttpMethod = Request.HttpMethod;
            ViewBag.BrowserType = Request.Browser;
            ViewBag.Headers = Response.Headers;
            return View();
        }
        public ActionResult ResponseExample()
        {
            Response.Write("Hey there!");
            Response.ContentType = "text/plain";
            Response.Headers["Server"] = "My Server";
            Response.StatusCode = 500;
            return View();
        }
    }
}