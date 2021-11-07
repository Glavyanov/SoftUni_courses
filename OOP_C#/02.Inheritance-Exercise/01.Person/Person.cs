using System;

namespace Person
{
    public class Person
    {
        private  int age;
        public Person()
        {

        }

        public Person(string name, int age) : this()
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The age cannot be nagative.");
                }
                this.age = value;
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}
