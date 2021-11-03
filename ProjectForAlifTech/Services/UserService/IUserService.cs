using ElectronWallet.Helper;
using ElectronWallet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.Services.UserService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xUserId"></param>
        /// <param name="xDidets"></param>
        /// <returns></returns>
        ResponceCoreData Login(UserLoginViewModel model);
    }
}
