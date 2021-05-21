using DataAndServices.Common;
using DataAndServices.CommonModel;
using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.Admin_Acc_Services
{
    public class AdminAccService : IAdminAccService
    {
        private readonly IMongoCollection<Account> _db;
        private readonly DataContext db = new DataContext("mongodb://localhost:27017","OnlineShop");

        public AdminAccService (DataContext db)
        {
            _db = db.GetAccountCollection();
        }
        public async Task<bool> Create_Ad_acc(Account account)
        {
            try
            {
                await _db.InsertOneAsync(account);
                //await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                //var filter = Builders<Account>.Filter;
                //var serach = filter(id);
                //Account account = (Account)_db.Find(s=>s.idUser==id);
                FilterDefinitionBuilder<Account> filter = Builders<Account>.Filter;
                FilterDefinition<Account> eqFilter = filter.Where(x => x.idUser == id);
                await _db.DeleteOneAsync(eqFilter);
               // db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _db.Find(s => s.idUser == id).FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _db.Find(s=>true).ToListAsync();
        }

       

        public async Task<List<Account_Role>> GetAllAccounts2()
        {

            var acccountCollection = db.GetAccountCollection();
            var roleCollection = db.GetRoleCollection();
            var accountInfo = from account in acccountCollection.AsQueryable()
                              join role in roleCollection.AsQueryable() on account.RoleId equals role.RoleId
                              select new Account_Role()
                              {
                                  idUser = account.idUser,
                                  FirstName = account.FirstName,
                                  LastName = account.LastName,
                                  RoleName = role.RoleName
                              };
            return await accountInfo.ToListAsync();
        }

        public async Task<bool> Update_Ad_acc(Account account)
        {
            var acc = await GetAccountById(account.idUser);
            if (acc != null)
            {
                acc.idUser = account.idUser;
                acc.FirstName = account.FirstName;
                acc.Email = account.Email;
                acc.LastName = account.LastName;
                acc.Password = Encryptor.MD5Hash(account.Password);
                acc.RoleId = account.RoleId;

               // await db.SaveChangesAsync();
                return true;
            }





            return false;
        }

        public async Task<bool> Update_Ad_acc2(Account account)
        {
            var acc = await GetAccountById(account.idUser);
            if (acc != null)
            {
                acc.idUser = account.idUser;
                acc.FirstName = account.FirstName;
                acc.Email = account.Email;
                acc.LastName = account.LastName;
                // acc.Password = Encryptor.MD5Hash(account.Password);
                acc.RoleId = account.RoleId;

              // await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
