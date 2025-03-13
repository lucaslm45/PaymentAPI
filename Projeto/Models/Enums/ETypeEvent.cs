using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Projeto.Models.Enums {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ETypeEvent {
        [EnumMember(Value = "deposit")]
        Deposit,

        [EnumMember(Value = "withdraw")]
        Withdraw,

        [EnumMember(Value = "transfer")]
        Transfer
    }
}
