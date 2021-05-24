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

        public async Task<List<User_Acc_Client>> GetAllCustomers()
        {
            return await _dbUser.Find(s => true).ToListAsync();
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _dbFeed.Find(s => true).ToListAsync();
        }

        public async Task<List<Item_type>> GetAllItemType()
        {
            return await _dbitemType.Find(s => true).ToListAsync();
        }

        public async Task<User_Acc_Client> GetCustomerByEmail(string mail)
        {
            return await _dbUser.Find(s => s.Email==mail).FirstOrDefaultAsync();
        }

        public async Task<User_Acc_Client> GetCustomerByID(string id)
        {
            return await _dbUser.Find(s => s._id == id).FirstOrDefaultAsync();
        }

        public async Task<User_Acc_Client> GetCustomerByPassword(string email)
        {
            return await _dbUser.Find(s => s.Password == email).FirstOrDefaultAsync();
        }

        public Task<User_Acc_Client> GetCustomerByUsername(string user)
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

        public Task<User_Acc_Client> LoginCustomer(string user, string pass)
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
