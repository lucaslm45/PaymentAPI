namespace PaymentAPI.Business.Services.Interfaces {
    /// <summary>
    /// Interface responsável por definir operações para resetar o banco de dados.
    /// </summary>
    public interface IResetService {
        /// <summary>
        /// Reseta o banco de dados, excluindo e recriando as tabelas.
        /// </summary>
        /// <returns>
        /// Um <see cref="IResult"/> representando o resultado da operação.
        /// </returns>
        IResult Reset();
    }
}
