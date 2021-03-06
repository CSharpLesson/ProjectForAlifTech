using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronWaller.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("user")]
    public class User
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
        [Column("x-user_id")]
        public string XUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("x-digest")]
        public string XDigest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }
    }
}
