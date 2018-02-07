using Model;
using Model.Repositories;
using Model.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModelTest
{
    
    public class AppointmentRepositoryTest
    {
        public IRepository<Appointment> repository;
        public AppointmentRepositoryTest()
        {
            ClinicContext context = new ClinicContext();
            this.repository = new AppointmentRepository(context);
            context.Appointments.Add(new Appointment() { Date = new DateTime(2018, 11, 11, 11, 11, 11) });
        }

        [Fact]
        public void AppointmentRepository_Add_SameDate_Exception()
        {
            //Arrange declarado en el cosntructor
            //Act
            Action testCode = () => this.repository.Add(new Appointment() { Date = new DateTime(2018, 11, 11, 11, 34, 14) });

            //Assert
            Assert.Throws<ArgumentException>(testCode);
            
        }

    }
}
