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
         Task<List<User_Acc>> GetAllCustomers();

         Task<List<Item_type>> GetAllItemType();

         Task<List<Feedback>> GetAllFeedbacks();

         Task<bool> InsertCustomer(User_Acc cusInsert);

         Task<long> InsertForFacebook(User_Acc cusInsert);

         Task<long> InsertForGoogle(User_Acc cusInsert);

         Task<bool> UpdateCustomer(User_Acc cusUpdate);

        Task< bool> UpdateCustomer2(User_Acc cusUpdate);

        Task< bool> UpdateCustomer3(User_Acc cusUpdate);

        Task< bool> DeleteCustomer(int id);

        Task<User_Acc> GetCustomerByID(int id);

        Task<User_Acc> GetCustomerByUsername(string user);

        Task<User_Acc> GetCustomerByEmail(string mail);

        Task< string> GetCustomerByPassword(string email);

        Task<User_Acc> LoginCustomer(string user, string pass);
        Task<bool> InsertFeedback(Feedback feedback);
        

    }
}
