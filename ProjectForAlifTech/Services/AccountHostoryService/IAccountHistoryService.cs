using ElectronWallet.Helper;
using System;

namespace ElectronWallet.Services.AccountHostoryService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountHistoryService
    {
        ResponceCoreData GetHistory();
    }
}
