using System;
using System.Threading;
using System.Threading.Tasks;
using domainEvents.Events;
using MediatR;

namespace domainEvents.Handlers
{
    public class NotifyUserAppointmentCreated : INotificationHandler<AppointmentCreated>
    {
        public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
        {
            string emailAddress = notification.Appointment.EmailAddress;
            // ConsoleWriter.FromEmailEventHandlers("[EMAIL] Notification email sent to {0}", emailAddress);
            Console.WriteLine("[EMAIL] Notification email sent to {0}", emailAddress);

            return Task.CompletedTask;
        }
    }
}