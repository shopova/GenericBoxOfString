using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> entities;

        public Repository()
        {
            entities = new List<T>();
        }

        public void Add(T model)
        {
            this.entities.Add(model);
        }

        public IReadOnlyCollection<T> GetAll() => this.entities;

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            T type = entities.FirstOrDefault(x => x.Equals(model));

            return entities.Remove(model);
        }
    }
}
