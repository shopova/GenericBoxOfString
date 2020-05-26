using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!models.Contains(model))
            {
                models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = models.FirstOrDefault(x => x.Name == name);
            models.Remove(gun);

            return gun;
        }

        public bool Remove(IGun model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
