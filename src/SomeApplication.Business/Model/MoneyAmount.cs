namespace SomeApplication.Business.Model
{
    public class MoneyAmount
    {
        public MoneyAmount(decimal amount = 0, string currency = "ARS")
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public decimal Amount { get; }

        public string Currency { get; }

        public override bool Equals(object obj) =>
            this.Equals(obj as MoneyAmount);

        public bool Equals(MoneyAmount other) =>
            other != null &&
            this.Amount == other.Amount &&
            this.Currency == other.Currency;

        public override int GetHashCode() =>
            this.Amount.GetHashCode() ^ this.Currency.GetHashCode();

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);

        public static MoneyAmount operator *(MoneyAmount amount, int quantity) => 
            new MoneyAmount(amount.Amount * quantity, amount.Currency);

        public static MoneyAmount operator *(int quantity, MoneyAmount amount) => amount * quantity;
    }
}