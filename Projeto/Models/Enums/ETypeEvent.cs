using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Projeto.Models.Enums {
    /// <summary>
    /// Enum que representa os diferentes tipos de eventos de transação bancária.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]  // Converte o enum para e de strings durante a serialização/deserialização JSON
    public enum ETypeEvent {
        /// <summary>
        /// Representa uma transação de depósito.
        /// </summary>
        [EnumMember(Value = "deposit")]  // Define o valor correspondente no JSON
        Deposit,

        /// <summary>
        /// Representa uma transação de saque.
        /// </summary>
        [EnumMember(Value = "withdraw")]
        Withdraw,

        /// <summary>
        /// Representa uma transação de transferência entre contas.
        /// </summary>
        [EnumMember(Value = "transfer")]
        Transfer
    }
}
