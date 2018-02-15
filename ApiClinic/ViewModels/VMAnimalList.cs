using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClinic.ViewModels
{
    public class VMAnimalList
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int ClientId { get; set; }

        public int SpecieId { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; }

        public IEnumerable<SelectListItem> Species { get; set; }
    }
}
