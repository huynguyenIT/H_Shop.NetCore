using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Client_Services
{
     public interface IHomeServices
    {
         Task<List<User_Acc_Client>> GetAllCustomers();

         Task<List<Item_type>> GetAllItemType();

         Task<List<Feedback>> GetAllFeedbacks();

         Task<bool> InsertCustomer(User_Acc cusInsert);

         Task<long> InsertForFacebook(User_Acc cusInsert);

         Task<long> InsertForGoogle(User_Acc cusInsert);

         Task<bool> UpdateCustomer(User_Acc cusUpdate);

        Task< bool> UpdateCustomer2(User_Acc cusUpdate);

        Task< bool> UpdateCustomer3(User_Acc cusUpdate);

        Task< bool> DeleteCustomer(int id);

        Task<User_Acc_Client> GetCustomerByID(string id);

        Task<User_Acc_Client> GetCustomerByUsername(string user);

        Task<User_Acc_Client> GetCustomerByEmail(string mail);

        Task<User_Acc_Client> GetCustomerByPassword(string email);

        Task<User_Acc_Client> LoginCustomer(string user, string pass);
        Task<bool> InsertFeedback(Feedback feedback);
        

    }
}
