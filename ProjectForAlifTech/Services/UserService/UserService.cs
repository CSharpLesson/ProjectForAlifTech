using ElectronWaller.DataContexts;
using ElectronWaller.Models;
using ElectronWallet.Helper;
using ElectronWallet.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectronWallet.Services.UserService
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : IUserService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponceCoreData Login(UserLoginViewModel model)
        {
            try
            {
                return TryLogin(model);
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
        private ResponceCoreData TryLogin(UserLoginViewModel model)
        {            
            var user = _context.Users.FirstOrDefault(f => f.XUserId == model.XUserId && f.XDigest == model.XDigest );
            if (user != null)
                return new ResponceCoreData();

            return new ResponceCoreData(new Exception("Bunday foydalanuvchi mavjud emas"));
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(f => f.XUserId == id);
        }
    }
}
