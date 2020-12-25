using System.Runtime.Serialization;
using SomeApplication.Business.Model;

namespace SomeApplication.Business.DTO
{
    [DataContract]
    public class MoneyAmountDTO
    {
        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public string Currency { get; set; }

        public MoneyAmount ToMoneyAmount()
        {
            return new MoneyAmount(this.Amount, this.Currency);
        }

        public static MoneyAmountDTO From(MoneyAmount moneyAmount)
        {
            var value = moneyAmount ?? new MoneyAmount();
            return new MoneyAmountDTO
            {
                Amount = moneyAmount.Amount,
                Currency = moneyAmount.Currency
            };
        }
    }
}
