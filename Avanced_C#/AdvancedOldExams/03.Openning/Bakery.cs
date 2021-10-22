using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (this.data != null)
            {
                if (this.data.Count < this.Capacity)
                {
                    this.data.Add(employee);
                }
            }
        }

        public bool Remove(string name)
        {
            if (this.data != null)
            {
                if (this.data.Any(e => e.Name == name))
                {
                    var employee = this.data.First(e => e.Name == name);
                    this.data.Remove(employee);
                    return true;
                }
               
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            if (this.data != null)
            {
                return this.data.OrderByDescending(e => e.Age).FirstOrDefault();
            }

            return null;
        }

        public Employee GetEmployee(string name)
        {
            if (this.data != null)
            {
                return this.data.FirstOrDefault(e => e.Name == name);
            }

            return null;
        }

        public int Count => this.data.Count;

        public string Report()
        {
            return $"Employees working at Bakery {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.data)}";
        }
    }
}
