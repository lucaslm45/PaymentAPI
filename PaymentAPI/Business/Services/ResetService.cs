using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Data;

namespace PaymentAPI.Business.Services {
    public class ResetService : IResetService {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetService"/> with database context injection.
        /// </summary>
        /// <param name="context">The database context used to manage data persistence.</param>
        public ResetService(AppDbContext context) {
            _context = context;
        }

        /// <summary>
        /// Resets the database by deleting and recreating all tables.
        /// </summary>
        /// <returns>An HTTP result indicating success or failure of the operation.</returns>
        public IResult Reset() {
            try {
                // Deletes and recreates the database to ensure a clean initial state.
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                return Results.Content("OK", "text/plain");
            }
            catch (Exception) {
                // Returns an error if the operation fails.
                return Results.NotFound();
            }
        }
    }
}
