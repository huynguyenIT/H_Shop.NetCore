using DataAndServices.Client_Services;
using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Client
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [Route("InsertBill")]
        public  async Task<int> InsertBill(CheckoutCustomer_Order checkoutCustomer_Order)
        {
            return await _cartServices.InsertBill(checkoutCustomer_Order);
        }
        [Route("InsertCKOrder")]
        public async Task<bool> InsertCKOrder(Checkout_Oder dTO_Account)
        {
            return await _cartServices.InsertCheckoutOrder(dTO_Account);
        }
        [Route("GetGiamGia/{zipcode}")]
        public async Task< double> GetGiamGia(string zipcode)
        {
            return await _cartServices.GetGiamGia(zipcode);
        }
    }
}
