using EBANX.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBANX.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.Origin)
                .WithMany()
                .HasForeignKey(t => t.OriginId)
                .OnDelete(DeleteBehavior.Restrict); // Evita remoção em cascata

            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.Destination)
                .WithMany()
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
