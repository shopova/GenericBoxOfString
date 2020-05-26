using MXGP.Models.Motorcycles.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public MotorcycleRepository()
        {
            this.entities = new List<IMotorcycle>();
        }

        public override IMotorcycle GetByName(string name)
        {
            return this.entities.FirstOrDefault(x => x.Model == name);
        }
    }
}
