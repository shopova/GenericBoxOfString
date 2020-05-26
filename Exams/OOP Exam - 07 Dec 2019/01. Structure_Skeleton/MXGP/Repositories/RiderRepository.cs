using MXGP.Models.Riders.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public RiderRepository()
        {
            this.entities = new List<IRider>();
        }

        public override IRider GetByName(string name)
        {
            return this.entities.FirstOrDefault(x => x.Name == name);
        }
    }
}
