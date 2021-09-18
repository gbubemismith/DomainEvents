using System;
using domainEvents.Entities;
using domainEvents.Interfaces;
using domainEvents.Shared;

namespace domainEvents.Events
{
    public class AppointmentCreated : IDomainEvent
    {
        public Appointment Appointment { get; set; }
        public DateTime DateTimeOccured { get; set; }

        public AppointmentCreated(Appointment appointment, DateTime dateCreated)
        {
            Appointment = appointment;
            DateTimeOccured = dateCreated;
        }

        public AppointmentCreated(Appointment appointment) : this(appointment, DateTime.Now)
        {

        }
    }
}