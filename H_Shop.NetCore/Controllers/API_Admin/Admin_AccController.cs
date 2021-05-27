using DataAndServices.Admin_Services.Admin_Acc_Services;
using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Admin
{
    [Route("api/Admin_acc")]
    [ApiController]
    public class Admin_AccController : ControllerBase
    {
        private readonly IAdminAccService adminAccService;

        public Admin_AccController (IAdminAccService _adminAccService)
        {
            adminAccService = _adminAccService;
        }
        [Route("Create")]
        public bool Create(Account Account)
        {
            return  adminAccService.Create_Ad_acc(Account);
        }

        // PUT: api/Admin_acc/5
        [Route("UpdateAcc")]
        public bool Update(Account Account)
        {
            return  adminAccService.Update_Ad_acc(Account);
        }
        [Route("UpdateAccTwo")]
        public bool Update2(Account Account)
        {
            return  adminAccService.Update_Ad_acc2(Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteAccount/{id}")]
        public async Task<bool> DeleteAccount(string id)
        {
            return await adminAccService.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var listAccount= await adminAccService.GetAllAccounts();
            return Ok(listAccount);
        }
        [HttpGet]
        [Route("GetAllAccounts2")]
        public IActionResult GetAllAccounts2()
        {
            var listAccount2 =  adminAccService.GetAllAccounts2();
            return Ok(listAccount2);
        }
        [HttpGet]
        [Route("GetAccountById/{Id}")]
        public async Task<IActionResult> GetProductById(string Id)
        {
            var accId= await adminAccService.GetAccountById(Id);
            return Ok(accId);
        }
    }
}
