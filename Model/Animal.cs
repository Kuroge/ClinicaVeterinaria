using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Animal : Entity
    {

        public string Name { get; set; }

        public Client Owner { get; set; }

        public Kind Species { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
