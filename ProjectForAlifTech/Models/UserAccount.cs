using ElectronWaller.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ElectronWallet.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("user_account")]
    public class UserAccount
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
        [Column("name")]
        public string Name { get; set; }

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
        [Column("balance")]
        public decimal Balance { get; set; }
    }
}
