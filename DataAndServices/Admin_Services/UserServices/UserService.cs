using DataAndServices.Common;
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
        public async Task<bool> DeleteAccount(string id)
        {
            try
            {
                await _db.DeleteOneAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User_Acc> GetAccountById(string id)
        {
            return await _db.Find(s => s._id == id).FirstOrDefaultAsync();

        }

        public async Task<List<User_Acc>> GetAllAccounts()
        {
            return await _db.Find(s =>true).ToListAsync();
        }

        public bool Update_Ad_acc(User_Acc custom)
        {
            var acc = GetAccountById(custom._id);
            if (acc != null)
            {
                var eqfilter = Builders<User_Acc>.Filter.Where(s => s.idUser == custom.idUser);

                var update = Builders<User_Acc>.Update.Set(s => s.Email, custom.Email)
                    .Set(s => s.FirstName, custom.FirstName)
                    .Set(s => s.LastName, custom.LastName)
                    .Set(s => s.Password, Encryptor.MD5Hash(custom.Password))
                    .Set(s => s.idUser, custom.idUser);

                var options = new UpdateOptions { IsUpsert = true };




                _db.UpdateOneAsync(eqfilter, update, options);
                return true;
            }





            return false;
        }

        public bool Update_Ad_acc2(User_Acc custom)
        {
            var acc = GetAccountById(custom._id);
            if (acc != null)
            {
                var eqfilter = Builders<User_Acc>.Filter.Where(s => s.idUser == custom.idUser);

                var update = Builders<User_Acc>.Update.Set(s => s.Email, custom.Email)
                    .Set(s => s.FirstName, custom.FirstName)
                    .Set(s => s.LastName, custom.LastName)
                    //.Set(s => s.Password, Encryptor.MD5Hash(custom.Password))
                    .Set(s => s.idUser, custom.idUser);

                var options = new UpdateOptions { IsUpsert = true };




                _db.UpdateOneAsync(eqfilter, update, options);
                return true;
            }





            return false;
        }
    }
}
