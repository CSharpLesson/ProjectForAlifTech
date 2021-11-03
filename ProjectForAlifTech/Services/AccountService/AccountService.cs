using ElectronWaller.DataContexts;
using ElectronWallet.Helper;
using ElectronWallet.Models;
using ElectronWallet.Services.UserService;
using ElectronWallet.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.Services.AccountService
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public ResponceCoreData Credit(string Id, string digest, decimal sum)
        {
            try
            {
                return TryCredit(Id, digest, sum);
            }
            catch (Exception ex)
            {
                return new ResponceCoreData(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private ResponceCoreData TryCredit(string id, string digest, decimal sum)
        {
            var user = _userService.GetById(id);
            if (user == null || user.XUserId != id && user.XDigest != digest)
                throw new Exception("X-UserId yoki X-Digest noto'g'ri");

            var account = _context.UserAccounts.FirstOrDefault(f => f.UserId == user.Id);
            if (account != null)
            {
                account.Balance += sum;
                if (user.IsActive && account.Balance > 100000)
                    throw new Exception("Eng ko'pi bilan 100000 bo'ladi");
                else if (!user.IsActive && account.Balance > 10000)
                    throw new Exception("Eng ko'pi bilan 10000 bo'ladi");

                _context.UserAccounts.Update(account);
                _context.SaveChanges();

                AddHistory(user.Id, account, sum);

                return new ResponceCoreData();
            }
            else
                throw new Exception("Bunday hamyon mavjud emas");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="account"></param>
        private void AddHistory(int id, Models.UserAccount account, decimal sum)
        {
            var history = new AccountHistory();
            history.AccountId = account.Id;
            history.UserId = id;
            history.Date = DateTime.Now;
            history.OldBalance = account.Balance - sum;
            history.Balance = account.Balance;
            _context.AccountHistories.Add(history);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResponceCoreData GetBalance(string userId, string digest)
        {
            try
            {
                return TryGetBalance(userId, digest);
            }
            catch (Exception ex)
            {
                return new ResponceCoreData(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private ResponceCoreData TryGetBalance(string userId, string digest)
        {
            var user = _userService.GetById(userId);
            if (user == null || user.XUserId != userId && user.XDigest != digest)
                throw new Exception("X-UserId yoki X-Digest noto'g'ri");
            var account = _context.UserAccounts.FirstOrDefault(f => f.UserId == user.Id);

            if (account == null)
                throw new Exception("Bunday hamyon mavjud emas");

            return new ResponceCoreData(account.Balance);
        }

        public ResponceCoreData GetWaller(string userId, string digest)
        {
            try
            {
                return TryGetWaller(userId, digest);
            }
            catch (Exception ex)
            {
                return new ResponceCoreData(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private ResponceCoreData TryGetWaller(string userId, string digest)
        {
            var user = _userService.GetById(userId);
            if (user == null || user.XUserId != userId && user.XDigest != digest)
                throw new Exception("X-UserId yoki X-Digest noto'g'ri");

            var account = _context.UserAccounts.FirstOrDefault(f => f.UserId == user.Id);
            if (account == null)
                throw new Exception("Bunday hamyon mavjud emas");

            var accountViewMode = new UserAccountViewModel(account.Name, account.Balance, account.UserModel?.XUserId);

            return new ResponceCoreData(accountViewMode);
        }
    }
}
