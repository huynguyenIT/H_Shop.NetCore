using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.AccountService
{
    public interface IAccountService
    {
        //Task<BoolResult> AccountIsExits(string userName, string password);


        //Task<bool> UserNameIsExitst(string username);


        Task<bool> UpdateCustomer(Account cusUpdate);


        Task<bool> DeleteCustomer(int id);


        Task<bool> InsertCustomer(Account cusInsert);


        Task<Account> GetCustomerByID(int id);



        Task<Account> GetCustomerByEmail(string email);


        Task<Account> LoginCustomer(string user, string pass);
    }
}
