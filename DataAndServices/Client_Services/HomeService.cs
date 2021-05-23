using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Client_Services
{
    public class HomeService : IHomeServices
    {
        private readonly IMongoCollection<User_Acc_Client> _dbUser;
        private readonly IMongoCollection<Feedback> _dbFeed;
        private readonly IMongoCollection<Item_type> _dbitemType;



        public HomeService(DataContext db)
        {
            _dbUser = db.GetUser_Acc_ClientCollection();
            _dbFeed = db.GetFeedbackCollection();
            _dbitemType = db.GetItem_TypeCollection();
        }
        public Task<bool> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User_Acc>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetAllFeedbacks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item_type>> GetAllItemType()
        {
            throw new NotImplementedException();
        }

        public Task<User_Acc> GetCustomerByEmail(string mail)
        {
            throw new NotImplementedException();
        }

        public Task<User_Acc> GetCustomerByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCustomerByPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User_Acc> GetCustomerByUsername(string user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCustomer(User_Acc cusInsert)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Task<long> InsertForFacebook(User_Acc cusInsert)
        {
            throw new NotImplementedException();
        }

        public Task<long> InsertForGoogle(User_Acc cusInsert)
        {
            throw new NotImplementedException();
        }

        public Task<User_Acc> LoginCustomer(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(User_Acc cusUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer2(User_Acc cusUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer3(User_Acc cusUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
