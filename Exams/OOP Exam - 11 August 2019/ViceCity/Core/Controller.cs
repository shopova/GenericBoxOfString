using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository = new GunRepository();
        private List<IPlayer> players = new List<IPlayer>();
        private MainPlayer mainPlayer = new MainPlayer();
        private GangNeighbourhood gangNeighbourhood = new GangNeighbourhood();

        public Controller()
        {
            MainPlayer mainPlayer = new MainPlayer();
        }

        public string AddGun(string type, string name)
        {
            if (type == "Rifle")
            {
                Rifle rifle = new Rifle(name);
                this.gunRepository.Add(rifle);
            }
            else if (type == "Pistol")
            {
                Pistol pistol = new Pistol(name);
                this.gunRepository.Add(pistol);
            }
            else
            {
                return "Invalid gun type!";
            }

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count <= 0)
            {
                return "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                IGun gun = gunRepository.Models.FirstOrDefault();

                this.mainPlayer.GunRepository.Add(gun);
                this.gunRepository.Remove(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!this.players.Any(x => x.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                IGun gun = this.gunRepository.Models.FirstOrDefault();
                this.gunRepository.Remove(gun);
                return $"Successfully added {gun.Name} to the Civil Player: {name}";
            }
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civilPlayer = new CivilPlayer(name);

            this.players.Add(civilPlayer);
            return $"Successfully added civil player: {civilPlayer.Name}!";
        }

        public string Fight()
        {
            this.gangNeighbourhood.Action(this.mainPlayer, this.players);
            int mainPlayerPoints = this.mainPlayer.LifePoints;
            
            if (mainPlayerPoints == this.mainPlayer.LifePoints && !this.players.Any(x => x.IsAlive == false))
            {
                return "Everything is okay!";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A fight happened:");
            sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");

            List<IPlayer> deadCivilPlayers = players.Where(x => x.IsAlive == false).ToList();

            sb.AppendLine($"Tommy has killed: {deadCivilPlayers.Count} players!");
            sb.AppendLine($"Left Civil Players: {players.Where(x => x.IsAlive == true).ToList().Count}!");

            return sb.ToString().TrimEnd();
        }
    }
}
