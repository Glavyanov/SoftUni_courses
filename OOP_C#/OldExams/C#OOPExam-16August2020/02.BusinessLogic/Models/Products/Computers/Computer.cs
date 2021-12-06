using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this.Components != null && this.Components.Count != 0)
                {
                    return base.OverallPerformance + this.Components.Select(c => c.OverallPerformance).Average();
                }
                return base.OverallPerformance;
            }

        }

        public override decimal Price
        {
            get
            {
                return base.Price + this.Components.Select(c => c.Price).Sum() + this.Peripherals.Select(p => p.Price).Sum();
            }

        }

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);

        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = null;
            if (this.Components == null || !this.Components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = null;
            if (this.Peripherals == null || !this.Peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            peripheral = this.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }
            if (this.Peripherals.Count > 0)
            {

                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Select(p => p.OverallPerformance).Average():F2}):");
                foreach (var peripheral in this.Peripherals)
                {
                    sb.AppendLine($"  {peripheral}");
                }
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance (0.00):");
            }
            return sb.ToString().Trim();
        }
    }
}
