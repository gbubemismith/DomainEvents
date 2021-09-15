using System;

namespace domainEvents.Exceptions
{
    public abstract class DomainException : Exception
    {
        public virtual string code { get; }

        protected DomainException(string message) : base(message)
        {

        }
    }
}