using ElectronWaller.Models;
using ElectronWallet.Models;
using Microsoft.EntityFrameworkCore;
using ElectronWallet.Helper;

namespace ElectronWaller.DataContexts
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<AccountHistory> AccountHistories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, XUserId = "ibrohim_ii", XDigest = GenerateHash.HashHmac("ibrohimii"), IsActive = true },
                new User() { Id = 2, XUserId = "akrom_ia", XDigest = GenerateHash.HashHmac("sky"), IsActive = false });

            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount() {Id = 1, Name="Click.uz", UserId = 1, Balance = 50000},
                new UserAccount() { Id = 2, Name = "Apelsin", UserId = 2, Balance = 6000 });
        }
    }
}
