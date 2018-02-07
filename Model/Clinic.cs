using System;
using System.Collections.Generic;

namespace Model
{
    public class Clinic : Entity
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Veterinarian> Veterinarians { get; set; }

    }
}
