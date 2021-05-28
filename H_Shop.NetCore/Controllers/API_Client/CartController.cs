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
        public  int InsertBill(CheckoutCustomerOrder checkoutCustomerOrder)
        {
            return  _cartServices.InsertBill(checkoutCustomerOrder);
        }
        [Route("InsertCKOrder")]
        public bool InsertCKOrder(Checkout_Oder dTO_Account)
        {
            return  _cartServices.InsertCheckoutOrder(dTO_Account);
        }
        [Route("GetGiamGia/{zipcode}")]
        public async Task< double> GetGiamGia(string zipcode)
        {
            return await _cartServices.GetGiamGia(zipcode);
        }
    }
}
