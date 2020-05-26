using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Repositories
{
    public class PlayerRepository
    {
        private readonly List<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.models.AsReadOnly();

        public void Add(IPlayer model)
        {

            if (!models.Contains(model))
            {
                models.Add(model);
            }
        }

        public IPlayer Find(string name)
        {
            IPlayer player = models.FirstOrDefault(x => x.Name == name);
            models.Remove(player);

            return player;
        }

        public bool Remove(IPlayer model)
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
