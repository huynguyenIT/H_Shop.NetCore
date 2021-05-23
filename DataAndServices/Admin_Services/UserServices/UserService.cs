using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.UserServices
{
    public class UserService : IUsers
    {

        private readonly IMongoCollection<User_Acc> _db;

        public UserService(DataContext db)
        {
            _db = db.GetUser_AccCollection();
        }
        public Task<bool> DeleteAccount(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User_Acc> GetAccountById(string id)
        {
            return await _db.Find(s => s._id == id).FirstOrDefaultAsync();

        }

        public async Task<List<User_Acc>> GetAllAccounts()
        {
            return await _db.Find(s =>true).ToListAsync();
        }

        public Task<bool> Update_Ad_acc(User_Acc Account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update_Ad_acc2(User_Acc Account)
        {
            throw new NotImplementedException();
        }
    }
}
