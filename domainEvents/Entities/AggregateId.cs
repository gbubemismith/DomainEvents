using System;
using System.Diagnostics.CodeAnalysis;
using domainEvents.Exceptions;

namespace domainEvents.Entities
{
    //value object
    public class AggregateId : IEquatable<AggregateId>
    {
        public Guid Value { get; }

        public AggregateId(Guid value)
        {
            if (value == Guid.Empty)
                throw new InvalidAggregateIdException(value);

            Value = value;

        }
        public AggregateId() : this(Guid.NewGuid())
        {

        }

        public bool Equals([AllowNull] AggregateId other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AggregateId)obj);
        }

        // override object.GetHashCode
        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator Guid(AggregateId id) => id.Value;

        public static implicit operator AggregateId(Guid id) => new AggregateId(id);

        public override string ToString() => Value.ToString();
    }
}