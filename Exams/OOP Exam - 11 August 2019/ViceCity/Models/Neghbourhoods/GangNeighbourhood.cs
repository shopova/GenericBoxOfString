using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        private GunRepository gunRepository = new GunRepository();

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault();

            if (gun != null)
            {
                foreach (var player in civilPlayers)
                {
                    while (gun.CanFire && player.IsAlive)
                    {
                        int bulletsFired = gun.Fire();
                        player.TakeLifePoints(bulletsFired);
                    }

                    if (!gun.CanFire)
                    {
                        this.gunRepository.Remove(gun);
                        gun = mainPlayer.GunRepository.Models.FirstOrDefault();
                    }
                }
            }

            List<IPlayer> alivePlayers = civilPlayers
                .Where(x => x.IsAlive)
                .ToList();

            foreach (var player in alivePlayers)
            {
                IGun civilGun = player.GunRepository.Models.FirstOrDefault();

                if (civilGun != null)
                {
                    while (player.GunRepository.Models.Count > 0 && mainPlayer.IsAlive)
                    {
                        while (gun.TotalBullets > 0 && mainPlayer.IsAlive)
                        {
                            int bulletsFired = gun.Fire();
                            player.TakeLifePoints(bulletsFired);
                        }

                        this.gunRepository.Remove(gun);
                        gun = mainPlayer.GunRepository.Models.FirstOrDefault();

                    }

                    if (mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
            }
        }
    }
}
