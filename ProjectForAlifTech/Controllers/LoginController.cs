using ElectronWallet.Helper;
using ElectronWallet.Services.UserService;
using ElectronWallet.ViewModels;
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
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponceCoreData Token(UserLoginViewModel userLogin) 
        {
            return _userService.Login(userLogin);
        }
    }
}
