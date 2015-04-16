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
    public class OwnerController : Controller
    {
        #region Properties
        //
        // GET: /Owner/
        MessCustContext _ds = new MessCustContext();

        #endregion Properties

        #region Index

        public ActionResult Index()
        {

            var Owner = _ds.GetOwners().Where(S => S.status == (byte)Status.Active);
            //var owner = _ds.GetOwners.Where(o => o.status == (byte)Status.Active);

            return View(Owner);
        }

        #endregion Index

        #region CreateOwner

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            if (ModelState.IsValid)
            {
                owner.status = (byte)Status.Active;
                owner.lastUpdatedDate = DateTime.UtcNow;

                _ds.CreateOwner(owner);

            }
            return View(owner);

        }

        #endregion CreateOwner

        #region EditOwner


        public ActionResult Edit(long id)
        {
            var owner = _ds.GetOwner(id);

            if (owner == null)
                return HttpNotFound();

            return View(owner);

        }

        [HttpPost]
        public ActionResult Edit(Owner owner)
        {

            if (ModelState.IsValid)
            {
                owner.status = (byte)Status.Active;
                owner.lastUpdatedDate = DateTime.UtcNow;
                _ds.UpdateOwner(owner);

            }

            return View(owner);
        }

        #endregion EditOwner

        public ActionResult Details()
        {
            int id = 1;

            var owner = _ds.Owners.Find(id);

            ViewBag.details = owner.ownerFirstName;
            ViewBag.LastName = owner.ownerLastNeame;
            ViewBag.Address = owner.ownerAddress;
            ViewBag.Contact = owner.ownerContactNo;
            ViewBag.Email = owner.ownerEmail; 
            return View();//owner
        
        
        }
    }

}
