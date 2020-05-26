using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
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
                if (value >= 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");
            return stringBuilder.ToString();
        }
    }
}