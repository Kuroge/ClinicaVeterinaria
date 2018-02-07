using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.Repositories.Implementation
{
    public class VeterinarianRepository : IRepository<Veterinarian>
    {
        private ClinicContext context;

        public VeterinarianRepository(ClinicContext context)
        {
            this.context = context;
        }
        public Veterinarian Add(Veterinarian item)
        {
            this.context.Veterinarians.Add(item);
            return item;
        }

        public IEnumerable<Veterinarian> Get()
        {
            return this.context.Veterinarians;
        }

        public Veterinarian GetById(int id)
        {

            return this.context.Veterinarians.Where(x => x.Id == id).FirstOrDefault();

        }

        public void Remove(Veterinarian item)
        {
            this.context.Veterinarians.Remove(item);
        }

        public Veterinarian Update(Veterinarian item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("El veterinario no puede ser nulo");
            }
            else
            {
                var actualItem = this.GetById(item.Id);
                if (item.Equals(actualItem))
                {
                    return item;
                }
                else
                {
                    
                    this.Remove(actualItem);
                    this.Add(item);
                    return item;
                }
            }
            

        }
    }
}
