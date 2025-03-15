using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaymentAPI.Models.Enums {
    /// <summary>
    /// Enum that represents the different types of banking transaction events.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]  // Converts the enum to and from strings during JSON serialization/deserialization
    public enum ETypeEvent {
        /// <summary>
        /// Represents a deposit transaction.
        /// </summary>
        [EnumMember(Value = "deposit")]  // Defines the corresponding value in JSON
        Deposit,

        /// <summary>
        /// Represents a withdrawal transaction.
        /// </summary>
        [EnumMember(Value = "withdraw")]
        Withdraw,

        /// <summary>
        /// Represents a transfer transaction between accounts.
        /// </summary>
        [EnumMember(Value = "transfer")]
        Transfer
    }
}