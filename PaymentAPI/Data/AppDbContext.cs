using PaymentAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Data {
    /// <summary>
    /// Represents the database context for the application.
    /// Contains the entities for accounts, transactions and account transactions.
    /// </summary>
    public class AppDbContext : DbContext {
        /// <summary>
        /// Initializes a new instance of the database context.
        /// </summary>
        /// <param name="options">The configuration options for the context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the collection of accounts in the database.
        /// </summary>
        public DbSet<AccountEntity> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the collection of transactions in the database.
        /// </summary>
        public DbSet<TransactionEntity> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the collection of account transactions in the database.
        /// </summary>
        public DbSet<AccountTransactionEntity> AccountTransactions { get; set; }

        /// <summary>
        /// Configures the data model for the entities in the database context.
        /// </summary>
        /// <param name="modelBuilder">The data model that is being configured.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Many-to-many relationship between AccountEntity and TransactionEntity
            modelBuilder.Entity<AccountTransactionEntity>()
                .HasKey(at => new { at.AccountId, at.TransactionId });  // Composes the primary keys

            // Relationship between AccountTransactionEntity and AccountEntity
            modelBuilder.Entity<AccountTransactionEntity>()
                .HasOne(at => at.Account)
                .WithMany(a => a.AccountTransaction)
                .HasForeignKey(at => at.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            // Relationship between AccountTransactionEntity and TransactionEntity
            modelBuilder.Entity<AccountTransactionEntity>()
                .HasOne(at => at.Transaction)
                .WithMany(t => t.AccountTransaction)
                .HasForeignKey(at => at.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
