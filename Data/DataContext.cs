using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace APICoreManagementRepo.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options) { }
         public DbSet<User> User { get; set; }
    }
}