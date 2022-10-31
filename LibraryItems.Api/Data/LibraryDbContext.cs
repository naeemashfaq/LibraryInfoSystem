using Microsoft.EntityFrameworkCore;
using LibraryItems.Api.Entities;

namespace LibraryItems.Api.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public DbSet<LibraryItem> Items { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

