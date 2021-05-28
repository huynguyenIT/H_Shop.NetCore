using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.Checkout_Customer_Services
{
    public interface ICheckoutCustomerService
    {
       List<CheckoutCustomerOrder> GetAllAccounts();



        Task<CheckoutCustomerOrder> GetAccountById(string id);


        Task<List<CheckoutCustomerOrder>> GetListAccountById(string id);



        bool Update_Ad_acc(CheckoutCustomerOrder dTO_Account);

        bool DeleteAccount(string id);
    }
}
