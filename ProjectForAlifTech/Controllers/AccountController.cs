using ElectronWallet.Helper;
using ElectronWallet.Services.AccountHostoryService;
using ElectronWallet.Services.AccountService;
using ElectronWallet.ViewModels;
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
        IAccountHistoryService _accountHistoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService, IAccountHistoryService accountHistoryService)
        {
            _accountService = accountService;
            _accountHistoryService = accountHistoryService;
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
        [HttpPost]
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
        public ResponceCoreData Credite([FromBody] AccountCreditModel model) 
        {
            return _accountService.Credit(XUserId,XDigest ,model.Sum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]        
        public ResponceCoreData GetWaller() 
        {
            return _accountService.GetWaller(XUserId,XDigest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponceCoreData GetHistory([FromBody] HistoryParamViewModel model) 
        {
            return _accountHistoryService.GetHistory(model, new UserLoginViewModel(XUserId, XDigest));
        }
    }
}
