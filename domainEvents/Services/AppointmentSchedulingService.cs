using System.Threading.Tasks;
using domainEvents.Entities;
using domainEvents.Interfaces;

namespace domainEvents.Services
{
    public class AppointmentSchedulingService
    {
        private readonly IRepository<Appointment> _appointmentRepo;

        public AppointmentSchedulingService(IRepository<Appointment> appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public Task ScheduleAppointment(string email)
        {
            var appointment = Appointment.Create(email);
            return _appointmentRepo.Save(appointment);
        }
    }
}