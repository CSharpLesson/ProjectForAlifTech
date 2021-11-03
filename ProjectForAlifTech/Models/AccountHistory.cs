using ElectronWaller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ElectronWallet.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("account_history")]
    public class AccountHistory
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        [ForeignKey(nameof(UserModel))]
        public int UserId { get; set; }

        [IgnoreDataMember]
        public virtual User UserModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("account_id")]
        [ForeignKey(nameof(AccountModel))]
        public int AccountId { get; set; }

        [IgnoreDataMember]
        public virtual UserAccount AccountModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("old_balance")]
        public decimal OldBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
