﻿using DataAndServices.Data;
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
        private readonly IMongoCollection<CheckoutCustomerOrder> _db;
        public CheckoutCustomerService(DataContext db)
        {
            _db = db.GetCheckoutCustomerOrderCollection();
        }
        public bool DeleteAccount(string id)
        {
            try
            {
                var deleteFilter3 = Builders<CheckoutCustomerOrder>.Filter.Eq("_id", id);

                 _db.DeleteOne(deleteFilter3);

              
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CheckoutCustomerOrder> GetAccountById(string id)
        {
            return await _db.Find(s => s._id == id).FirstOrDefaultAsync();
        }

        public List<CheckoutCustomerOrder> GetAllAccounts()
        
        {
            return  _db.Find(s=>true).ToList();
        }

        public async Task<List<CheckoutCustomerOrder>> GetListAccountById(string id)
        {
            return await _db.Find(s => s._id == id).ToListAsync();
        }

        public bool Update_Ad_acc(CheckoutCustomerOrder custom)
        {
            var acc =  GetAccountById(custom._id);
            if (acc != null)
            {
                var eqfilter = Builders<CheckoutCustomerOrder>.Filter.Where(s => s._id == custom._id);

                var update = Builders<CheckoutCustomerOrder>.Update.Set(s => s.Email, custom.Email)
                    .Set(s => s.FirstName, custom.FirstName)
                    .Set(s => s.LastName, custom.LastName)
                    .Set(s => s.City, custom.City)
                    .Set(s => s.GiamGia, custom.GiamGia)
                    .Set(s => s.NgayTao, custom.NgayTao)
                    .Set(s => s.SDT, custom.SDT)
                    .Set(s => s.TongTien, custom.TongTien)
                    .Set(s => s.TrangThai, custom.TrangThai);
                    //.Set(s => s.ProductOrder, custom.ProductOrder);
                    //.Set(s => s.TenSP, custom.TenSP)
                    //.Set(s => s.SoLuong, custom.SoLuong)
                    //.Set(s => s.Gia, custom.Gia)
                    //.Set(s => s._id, custom._id)
                    //.Set(s => s.Id_KH, custom.Id_KH)

                    //        .Set(s => s.TrangThai, custom.TrangThai);

                var options = new UpdateOptions { IsUpsert = true };




                _db.UpdateOneAsync(eqfilter, update, options);
                return true;

            }

            return false;



            //return false;
        }
    }
}
