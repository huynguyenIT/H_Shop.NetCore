﻿using DataAndServices.Admin_Services.AccountService;
using DataAndServices.Data;
using DataAndServices.DataModel;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Admin
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AccountController( IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<bool> UpdateCustomer([FromForm] Account model)
        {
            try
            {
                return await accountService.UpdateCustomer(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpPost]
        [Route("InsertAccount")]
        public async Task<bool> InsertCustomer(Account cusInsert)
        {
            try
            {
                return await accountService.InsertCustomer(cusInsert);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpGet]
        [Route("GetLoginResultByEmailPassword")]
        public async Task<Account> GetLoginResultByEmailPassword(string user, string pass)
        {
            try
            {
                log.Info("Successful to response login result.");
                return await accountService.LoginCustomer(user, pass);
            }
            catch (Exception)
            {
                log.Error("Cannot response login result.");
                throw;
            }
        }
        [Route("GetAccountById")]
        public async Task<Account> GetAccountById(string id)
        {
            try
            {
                return await accountService.GetCustomerByID(id);
            }
            catch (Exception)
            {
                log.Error("Cannot response result.");
                throw;
            }
        }
        [Route("GetAccountByEmail")]
        public async Task<Account> GetAccountByEmail(string email)
        {
            try
            {
                return await accountService.GetCustomerByEmail(email);
            }
            catch (Exception)
            {
                log.Error("Cannot response result.");
                throw;
            }
        }
    }
}
