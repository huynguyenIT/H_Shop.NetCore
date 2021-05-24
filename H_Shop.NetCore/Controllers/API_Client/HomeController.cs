using DataAndServices.Client_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Client
{
    [Route("api/Home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices _homeServices;
        public HomeController(IHomeServices homeServices)
        {
            _homeServices = homeServices;
        }
        [HttpGet]
        [Route("GetAllItemType")]
        public async Task<IActionResult> GetAllItemType()
        {
           var listItemType= await _homeServices.GetAllItemType();
            return Ok(listItemType);
        }
    }
}
