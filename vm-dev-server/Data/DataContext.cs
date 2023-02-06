using Microsoft.EntityFrameworkCore;

namespace vm_dev_server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option): base(option) {  }

        public DbSet<Experience> Experiences { get; set; }
        
        public DbSet<Projects> Projects { get; set; }
    }
}
