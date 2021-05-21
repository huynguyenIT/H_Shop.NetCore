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
        Task<List<Checkout_Customer>> GetAllAccounts();



        Task<Checkout_Customer> GetAccountById(int id);


        Task<List<Checkout_Customer>> GetListAccountById(int id);



        Task<bool> Update_Ad_acc(Checkout_Customer dTO_Account);

        Task<bool> DeleteAccount(int id);
    }
}
