using System.Linq;
using System.Collections.Generic;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> items = planet.Items.ToList();

            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    continue;
                }
                else
                {

                    while (astronaut.Oxygen > 0)
                    {
                        if (items.Count != 0)
                        {
                            astronaut.Bag.Items.Add(items[0]);
                           items.RemoveAt(0);
                        }
                        else
                        {
                            break;
                        }
                        astronaut.Breath();
                    }
                }
                if (items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
