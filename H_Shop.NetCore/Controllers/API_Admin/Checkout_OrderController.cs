using DataAndServices.Admin_Services.CheckoutOrderServices;

using DataAndServices.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Admin
{
    [Route("api/Checkout_Order")]
    [ApiController]
    public class Checkout_OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public Checkout_OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("Update")]
        public bool Update(Checkout_Oder dTO_Account)
        {
            return  _orderService.Update_Ad_acc(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteOrder/{id}")]
        public async Task<bool> DeleteOrder(string id)
        {
            return await _orderService.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
           var listOrder= await _orderService.GetAllAccounts();
            return Ok(listOrder);
        }
       
        [HttpGet]
        [Route("GetOrderById/{Id}")]
        public async Task<IActionResult> GetOrderById(string Id)
        {
           var orderId= await _orderService.GetAccountById(Id);
            return Ok(orderId);
        }
        [HttpGet]
        [Route("GetOrderByIdKH/{Id}")]
        public async Task<IActionResult> GetOrderByIdKH(string Id)
        {
           var orderIdKh= await _orderService.GetAccountByIdKH(Id);
            return Ok(orderIdKh);
        }
        [HttpGet]
        [Route("GetListOrderById/{Id}")]
        public async Task<IActionResult> GetListOrderById(string Id)
        {
           var listOrderId =await _orderService.GetListAccountById(Id);
            return Ok(listOrderId);
        }
    }
}
