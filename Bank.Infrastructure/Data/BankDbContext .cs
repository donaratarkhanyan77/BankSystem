using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Data;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CUSTOMER
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Customer>()
            .Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);

        // ACCOUNT
        modelBuilder.Entity<Account>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Account>()
            .Property(a => a.AccountNumber)
            .IsRequired()
            .HasMaxLength(20);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}