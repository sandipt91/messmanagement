using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using messManagementSystem.Filters;
using messManagementSystem.messContext;
using messManagementSystem.Models;

namespace messManagementSystem.Controllers
{
    [InitializeSimpleMembership]
    [Authorize]
    public class CustomerController : Controller
    {

        #region Properties
        //
        // GET: /Customer/

        MessCustContext _ds = new MessCustContext();

        #endregion Properties

        #region Index

        public ActionResult Index()
        {
            var cust = _ds.GetCustomers().Where(c => c.status == (byte)Status.Active);
            return View(cust);
        } 

        #endregion Index

        #region Create

        public ActionResult Create()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult Create(Customer cust)
        {  
            if (ModelState.IsValid)
            {
                cust.lastUpdateDate = DateTime.UtcNow; 
                cust.status = (byte)Status.Active;
                cust.joinDate = DateTime.UtcNow;
                cust.releasedate = DateTime.UtcNow;

                _ds.CreateCustomer(cust);
            }

            return RedirectToAction("Index");
           // return View(cust);
        }

        #endregion Create

        #region Edit

        public ActionResult Edit(long id)
        {
            var cust = _ds.Customers.Find(id);
            return View(cust);
        }

        [HttpPost]
        public ActionResult Edit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                cust.status = (byte)Status.Active;
                cust.lastUpdateDate = DateTime.UtcNow;

                _ds.UpdateCustomer(cust);
            }
            return View(cust);

        }

        #endregion Edit 

        #region Delete

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Delete(long id)
        {
            int isDeleted = 0;

            Customer customer = _ds.GetCustomer(id);

            if (customer != null)
            {
                isDeleted = _ds.DeleteCustomer(id);
            }
            return Json(isDeleted <= 0 ? false : true, JsonRequestBehavior.AllowGet);
        }

        #endregion Delete

    } 
}
