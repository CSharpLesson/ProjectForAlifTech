using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ElectronWallet.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class GenerateHash
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signatureString"></param>
        /// <returns></returns>
        public static string hash_hmac(string signatureString)
        {
            string secretKey = "aliftech";
            HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey));
            byte[] buffer = Encoding.UTF8.GetBytes(signatureString);
            string result = BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
        }
    }
}
