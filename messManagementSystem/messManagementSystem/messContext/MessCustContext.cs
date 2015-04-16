using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using messManagementSystem.messContext.Interface;
using messManagementSystem.Models;

namespace messManagementSystem.messContext
{
    public class MessCustContext : DbContext, mInterface
    { 
        #region DbSet

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DailyMess> Dailymess { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<temp> Temps { get; set; }

        #endregion DbSet

        #region Constructor

        public MessCustContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion Constructor

        #region Owner

        #region CreateOwner

        public int CreateOwner(Owner owner)
        {
            if (owner == null)
                return 0;
            this.Owners.Add(owner);
            return this.SaveChanges();
        }

        #endregion CreateOwner

        #region UpdateOwner

        public int UpdateOwner(Owner owner)
        {
            if (owner == null)
                return 0;

            this.Entry(owner).State = System.Data.EntityState.Modified;
            return this.SaveChanges();
        }

        #endregion UpdateOwner

        #region DeleteOwner

        public int DeleteOwner(long ownerid)
        {
            throw new NotImplementedException();
        }

        #endregion DeleteOwner

        #region GetOwners

        public IEnumerable<Owner> GetOwners()
        {
            return Owners;
        }

        #endregion GetOwners

        #region GetOwner

        public Owner GetOwner(long ownerid)
        {
            return this.Owners.Find(ownerid);
        }

        #endregion GetOwner

        #endregion Owner

        #region Customer


        #region CreateCustomer

        public int CreateCustomer(Customer customer)
        {
            if (customer == null)
                return 0;

            this.Customers.Add(customer);
            return this.SaveChanges();
        }

        #endregion CreateCustomer


        #region UpdateCustomer

        public int UpdateCustomer(Customer customer)
        {
            if (customer == null)
                return 0;

            this.Entry(customer).State = System.Data.EntityState.Modified;
            return this.SaveChanges();
        }

        #endregion UpdateCustomer

        #region DeleteCustomer

        public int DeleteCustomer(long custId)
        {
            var customer = GetCustomer(custId);

            if (customer == null)
                return 0;

            customer.status = (byte)Status.InActive;
            customer.lastUpdateDate = DateTime.UtcNow;

            this.Entry(customer).State = System.Data.EntityState.Modified;
            return this.SaveChanges();
        }

        #endregion DeleteCustomer

        #region GetCustomers

        public IEnumerable<Customer> GetCustomers()
        {
            return Customers;
        }

        #endregion GetCustomers

        #region GetCustomer

        public Customer GetCustomer(long custId)
        {
            return this.Customers.Find(custId);
        }

        #endregion GetCustomer

        #endregion Customer

        #region DailyMess

        public int CreateDailyMess(DailyMess Dailymess)
        {
            if (Dailymess == null)
                return 0;
            this.Dailymess.Add(Dailymess);
            return this.SaveChanges();
        }

        public int UpdateDailyMess(DailyMess Dailymess)
        {
            throw new NotImplementedException();
        }

        public int DeleteDailyMess(long dailyMessID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DailyMess> GetDailyMesss()
        {
            return Dailymess;
        }

        public Owner GetDailyMess(long dailyMessID)
        {
            throw new NotImplementedException();
        }

        #endregion DailyMess


       
        public int SaveComments(Contact comment)
        {
            if (comment == null)
                return 0;
            this.Contacts.Add(comment);
            return this.SaveChanges();
            
        } 

        IEnumerable<Customer> mInterface.mesCustomer()
        {
            var all = Customers;

            //return this.Customers;
            return all;
        }

    }
}