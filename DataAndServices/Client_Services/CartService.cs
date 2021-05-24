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



        public CartService(DataContext db)
        {
            _dbCheckOrder = db.GetCheckout_OderCollection();
            _dbCodeDis = db.GetCodeDiscountCollection();
            
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
