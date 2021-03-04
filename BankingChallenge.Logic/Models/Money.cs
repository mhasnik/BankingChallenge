using System;

namespace BankingChallenge.Logic.Models
{

    // Creating a type for Money for 2 reasons:
    // 1. It's much easier to extend it (f.e. currency) without changing signatures throughout the system
    // 2. It's harder to make a mistake (f.e. having two decimals representing something completely different
    //    makes code more error prone)
    
    public readonly struct Money : IEquatable<Money>, IComparable<Money>, IComparable
    {
        public readonly decimal Amount;

        public Money(decimal amount)
        {
            Amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        }

        public bool Equals(Money other)
        {
            return Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            return obj is Money other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }

        public static bool operator ==(Money left, Money right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(Money other)
        {
            return Amount.CompareTo(other.Amount);
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }

            return obj is Money other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(Money)}");
        }

        public static bool operator <(Money left, Money right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Money left, Money right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Money left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Money left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }

        public override string ToString()
        {
            return $"{Amount} kr.";
        }
    }
}