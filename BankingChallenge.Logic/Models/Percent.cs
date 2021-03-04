using System;

namespace BankingChallenge.Logic.Models
{
    public readonly struct Percent : IEquatable<Percent>, IComparable<Percent>, IComparable
    {
        public readonly decimal Value;

        public Percent(decimal value)
        {
            Value = value;
        }

        public decimal ToFraction() => Value / 100;

        public int CompareTo(Percent other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }

            return obj is Percent other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(Percent)}");
        }

        public static bool operator <(Percent left, Percent right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Percent left, Percent right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Percent left, Percent right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Percent left, Percent right)
        {
            return left.CompareTo(right) >= 0;
        }

        public bool Equals(Percent other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Percent other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Percent left, Percent right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percent left, Percent right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"{Value}%";
        }
    }
}