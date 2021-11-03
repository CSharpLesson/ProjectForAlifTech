using Microsoft.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponceCoreData
    {
        /// <summary>
        /// 
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; } = 400;

        /// <summary>
        /// 
        /// </summary>
        public bool Succsess { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public ResponceCoreData(object result)
        {
            Result = result;
            StatusCode = 200;
            Error = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public ResponceCoreData(Exception error)
        {
            HttpContextHelper.SetStatusCode(ResponseStatusCode.BadRequest);
            Result = null;
            StatusCode = 400;
            Error = error.Message;
            Succsess = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public ResponceCoreData()
        {
            Result = null;
            StatusCode = 200;
            Error = null;
            Succsess = true;
        }
    }
}
