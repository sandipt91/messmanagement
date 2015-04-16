using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using messManagementSystem.messContext;
using messManagementSystem.Models;

namespace messManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        MessCustContext _ds = new MessCustContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }


        [Authorize]
        public ActionResult Dashboard(int id = 1)
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaveComment(Contact comment)
        {
            if (ModelState.IsValid)
            {
                comment.status = (byte)Status.Active;
                comment.lastUpdatedDate = DateTime.UtcNow;
                _ds.SaveComments(comment);
            }

            return null;
        }
    }
}
