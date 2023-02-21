using System.Collections;
using Application.Infrastructure;
using System;
using System.Collections.Generic;

namespace Application.Models.Auction
{
    public class Money : ValueObject<Money>, IComparable<Money>
    {
        protected decimal Value { get; set; }
        public Money() : this(0m) { }
        public Money(decimal value)
        {
            ThrowExceptionIfValueIsInvalid(value);
            Value = value;
        }

        private void ThrowExceptionIfValueIsInvalid(decimal value)
        {
            if (value % 0.01m != 0) throw new MoreThanTwoDecimalPlacesException();

            if (value < 0) throw new MoneyCanNotBeNegativeValueException();
        }

        public Money Add(Money money)
        {
            return new Money(Value + money.Value);
        }

        public bool IsGreaterThan(Money money)
        {
            return Value > money.Value;
        }

        public bool IsGreaterThanOrEqualTo(Money money)
        {
            return Value > money.Value || this.Equals(money);
        }

        public bool IsLessThanOrEqualTo(Money money)
        {
            return Value < money.Value || this.Equals(money);
        }

        public int CompareTo(Money? other)
        {
            return Value.CompareTo(other?.Value);
        }



        protected override IEnumerable<object> GetAttributesToIncludeEqualityCheck()
        {
            return new List<object> { Value };
        }

        public override string ToString()
        {
            return string.Format("{0}", Value);
        }
    }
}