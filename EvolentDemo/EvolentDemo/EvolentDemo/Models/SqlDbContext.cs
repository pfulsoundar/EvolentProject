using System.Data.Entity;

namespace EvolentDemo.Models
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext() : base("name=SqlConn")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}