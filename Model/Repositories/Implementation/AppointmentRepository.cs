using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.Repositories.Implementation
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public AppointmentRepository(ClinicContext context) : base(context)
        {
        }

        public override Appointment Add(Appointment item)
        {
            if (this.context.Appointments
                .Where(
                    x => x.Date.Year == item.Date.Year && 
                    x.Date.DayOfYear == item.Date.DayOfYear && 
                    x.Date.Hour == item.Date.Hour
                 ).Any())
            {
                throw new ArgumentException("Ya hay una cita con esa hora");
            }
            else
            {
                base.Add(item);
            }
            return item;
        }
    }
}
