using MXGP.Models.Races.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public RaceRepository()
        {
            this.entities = new List<IRace>();
        }

        public override IRace GetByName(string name)
        {
            return this.entities.FirstOrDefault(x => x.Name == name);
        }
    }
}
