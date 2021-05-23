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
                FilterDefinitionBuilder<Checkout_Customer> filter = Builders<Checkout_Customer>.Filter;
                FilterDefinition<Checkout_Customer> eqFilter = filter.Where(x => x._Id == id);

                await _db.DeleteOneAsync(eqFilter);

              
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

        public Task<bool> Update_Ad_acc(Checkout_Customer account)
        {
            var acc =  GetAccountById(account._Id);
            if (acc != null)
            {
                //acc.Id_KH = account.Id_KH;
                //acc.FirstName = account.FirstName;
                //acc.Email = account.Email;
                //acc.LastName = account.LastName;
                ////acc.NgayTao = account.NgayTao;
                //acc.SDT = account.SDT;
                //acc.TongTien = account.TongTien;
                //acc.TrangThai = account.TrangThai;
                //acc.Zipcode = account.Zipcode;
                //acc.GiamGia = account.GiamGia;
                //acc.DiaChi = account.DiaChi;

                //db.SaveChanges();
                //return true;
                
            }

            return null;



            //return false;
        }
    }
}
