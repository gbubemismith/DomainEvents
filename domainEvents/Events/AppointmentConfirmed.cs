using System;
using domainEvents.Entities;
using domainEvents.Interfaces;
using domainEvents.Shared;

namespace domainEvents.Events
{
    public class AppointmentConfirmed : BaseDomainEvent
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