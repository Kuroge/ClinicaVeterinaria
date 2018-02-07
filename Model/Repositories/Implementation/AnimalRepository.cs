using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repositories.Implementation
{
    public class AnimalRepository : GenericRepository<Animal>
    {
        public AnimalRepository(ClinicContext context) : base(context)
        {
        }

        public override Animal Add(Animal item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ArgumentNullException("El nombre no puede estar en blanco");
            }
            return base.Add(item);
        }
    }
}
