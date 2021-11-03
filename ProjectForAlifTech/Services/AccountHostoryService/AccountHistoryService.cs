using ElectronWaller.DataContexts;
using ElectronWallet.Helper;
using ElectronWallet.Services.UserService;
using ElectronWallet.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.Services.AccountHostoryService
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountHistoryService : IAccountHistoryService
    {
        /// <summary>
        /// 
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountHistoryService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponceCoreData GetHistory(HistoryParamViewModel model, UserLoginViewModel loginModel)
        {
            try
            {
                return TryGetHistory(model,loginModel);
            }
            catch (Exception ex)
            {
                return new ResponceCoreData(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private ResponceCoreData TryGetHistory(HistoryParamViewModel model, UserLoginViewModel loginModel)
        {
            var user = _userService.GetById(loginModel.XUserId);
            if (user == null || user.XUserId != loginModel.XUserId && user.XDigest != loginModel.XDigest)
                throw new Exception("X-UserId yoki X-Digest noto'g'ri");

            var historys = _context.AccountHistories
                .Include(s=>s.AccountModel)
                .Include(z => z.UserModel)
                .Where(f => f.Date.Date >= model.startDate.Date && f.Date.Date <= model.endDate.Date)
                .Select(s=>new HistoryViewModel(s.UserModel.XUserId, s.AccountModel.Name, s.Date, s.OldBalance, s.Balance));

            return new ResponceCoreData(historys);

        }
    }
}
