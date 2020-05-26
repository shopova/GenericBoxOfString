using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = models.FirstOrDefault(x => x.Name == name);
            if (planet != null)
            {
                return planet;
            }

            return null;
        }

        public bool Remove(IPlanet model)
        {
            IPlanet planet = models.FirstOrDefault(x => x.Name == model.Name);
            if (planet != null)
            {
                models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
