﻿using DataAndServices.Admin_Services.UserServices;
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
        [Route("Update")]
        public async Task<bool> Update(User_Acc dTO_Account)
        {
            return await _users.Update_Ad_acc(dTO_Account);
        }
        [Route("Update2")]
        public async Task< bool> Update2(User_Acc dTO_Account)
        {
            return await _users.Update_Ad_acc2(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteAccount/{id:int}")]
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
        public async Task<IActionResult> GetProductById(string Id)
        {
            var userById= await _users.GetAccountById(Id);
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
        public async Task<bool> InsertCustomer(User_Acc cusInsert)
        {
            return await _homeServices.InsertCustomer(cusInsert);
        }
        [Route("UpdateCustomer")]
        public async Task<bool> UpdateCustomer(User_Acc cusUpdate)
        {
            return await _homeServices.UpdateCustomer(cusUpdate);
        }
        [Route("DeleteCustomer")]
        public async Task<bool> DeleteCustomer(int id)
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
