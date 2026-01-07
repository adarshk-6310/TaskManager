using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.DBClass
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
