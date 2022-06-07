using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW3.Models;

namespace HW3.Controllers
{
    public class HomeController : Controller
    {

        private readonly FileModel fileModel = new FileModel();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase myfile, string File) {

            System.Diagnostics.Debug.WriteLine(File);
            System.Diagnostics.Debug.WriteLine(myfile);
            if (File == "Document")
            {

                var path = Path.Combine(Server.MapPath("~/Media/Documents/"),
                                        System.IO.Path.GetFileName(myfile.FileName));
                myfile.SaveAs(path);
            }
            else if (File == "Image")
            {
                var path = Path.Combine(Server.MapPath("~/Media/Images/"),
                        System.IO.Path.GetFileName(myfile.FileName));
                myfile.SaveAs(path);

            }
            else {

                var path = Path.Combine(Server.MapPath("~/Media/Videos/"),
                      System.IO.Path.GetFileName(myfile.FileName));
                myfile.SaveAs(path);

            }
            return RedirectToAction("Index");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}