using System;

namespace domainEvents.Exceptions
{
    public class InvalidAggregateIdException : DomainException
    {
        public Guid Id { get; }
        public InvalidAggregateIdException(Guid id) : base($"Invalid aggregate ID: '{id}'.")
        {

        }
    }
}