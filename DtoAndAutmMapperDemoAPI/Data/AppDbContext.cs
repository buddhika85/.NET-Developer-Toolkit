using DtoAndAutmMapperDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DtoAndAutmMapperDemoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // tables
        public DbSet<Person> People => Set<Person>();
    }
}