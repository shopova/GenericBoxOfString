using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut astronaut)
        {
            this.models.Add(astronaut);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronautToFind = models.FirstOrDefault(x => x.Name == name);
            if (astronautToFind != null)
            {
                return astronautToFind;
            }

            return null;
        }

        public bool Remove(IAstronaut astronaut)
        {
            IAstronaut astronautToRemove = models.FirstOrDefault(x => x.Name == astronaut.Name);
            if (astronautToRemove != null)
            {
                models.Remove(astronaut);
                return true;
            }

            return false;
        }
    }
}
