namespace PaymentAPI.Business.Services.Interfaces {
    /// <summary>
    /// Interface responsible for defining operations to reset the database.
    /// </summary>
    public interface IResetService {
        /// <summary>
        /// Resets the database by deleting and recreating the tables.
        /// </summary>
        /// <returns>
        /// An <see cref="IResult"/> representing the result of the operation.
        /// </returns>
        IResult Reset();
    }
}
