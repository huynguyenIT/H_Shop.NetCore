using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.CheckoutOrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Checkout_Oder> _db;
        public OrderService(DataContext db)
        {
            _db = db.GetCheckout_OderCollection();
        }
        public Task<bool> DeleteAccount(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Checkout_Oder> GetAccountById(string id)
        {
            return await _db.Find(s => s._id == id).FirstOrDefaultAsync();

        }

        public async Task<Checkout_Oder> GetAccountByIdKH(string id)
        {
            var results = _db.Find(x => x.TenSP == id).FirstOrDefaultAsync();
            var filter = Builders<Checkout_Oder>.Filter.Eq(x => x.TenSP, id);

            FilterDefinitionBuilder<Checkout_Oder> filter1 = Builders<Checkout_Oder>.Filter;
            FilterDefinition<Checkout_Oder> eqFilter = filter1.Eq(x => x.TenSP, id);

            var test = await _db.Find(filter).FirstOrDefaultAsync();
            return test;
        }

        public async Task<List<Checkout_Oder>> GetAllAccounts()
        {
            return await _db.Find(s => true).ToListAsync();
        }

        public async Task<List<Checkout_Oder>> GetListAccountById(string id)
        {
            return await _db.Find(s => s._id == id).ToListAsync();
        }

        public Task<bool> Update_Ad_acc(Checkout_Oder dTO_Account)
        {
            throw new NotImplementedException();
        }
    }
}
