using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronWallet.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public record HistoryViewModel(string UserName, string AccountName, DateTime Date, decimal OldBalance, decimal Balance);
}
