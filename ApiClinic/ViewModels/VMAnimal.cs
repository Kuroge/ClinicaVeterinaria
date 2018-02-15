using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClinic.ViewModels
{
    public class VMAnimal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public string KindName { get; set; }
    }
}
