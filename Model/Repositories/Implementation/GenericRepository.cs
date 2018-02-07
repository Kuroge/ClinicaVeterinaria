using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Model.Repositories.Implementation
{
   public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected ClinicContext context;

        public GenericRepository(ClinicContext context)
        {
            this.context = context;
        }
        public virtual T Add(T item)
        {
            this.context.GetCollection<T>().Add(item);
            return item;
        }

        public virtual IEnumerable<T> Get()
        {
            return this.context.GetCollection<T>();
        }

        public virtual T GetById(int id)
        {
            return this.context.GetCollection<T>().Where(x => x.Id == id).FirstOrDefault();
        }

        public virtual void Remove(T item)
        {
            this.context.GetCollection<T>().Remove(item);
        }

        public virtual T Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("No puede ser nulo");
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
