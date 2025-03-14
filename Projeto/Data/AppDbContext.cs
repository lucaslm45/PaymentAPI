using Projeto.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Data {
    /// <summary>
    /// Representa o contexto de banco de dados para a aplicação.
    /// Contém as entidades de contas e transações.
    /// </summary>
    public class AppDbContext : DbContext {
        /// <summary>
        /// Inicializa uma nova instância do contexto de banco de dados.
        /// </summary>
        /// <param name="options">As opções de configuração para o contexto.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Obtém ou define a coleção de contas no banco de dados.
        /// </summary>
        public DbSet<AccountEntity> Accounts { get; set; }
        /// <summary>
        /// Obtém ou define a coleção de transações no banco de dados.
        /// </summary>
        public DbSet<TransactionEntity> Transactions { get; set; }

        /// <summary>
        /// Configura o modelo de dados para as entidades no contexto de banco de dados.
        /// </summary>
        /// <param name="modelBuilder">O modelo de dados que está sendo configurado.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Relacionamento entre TransactionEntity e AccountEntity para Origin
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.Origin)
                .WithMany()
                .HasForeignKey(t => t.OriginId)
                .OnDelete(DeleteBehavior.Restrict); // Evita remoção em cascata

            // Relacionamento entre TransactionEntity e AccountEntity para Destination
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.Destination)
                .WithMany()
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
