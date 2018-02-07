using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repositories
{
    public interface IRepository<T> where T:Entity
    {
        T Add(T item);

        void Remove(T item);

        T Update(T item);

        IEnumerable<T> Get();

        T GetById(int id);
    }
}
