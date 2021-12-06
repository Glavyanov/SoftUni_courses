using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly Dictionary<int, IComputer> computers;
        private readonly Dictionary<int, IPeripheral> peripherals;
        private readonly Dictionary<int, IComponent> components;
        public Controller()
        {
            this.computers = new Dictionary<int, IComputer>();
            this.peripherals = new Dictionary<int, IPeripheral>();
            this.components = new Dictionary<int, IComponent>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!this.computers.ContainsKey(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            if (this.components.ContainsKey(id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            ComponentType typeComp;
            if (Enum.TryParse<ComponentType>(componentType, out typeComp))
            {
                IComponent component = null;
                if (typeComp == ComponentType.CentralProcessingUnit)
                {
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                }
                else if (typeComp == ComponentType.Motherboard)
                {
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                }
                else if (typeComp == ComponentType.PowerSupply)
                {
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                }
                else if (typeComp == ComponentType.RandomAccessMemory)
                {
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                }
                else if (typeComp == ComponentType.SolidStateDrive)
                {
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                }
                else if (typeComp == ComponentType.VideoCard)
                {
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                }
                this.components.Add(id, component);
                this.computers[computerId].AddComponent(component);

            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            ComputerType typeComp;
            if (Enum.TryParse<ComputerType>(computerType, out typeComp))
            {
                if (typeComp == ComputerType.DesktopComputer)
                {
                    this.computers.Add(id, new DesktopComputer(id, manufacturer, model, price));
                }
                else
                {
                    this.computers.Add(id, new Laptop(id, manufacturer, model, price));
                }

            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!this.computers.ContainsKey(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            if (this.peripherals.ContainsKey(id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            PeripheralType typeComp;
            if (Enum.TryParse<PeripheralType>(peripheralType, out typeComp))
            {
                IPeripheral component = null;
                if (typeComp == PeripheralType.Headset)
                {
                    component = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (typeComp == PeripheralType.Keyboard)
                {
                    component = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (typeComp == PeripheralType.Monitor)
                {
                    component = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (typeComp == PeripheralType.Mouse)
                {
                    component = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                this.peripherals.Add(id, component);
                this.computers[computerId].AddPeripheral(component);

            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0 || this.computers.All(c=> c.Value.Price > budget))
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            var orderedComputers = this.computers.OrderByDescending(c => c.Value.OverallPerformance).ToDictionary(k => k.Key , v => v.Value);
            var computerToRemove = orderedComputers.FirstOrDefault(c => c.Value.Price <= budget);
            this.computers.Remove(computerToRemove.Key);
            return computerToRemove.Value.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var computer = this.computers[id] as Computer;
            this.computers.Remove(id);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            return this.computers[id].ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            int removedId = 0;
            if (!this.computers.ContainsKey(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            ComponentType result;
            if (Enum.TryParse<ComponentType>(componentType, out result))
            {
                var component = this.computers[computerId].RemoveComponent(componentType);
                var componentToRemove = this.components.FirstOrDefault(c => c.Value == component);
                this.components.Remove(componentToRemove.Key);
                removedId = componentToRemove.Key;
            }
            return $"Successfully removed {componentType} with id {removedId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            int removedId = 0;
            if (!this.computers.ContainsKey(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            PeripheralType result;
            if (Enum.TryParse<PeripheralType>(peripheralType, out result))
            {
                var peripheral = this.computers[computerId].RemovePeripheral(peripheralType);
                var peripheralToRemove = this.peripherals.FirstOrDefault(c => c.Value == peripheral);
                this.peripherals.Remove(peripheralToRemove.Key);
                removedId = peripheralToRemove.Key;
            }
            return $"Successfully removed {peripheralType} with id {removedId}.";

        }

        public void Close()
        {
            Environment.Exit(0);
        }
    }
}
