using DataAndServices.Admin_Services.UserServices;
using DataAndServices.Client_Services;
using DataAndServices.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Admin
{
    [Route("api/User_Acc")]
    [ApiController]
    public class User_AccController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly IHomeServices _homeServices;
        public User_AccController(IUsers users,IHomeServices homeServices)
        {
            _users = users;
            _homeServices = homeServices;
        }
        [Route("UpdateUser")]
        public bool Update(User_Acc dTO_Account)
        {
            return  _users.Update_Ad_acc(dTO_Account);
        }
        [Route("UpdateUserTwo")]
        public bool Update2(User_Acc dTO_Account)
        {
            return  _users.Update_Ad_acc2(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteAccount/{id}")]
        public async Task<bool> DeleteAccount(string id)
        {
            return await _users.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var listuser = await _homeServices.GetAllCustomers();
            return Ok(listuser);
        }
       
        [HttpGet]
        [Route("GetAccountById/{Id}")]
        public IActionResult GetProductById(string Id)
        {
            var userById=  _users.GetAccountById(Id);
            return Ok(userById);
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var listAcc= await _homeServices.GetAllCustomers();
            return Ok(listAcc);
        }
        [Route("GetDetailCustomer")]
        public async Task<IActionResult> GetDetailCustomer(string id)
        {
            var cusDetails= await _homeServices.GetCustomerByID(id);
            return Ok(cusDetails);
        }
        [Route("InsertCustomer")]
        public bool InsertCustomer(User_Acc_Client cusInsert)
        {
            return  _homeServices.InsertCustomer(cusInsert);
        }
        [Route("UpdateCustomer")]
        public bool UpdateCustomer(User_Acc_Client cusUpdate)
        {
            return _homeServices.UpdateCustomer(cusUpdate);
        }
        [Route("DeleteCustomer/{id}")]
        public async Task<bool> DeleteCustomer(string id)
        {
            return await _homeServices.DeleteCustomer(id);
        }
        //[Route("CountCustomer")]
        //public  int CountCustomer()
        //{
        //    return  _homeServices.GetAllCustomers().Count();
        //}
    }
}
