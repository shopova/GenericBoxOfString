using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            riderRepository = new RiderRepository();
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            string result;
            
            IRider rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                result = string.Format(ExceptionMessages.RiderNotFound, riderName);
                throw new InvalidOperationException(result);
            }

            IMotorcycle motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                result = string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel);
                throw new InvalidOperationException(result);
            }

            rider.AddMotorcycle(motorcycle);

            result = string.Format(OutputMessages.MotorcycleAdded, rider.Name, motorcycle.Model);
            return result;
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                string result = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(result);
            }

            if (this.riderRepository.GetByName(riderName) == null)
            {
                string result = string.Format(ExceptionMessages.RiderNotFound, riderName);
                throw new InvalidOperationException(result);
            }

            IRace race = this.raceRepository.GetByName(raceName);
            IRider rider = this.riderRepository.GetByName(riderName);

            race.AddRider(rider);   

            string output = string.Format(OutputMessages.RiderAdded, riderName, raceName);
            return output;
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                string output = string.Format(ExceptionMessages.MotorcycleExists, model);
                throw new ArgumentException(output);
            }

            if (type == "Speed")
            {
                SpeedMotorcycle motorcycle = new SpeedMotorcycle(model, horsePower);
                this.motorcycleRepository.Add(motorcycle);

                string result = string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
                return result;
            }
            else
            {
                PowerMotorcycle motorcycle = new PowerMotorcycle(model, horsePower);
                this.motorcycleRepository.Add(motorcycle);

                string result = string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
                return result;
            }
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                string result = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(result);
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            string output = string.Format(OutputMessages.RaceCreated, name);
            return output;
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                string result = string.Format(ExceptionMessages.RiderExists, riderName);
                throw new ArgumentException(result);
            }

            IRider rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            string output = string.Format(OutputMessages.RiderCreated, riderName);
            return output;
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                string result = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(result);
            }

            if (race.Riders.Count < 3)
            {
                string result = string.Format(ExceptionMessages.RaceInvalid, raceName, "3");
                throw new InvalidOperationException(result);
            }

            List<IRider> riders = this.riderRepository.GetAll().OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();

            string output = string.Format(OutputMessages.RiderFirstPosition, riders[0].Name, race.Name);
            sb.AppendLine(output);
            output = string.Format(OutputMessages.RiderSecondPosition, riders[1].Name, race.Name);
            sb.AppendLine(output); 
            output = string.Format(OutputMessages.RiderThirdPosition, riders[2].Name, race.Name);
            sb.AppendLine(output);

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();

        }
    }
}
