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
        ResponceCoreData Credit(int Id, decimal sum);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        ResponceCoreData Debit(int Id, decimal sum);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponceCoreData GetBalance(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponceCoreData GetWaller(int userId);
    }
}
