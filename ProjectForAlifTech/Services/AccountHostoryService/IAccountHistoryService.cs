using ElectronWallet.Helper;
using ElectronWallet.ViewModels;

namespace ElectronWallet.Services.AccountHostoryService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountHistoryService
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="model"></param>
       /// <param name="loginModel"></param>
       /// <returns></returns>
        ResponceCoreData GetHistory(HistoryParamViewModel model, UserLoginViewModel loginModel);
    }
}
