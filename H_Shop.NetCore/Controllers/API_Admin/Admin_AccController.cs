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
    [Route("api/Admin_Acc")]
    [ApiController]
    public class Admin_AccController : ControllerBase
    {
        private readonly IAdminAccService adminAccService;

        public Admin_AccController (IAdminAccService _adminAccService)
        {
            adminAccService = _adminAccService;
        }
        [Route("Create")]
        public async Task<bool> Create(Account Account)
        {
            return await adminAccService.Create_Ad_acc(Account);
        }

        // PUT: api/Admin_acc/5
        [Route("Update")]
        public async Task<bool> Update(Account Account)
        {
            return await adminAccService.Update_Ad_acc(Account);
        }
        [Route("Update2")]
        public async Task<bool> Update2(Account Account)
        {
            return await adminAccService.Update_Ad_acc2(Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteAccount/{id:int}")]
        public async Task<bool> DeleteAccount(int id)
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
        public async Task<IActionResult> GetAllAccounts2()
        {
            var listAccount2 = await adminAccService.GetAllAccounts2();
            return Ok(listAccount2);
        }
        [HttpGet]
        [Route("GetAccountById/{Id:int}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var accId= await adminAccService.GetAccountById(Id);
            return Ok(accId);
        }
    }
}
