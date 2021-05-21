using DataAndServices.Common;
using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.UserAccServices
{
    public class UserAccService : IUserAccService
    {
        private readonly IMongoCollection<User_Acc> _db;
        private readonly DataContext db = new DataContext("mongodb://localhost:27017", "OnlineShop");
        public UserAccService(DataContext db)
        {
            _db = db.GetUser_AccCollection();
        }
        public async Task<bool> Create_Ad_acc(User_Acc User_Acc)
        {
            try
            {
                await _db.InsertOneAsync(User_Acc);
                //await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser_Acc(int _id)
        {
            try
            {

                await _db.DeleteOneAsync(s => s.idUser == _id);
                // db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<User_Acc>> GetAllUser_Accs()
        {
            return await _db.Find(s => true).ToListAsync();
        }

        public async Task<User_Acc> GetUser_AccById(string id)
        {
            var filter = Builders<User_Acc>.Filter.Eq(s => s._id, id);
            var result = await _db.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update_Ad_acc(User_Acc custom)
        {
            var acc = await GetUser_AccById(custom._id);
            if (acc != null)
            {
                //acc.idUser = account.idUser;
                //acc.FirstName = account.FirstName;
                //acc.Email = account.Email;
                //acc.LastName = account.LastName;
                //acc.Password = Encryptor.MD5Hash(account.Password);
                //acc.RoleId = account.RoleId;

                var eqfilter = Builders<User_Acc>.Filter.Where(s => s._id == custom._id);

                var update = Builders<User_Acc>.Update.Set(s => s.Email, custom.Email)
                    .Set(s => s.FirstName, custom.FirstName)
                    .Set(s => s.LastName, custom.LastName)
                    .Set(s => s.Password, Encryptor.MD5Hash(custom.Password))
                    .Set(s => s.idUser, custom.idUser);

                var options = new UpdateOptions { IsUpsert = true };




                await _db.UpdateOneAsync(eqfilter, update, options).ConfigureAwait(false);
                return true;
            }





            return false;
        }

        public async Task<bool> Update_Ad_acc2(User_Acc custom)
        {
            var acc = await GetUser_AccById(custom._id);
            if (acc != null)
            {
                //acc.idUser = account.idUser;
                //acc.FirstName = account.FirstName;
                //acc.Email = account.Email;
                //acc.LastName = account.LastName;
                //acc.Password = Encryptor.MD5Hash(account.Password);
                //acc.RoleId = account.RoleId;

                var eqfilter = Builders<User_Acc>.Filter.Where(s => s._id == custom._id);

                var update = Builders<User_Acc>.Update.Set(s => s.Email, custom.Email)
                    .Set(s => s.FirstName, custom.FirstName)
                    .Set(s => s.LastName, custom.LastName)
                    .Set(s => s.Password, Encryptor.MD5Hash(custom.Password))
                    .Set(s => s.idUser, custom.idUser);

                var options = new UpdateOptions { IsUpsert = true };




                await _db.UpdateOneAsync(eqfilter, update, options).ConfigureAwait(false);
                return true;
            }





            return false;
        }
    }
}
