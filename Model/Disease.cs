using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Disease : Entity
    {
        public string Name { get; set; }

        public ICollection<Kind> Affect { get; set; }

    }
}
