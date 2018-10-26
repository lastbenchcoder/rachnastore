using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rachna.Teracotta.Project.Source.Controllers
{
    public class errorcontroller : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View();
        }
        public ViewResult InProgress()
        {
            return View();
        }
    }
}