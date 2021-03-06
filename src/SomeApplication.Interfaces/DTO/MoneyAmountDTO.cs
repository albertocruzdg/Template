﻿using System.Runtime.Serialization;
using System.Text;
using SomeApplication.Business.Model;

namespace SomeApplication.Interfaces.DTO
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
            if (moneyAmount is null)
            {
                return null;
            }

            return new MoneyAmountDTO
            {
                Amount = moneyAmount.Amount,
                Currency = moneyAmount.Currency
            };
        }
    }
}
