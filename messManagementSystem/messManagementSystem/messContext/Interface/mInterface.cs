using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using messManagementSystem.Models;

namespace messManagementSystem.messContext.Interface
{
    public interface mInterface
    {
        #region QwnerInterface

        int CreateOwner(Owner owner);
        int UpdateOwner(Owner owner);
        int DeleteOwner(long ownerid);
        IEnumerable<Owner> GetOwners();
        Owner GetOwner(long ownerid);

        #endregion QwnerInterface

        #region CustomerInterface

        int CreateCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(long custId);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(long custId);

        #endregion CustomerInterface

        #region DailyMessInterface

        int CreateDailyMess(DailyMess Dailymess);
        int UpdateDailyMess(DailyMess Dailymess);
        int DeleteDailyMess(long dailyMessID);
        IEnumerable<DailyMess> GetDailyMesss();
        Owner GetDailyMess(long dailyMessID);

        #endregion DailyMessInterface


        #region CommentInterface

        int SaveComments(Contact comment);

        #endregion CommentInterface


        IEnumerable<Customer> mesCustomer();
    }
}