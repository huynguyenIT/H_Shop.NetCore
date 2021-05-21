using DataAndServices.Admin_Services.Admin_Acc_Services;
using DataAndServices.Admin_Services.UserAccServices;
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
        private readonly IUserAccService _userAccService;

        public User_AccController(IUserAccService userAccService)
        {
            _userAccService = userAccService;
        }
        [Route("Update")]
        public async Task<bool> Update(User_Acc User_Acc)
        {
            return await _userAccService.Update_Ad_acc(User_Acc);
        }
        [Route("Update2")]
        public async Task<bool> Update2(User_Acc User_Acc)
        {
            return await _userAccService.Update_Ad_acc2(User_Acc);
        }
        [Route("DeleteUser_Acc/{id}")]
        public async Task<IActionResult> DeleteUser_Acc(int id)
        {
            await _userAccService.DeleteUser_Acc(id);
            return NoContent();
        }
        [HttpGet]
        [Route("GetAllUser_Accs")]
        public async Task<IActionResult> GetAllUser_Accs()
        {
            var listUser_Acc = await _userAccService.GetAllUser_Accs();
            return Ok(listUser_Acc);
        }
        [HttpGet]
        [Route("GetUser_AccById/{id}")]

        public async Task<IActionResult> GetUser_AccById(string Id)
        {
            var accId = await _userAccService.GetUser_AccById(Id);
            return Ok(accId);
        }
    }
}
