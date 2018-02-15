using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClinic.ViewModels
{
    public class VMClientAnimal
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, ErrorMessage = "Max length is 30")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(9, ErrorMessage = "Length must be 9")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "ID is required")]
        public long Id { get; set; }
        public IEnumerable<Animal> Animals { get; set; }
    }
}
