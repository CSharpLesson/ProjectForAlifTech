using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectForAlifTech.Models
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
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }
    }
}
