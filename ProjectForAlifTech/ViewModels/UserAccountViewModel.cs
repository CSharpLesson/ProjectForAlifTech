using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public record UserAccountViewModel(string Name, decimal Balance,string UserName);      
}
