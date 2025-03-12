using EBANX.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBANX.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccountEntity> Accounts { get; set; }

    }
}
