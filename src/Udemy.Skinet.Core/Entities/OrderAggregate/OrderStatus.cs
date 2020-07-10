using System.Runtime.Serialization;

namespace Udemy.Skinet.Core.Entities.OrderAggregate {
    public enum OrderStatus {
        [EnumMember(Value = nameof(Pending))]
        Pending,

        [EnumMember(Value = "Payment Received")]
        PaymentRecieved,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
