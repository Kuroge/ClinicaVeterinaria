using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Appointment : Entity
    {
        public Clinic Clinic { get; set; }

        public Veterinarian Veterinarian { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public Animal Animal { get; set; }

        public DateTime Date { get; set; }

    }
}
