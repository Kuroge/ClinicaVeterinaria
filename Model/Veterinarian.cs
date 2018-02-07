using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Veterinarian : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Kind> Species { get; set; }
    }
}
