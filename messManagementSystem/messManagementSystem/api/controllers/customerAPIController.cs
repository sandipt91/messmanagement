
using messManagementSystem.messContext.Interface;
using messManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
//using System.Web.Mvc;
using StructureMap;
 
using System.Web.Http;

namespace messManagementSystem.api.controllers
{ 
    public class customerAPIController : ApiController
    {
        mInterface _ds = ObjectFactory.GetInstance<mInterface>();

        #region GetCustomerAPI

        [HttpGet]    
        public Customer GetCustomer(int id)
        {
            //var customer = _ds.mesCustomer().Where(c => c.custId == id).FirstOrDefault();
            var customer = _ds.mesCustomer().Where(c => c.custId == id).FirstOrDefault();
            if (customer == null)
                return null;

            return customer;
        }

        #endregion GetCustomertAPI

        #region GetAllCustomersAPI

        [HttpGet]
         public IEnumerable<Customer> GetAllCustomers()
         {
             var cust = _ds.mesCustomer().Where(c=>c.status==(byte)Status.Active);

             if (cust == null)
                 return null;

             return cust;
         }

         #endregion GetAllCustomersAPI

        #region DeleteCustomerAPI

         [HttpGet]
         public int DeleteCustomer(int id)
         {
             var customer = _ds.DeleteCustomer(id);

             return customer;
         }

         #endregion DeleteCustomerAPI

        #region EditCustomerAPI

         [HttpPost]
         public int EditCustomer(Customer cust)
         {
             if (cust == null)
                 return 0;
             cust.status = (byte)Status.Active;
             cust.lastUpdateDate = DateTime.UtcNow; 

             return _ds.UpdateCustomer(cust);
         }

         #endregion EditCustomerAPI

        #region CreateCustomerApi

         [HttpPost]
         public long CreateCustomer(Customer cust)
         {
             if (cust == null)
                 return 0;

             cust.status = (byte)Status.Active;
             cust.lastUpdateDate = DateTime.UtcNow;
             cust.joinDate = DateTime.UtcNow;
             cust.releasedate = DateTime.UtcNow;
             return _ds.CreateCustomer(cust);
               
         }

         #endregion CreateCustomer

    }
}
