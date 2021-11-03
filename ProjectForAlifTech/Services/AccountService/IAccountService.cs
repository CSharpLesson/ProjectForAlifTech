using ElectronWallet.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.Services.AccountService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        ResponceCoreData Credit(string Id, string digest, decimal sum);       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponceCoreData GetBalance(string userId, string digest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponceCoreData GetWaller(string userId, string digest);
    }
}
