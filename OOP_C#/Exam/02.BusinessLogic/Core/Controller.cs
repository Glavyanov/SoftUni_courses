using Gym.Core.Contracts;
using Gym.Repositories;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Equipment;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipmentRepo;
        private readonly List<IGym> gyms;
        public Controller()
        {
            this.equipmentRepo = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            string result = null;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            if (gym != null)
            {
                if (athleteType == "Boxer" && gym.GetType().Name == "BoxingGym")
                {
                    gym.AddAthlete(athlete);
                }
                if (athleteType == "Weightlifter" && gym.GetType().Name == "WeightliftingGym")
                {
                    gym.AddAthlete(athlete);
                }
                result = $"Successfully added {athleteType} to {gymName}.";
                if (athleteType == "Boxer" && gym.GetType().Name != "BoxingGym")
                {
                    result = "The gym is not appropriate.";
                }
                if (athleteType == "Weightlifter" && gym.GetType().Name != "WeightliftingGym")
                {
                    result = "The gym is not appropriate.";
                }
            }
            return result;
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();

            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            this.equipmentRepo.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            this.gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentDesire = this.equipmentRepo.FindByType(equipmentType);
            if (equipmentDesire == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            this.gyms.FirstOrDefault(g => g.Name == gymName).AddEquipment(equipmentDesire);
            this.equipmentRepo.Remove(equipmentDesire);
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.gyms)
            {
                sb.AppendLine(item.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
