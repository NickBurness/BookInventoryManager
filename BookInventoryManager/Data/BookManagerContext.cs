using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookInventoryManager.Models;

namespace BookInventoryManager.Data
{
    public class BookManagerContext : DbContext
    {
        public BookManagerContext(DbContextOptions<BookManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
