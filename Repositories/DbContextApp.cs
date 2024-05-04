using ecoapp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ecoapp.Repositories
{//password sha256 abc123
    public class DbContextApp(DbContextOptions<DbContextApp> options) : DbContext(options)
    {
        private string ConnectionString;

        public DbSet<ExpenseModel> Expenses { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).UseIdentityColumn();
            });
            modelBuilder.Entity<UserModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).UseIdentityColumn();
            });
            modelBuilder.Entity<LogModel>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).UseIdentityColumn();
                e.HasOne(e => e.User).WithMany(e => e.Logs).HasForeignKey(e => e.UserId);
            });
        }
    }
}
