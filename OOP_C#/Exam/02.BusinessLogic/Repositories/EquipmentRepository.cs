using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipmentRepo;
        public EquipmentRepository()
        {
            this.equipmentRepo = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => this.equipmentRepo.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.equipmentRepo.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.equipmentRepo.FirstOrDefault(e => e.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return this.equipmentRepo != null ? this.equipmentRepo.Remove(model) : false;
        }
    }
}
