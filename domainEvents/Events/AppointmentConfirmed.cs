using System;
using domainEvents.Entities;
using domainEvents.Interfaces;

namespace domainEvents.Events
{
    public class AppointmentConfirmed : IDomainEvent
    {
        public Appointment Appointment { get; set; }
        public DateTime DateTimeOccured { get; private set; }

        public AppointmentConfirmed(Appointment appointment, DateTime dateConfirmed)
        {
            Appointment = appointment;
            DateTimeOccured = dateConfirmed;
        }

        public AppointmentConfirmed(Appointment appointment) : this(appointment, DateTime.Now)
        {

        }
    }
}