using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HomeFinance.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public ErrorController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    break;
            }
            return View("ErrorView");
        }

        [Route("/Error")]
        public IActionResult ErrorHandler()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string errorText = System.DateTime.Now.ToString() + "\r\n" + exceptionDetails.Error + "\r\n" +
            "----------------------------------------------------------------------------------------------------------------------------------" + "\r\n";
            string filepath = Path.Combine(hostingEnvironment.WebRootPath, @"log\ErrorLog.txt");
            System.IO.File.AppendAllText(filepath, errorText);
            ViewBag.ErrorMessage = "Something went wrong, please contact abhisheks2@gmail.com";
            return View("ErrorView");
        }
    }
}