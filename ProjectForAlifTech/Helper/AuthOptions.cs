using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronWallet.Helper
{
    public class AuthOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ISSUER = "MyAuthServer"; // издатель токена

        /// <summary>
        /// 
        /// </summary>
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена

        /// <summary>
        /// 
        /// </summary>
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации

        /// <summary>
        /// 
        /// </summary>
        public const int LIFETIME = 1; // время жизни токена - 1 минута

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
