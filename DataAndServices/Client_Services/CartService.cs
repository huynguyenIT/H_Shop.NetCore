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



        public CartService(DataContext db)
        {
            _dbCheckOrder = db.GetCheckout_OderCollection();
            
        }
        public Task<double> GetGiamGia(string zipcode)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertBill(CheckoutCustomer_Order dTO_CheckoutCustomer_Order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCheckoutOrder(Checkout_Oder checkout_Order)
        {
            throw new NotImplementedException();
        }
    }
}
