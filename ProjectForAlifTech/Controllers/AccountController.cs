using ElectronWallet.Helper;
using ElectronWallet.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]    
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        IAccountService _accountService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 
        /// </summary>
        private string XUserId
        {
            get { return  Request.Headers["x-userId"];}
        }

        /// <summary>
        /// 
        /// </summary>
        private string XDigest
        {
            get { return Request.Headers["x-digest"]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponceCoreData GetBalance() 
        {            
            return _accountService.GetBalance(XUserId,XDigest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sum"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponceCoreData Credite([FromBody] decimal Sum) 
        {
            return _accountService.Credit(XUserId,XDigest ,Sum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public ResponceCoreData GetWaller() 
        {
            return _accountService.GetWaller(XUserId,XDigest);
        }
    }
}
