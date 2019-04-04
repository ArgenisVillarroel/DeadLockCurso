using AccountinManager.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountinManager.Data
{
    public class AccountManagerContext : DbContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts  { get; set; }

        public AccountManagerContext(DbContextOptions<AccountManagerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<AccountType>()
               .HasIndex(e => e.Code)
               .IsUnique(true);

            modelBuilder.Entity<Account>()
                .HasKey(e=>e.Id);

            modelBuilder.Entity<Account>()
                .HasIndex(e => e.Code)
                .IsUnique(true);

            modelBuilder.Entity<Account>()
                .HasOne(e => e.AccountType)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.AccountTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
