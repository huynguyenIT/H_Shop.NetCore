﻿using DataAndServices.Admin_Services.Products;
using DataAndServices.CommonModel;
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
    public class CartService : ICartServices
    {
        private readonly IMongoCollection<Checkout_Oder> _dbCheckOrder;
        private readonly IMongoCollection<CodeDiscount> _dbCodeDis;
        private readonly IMongoCollection<Checkout_Customer> _dbCheckCustomer;
        private readonly IMongoCollection<CheckoutCustomerOrder> _dbCheckCustomerOrder;
        private readonly IMongoCollection<Item> _dbItem;



        public CartService(DataContext db)
        {
            _dbCheckOrder = db.GetCheckout_OderCollection();
            _dbCodeDis = db.GetCodeDiscountCollection();
            _dbCheckCustomer = db.GetCheckout_CustomerCollection();
            _dbCheckCustomerOrder = db.GetCheckoutCustomerOrderCollection();
            _dbItem = db.GetItemCollection();
            
        }
        public async Task<double> GetGiamGia(string zipcode)
        {

            var temp = await _dbCodeDis.Find(s => s.Zipcode == zipcode).FirstOrDefaultAsync();
            if (temp != null)
            {
                return (double)temp.Discount; // vidu: 0.3 0.4
            }
            return 0;
        }
        //public int InsertBill(CheckoutCustomer_Order dTO_CheckoutCustomer_Order)
        //{
        //    try
        //    {
        //        Checkout_Customer _Customer = new Checkout_Customer();
        //        _Customer.FirstName = dTO_CheckoutCustomer_Order.FirstName;
        //        _Customer.LastName = dTO_CheckoutCustomer_Order.LastName;
        //        _Customer.Email = dTO_CheckoutCustomer_Order.Email;
        //        _Customer.SDT = dTO_CheckoutCustomer_Order.SDT;
        //        _Customer.DiaChi = dTO_CheckoutCustomer_Order.DiaChi;
        //        _Customer.City = dTO_CheckoutCustomer_Order.City;
        //        _Customer.Zipcode = dTO_CheckoutCustomer_Order.Zipcode;
        //        _Customer.NgayTao = dTO_CheckoutCustomer_Order.NgayTao;
        //        _Customer.TrangThai = dTO_CheckoutCustomer_Order.TrangThai;
        //        // _Customer.GiamGia = dTO_CheckoutCustomer_Order.TongTien * tiengiam;
        //        _Customer.GiamGia = dTO_CheckoutCustomer_Order.GiamGia;
        //        _Customer.TongTien = dTO_CheckoutCustomer_Order.TongTien;
        //        // _Customer.TongTien = dTO_CheckoutCustomer_Order.TongTien - dTO_CheckoutCustomer_Order.TongTien * tiengiam;
        //        _dbCheckCustomer.InsertOne(_Customer);

        //        List<Checkout_Oder> checkout_Oder = new List<Checkout_Oder>();

        //        foreach (var item in dTO_CheckoutCustomer_Order.Checkout_Orders)
        //        {
        //            Checkout_Oder checkout_order = new Checkout_Oder();
        //            checkout_order.Id_SanPham = item.Id_SanPham; ;
        //            checkout_order.TenSP = item.TenSP;
        //            checkout_order.SoLuong = item.SoLuong;
        //            checkout_order.Gia = item.Gia;
        //            checkout_order.NgayTao = item.NgayTao;
        //            checkout_order.TrangThai = item.TrangThai;
        //            checkout_Oder.Add(checkout_order);
        //            int quantity = (int)item.SoLuong;
        //            item.Id_KH = dTO_CheckoutCustomer_Order.Id_KH;
        //            _dbCheckOrder.InsertOne(item);
        //            //ProductService.UpdateQuantityItem(item._id,quantity);
        //        }



        //        return 1;





        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        public int InsertBill(CheckoutCustomerOrder checkoutCustomer_Order)
        {
          
            try
            {
                foreach (var item in checkoutCustomer_Order.ProductOrder)
                {
                    int quantity = (int)item.SoLuong;
                  
                  UpdateQuantityItem(item.Id_SanPham, quantity);
                }

                checkoutCustomer_Order.GiamGia = checkoutCustomer_Order.GiamGia+"%";
           
                _dbCheckCustomerOrder.InsertOne(checkoutCustomer_Order);

               



                return 1;





            }
            catch
            {
                return 0;
            }
        }
        public bool UpdateQuantityItem(string _id, int quantity)
        {
            var itemNow = _dbItem.Find(s => s._id == _id).FirstOrDefault();


            if (itemNow != null)
            {
                var quantityNow = itemNow.Quantity; // vidu: 0.3 0.4
                var quantityPay = quantityNow - quantity;

                if (quantityNow - quantityPay > 0)
                {


                    itemNow.Quantity = quantityPay;
                    var eqfilter = Builders<Item>.Filter.Where(s => s._id == _id);
                    var update = Builders<Item>.Update.Set(s => s.Quantity, itemNow.Quantity);


                    var options = new UpdateOptions { IsUpsert = true };
                    _dbItem.UpdateOne(eqfilter, update, options);

                    //db.SaveChanges();
                    return true;
                }

            }
            return false;
        }

        public bool InsertCheckoutOrder(Checkout_Oder checkout_Order)
        {
            try
            {
                _dbCheckOrder.InsertOne(checkout_Order);
                //db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
