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
        public AccountService(DataContext context,IUserService userService)
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
        public ResponceCoreData Credit(int Id, decimal sum)
        {
            try
            {
                return TryCredit(Id, sum);
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
        private ResponceCoreData TryCredit(int id, decimal sum)
        {
            var user = _userService.GetById(id);
            var account = _context.UserAccounts.FirstOrDefault(f => f.UserId == id);

            if (account != null)
            {
                account.Balance += sum;
                if (user.IsActive && account.Balance > 100000)
                    throw new Exception("Eng ko'pi bilan 100000 bo'ladi");
                else if(!user.IsActive && account.Balance > 10000)
                    throw new Exception("Eng ko'pi bilan 10000 bo'ladi");

                _context.UserAccounts.Update(account);
                _context.SaveChanges();

                AddHistory(id, account,sum);

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
        private void AddHistory(int id, Models.UserAccount account,decimal sum)
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
        /// <param name="Id"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public ResponceCoreData Debit(int Id, decimal sum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResponceCoreData GetBalance(int userId)
        {
            try
            {
                return TryGetBalance(userId);
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
        private ResponceCoreData TryGetBalance(int userId)
        {
            var account = _context.UserAccounts.FirstOrDefault(f => f.UserId == userId);

            if (account == null)
                throw new Exception("Bunday hamyon mavjud emas");

            return new ResponceCoreData(account.Balance);
        }

        public ResponceCoreData GetWaller(int userId)
        {
            try
            {
                return TryGetWaller(userId);
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
        private ResponceCoreData TryGetWaller(int userId)
        {
            var account = _context.UserAccounts.Include(s=>s.UserModel).FirstOrDefault(f => f.UserId == userId);
            if(account==null)
                throw new Exception("Bunday hamyon mavjud emas");

            var accountViewMode = new UserAccountViewModel(account.Name, account.Balance, account.UserModel?.XUserId);

            return new ResponceCoreData(accountViewMode);
        }
    }
}
