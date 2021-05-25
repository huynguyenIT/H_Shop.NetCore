using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.Checkout_Customer_Services
{
    public class CheckoutCustomerService : ICheckoutCustomerService

    {
        private readonly IMongoCollection<Checkout_Customer> _db;
        public CheckoutCustomerService(DataContext db)
        {
            _db = db.GetCheckout_CustomerCollection();
        }
        public async Task<bool> DeleteAccount(string id)
        {
            try
            {
                //FilterDefinitionBuilder<Checkout_Customer> filter = Builders<Checkout_Customer>.Filter;
                //FilterDefinition<Checkout_Customer> eqFilter = filter.Where(x => x._Id == id);

                await _db.DeleteOneAsync(id);

              
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Checkout_Customer> GetAccountById(string id)
        {
            return await _db.Find(s => s._Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Checkout_Customer>> GetAllAccounts()
        {
            return await _db.Find(s=>true).ToListAsync();
        }

        public async Task<List<Checkout_Customer>> GetListAccountById(string id)
        {
            return await _db.Find(s => s._Id == id).ToListAsync();
        }

        public bool Update_Ad_acc(Checkout_Customer custom)
        {
            var acc =  GetAccountById(custom._Id);
            if (acc != null)
            {
                var eqfilter = Builders<Checkout_Customer>.Filter.Where(s => s._Id == custom._Id);

                var update = Builders<Checkout_Customer>.Update.Set(s => s.Email, custom.Email)
                    .Set(s => s.FirstName, custom.FirstName)
                    .Set(s => s.LastName, custom.LastName)
                    .Set(s => s.City, custom.City)
                    .Set(s => s.GiamGia, custom.GiamGia)
                    .Set(s=>s.NgayTao,custom.NgayTao)
                    .Set(s=>s.SDT,custom.SDT)
                    .Set(s=>s.TongTien,custom.TongTien)
                    .Set(s=>s.TrangThai,custom.TrangThai);

                var options = new UpdateOptions { IsUpsert = true };




                _db.UpdateOneAsync(eqfilter, update, options);
                return true;

            }

            return false;



            //return false;
        }
    }
}
