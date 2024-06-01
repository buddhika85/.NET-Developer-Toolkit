
using CommandAPINoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPINoRepository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // tables
        public DbSet<Command> Commands => Set<Command>();
    }
}