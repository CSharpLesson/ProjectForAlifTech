using Microsoft.EntityFrameworkCore;

namespace ElectronWaller.DataContexts
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContext:DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionString { get; set; }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
    }
}
