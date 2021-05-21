using DataAndServices.Admin_Services.Checkout_Customer_Services;
using DataAndServices.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Admin
{
    [Route("api/Checkout_Customer")]
    [ApiController]
    public class Checkout_CustomerController : ControllerBase
    {
        private readonly ICheckoutCustomerService _checkoutCustomerService;

        public Checkout_CustomerController(ICheckoutCustomerService checkoutCustomerService)
        {
            _checkoutCustomerService = checkoutCustomerService;
        }

        [Route("Update")]
        public async Task< bool> Update(Checkout_Customer dTO_Account)
        {
            return await _checkoutCustomerService.Update_Ad_acc(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteCustomer/{id:int}")]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await _checkoutCustomerService.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {   
             var listAccount= await _checkoutCustomerService.GetAllAccounts();
            return Ok(listAccount);

            
        }
        //[HttpGet]
        //[Route("GetAllAccounts2")]
        //public JsonResult<List<DTO_Account_Role>> GetAllAccounts2()
        //{
        //    return Json<List<DTO_Account_Role>>(_checkoutCustomerService.GetAllAccounts2());
        //}
        [HttpGet]
        [Route("GetCustomerById/{Id:int}")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            var listAccount = await _checkoutCustomerService.GetAccountById(Id);
            return Ok(listAccount);

            
        }
        [HttpGet]
        [Route("GetListCustomerById/{Id:int}")]
        public  async Task<IActionResult> GetListCustomerById(int Id)
        {
            var listAccount = await _checkoutCustomerService.GetListAccountById(Id);
        
            return Ok(listAccount);
            
        }
    }
}
