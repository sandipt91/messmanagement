using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using messManagementSystem.messContext;
using messManagementSystem.Models;

namespace messManagementSystem.Controllers
{
    public class DailyMessController : Controller
    {
        MessCustContext _ds = new MessCustContext();
        //
        // GET: /DailyMess/

        public ActionResult Index(long custId)
        {
            ViewBag.custId = custId;

            var dailyMess = _ds.Dailymess.Where(s => s.custId.Equals(custId) && s.status == (byte)Status.Active);   

            return View(dailyMess);
        }


        public ActionResult Create(long id)
        {
            ViewBag.custId = id;

            DailyMess map = new DailyMess();

            ViewBag.CustomerCollection = _ds.GetCustomers().Where(c => c.status == (byte)Status.Active);

            return View(map);

        }

        [HttpPost]

        public ActionResult Create(DailyMess dailymess)
        {

            
          //  int IsAdded = 0;
            if (ModelState.IsValid)
            {
                //var daily = _ds.GetDailyMesss()
                //    .Where(PS => PS.custId.Equals(dailymess.custId)
                //        && PS.status == (byte)Status.Active);

                dailymess.lastUpdateDate = DateTime.UtcNow;
                dailymess.status = (byte)Status.Active;
                dailymess.lunchDateTime = DateTime.UtcNow;
                     
                _ds.CreateDailyMess(dailymess);  
            }
            ViewBag.CustomerCollection = _ds.GetCustomers().Where(c => c.status == (byte)Status.Active);
            ViewBag.custId = dailymess.custId;

            return View(dailymess);
        }
    }
}