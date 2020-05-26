using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Toppings = new List<Topping>();
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length >= 1 && value.Length <= 15)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }

        public List<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
            private set
            {
                if (value.Count >= 0 && value.Count <= 10)
                {
                    this.toppings = value;
                }
                else
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
            }
        }
        public Dough Dough { get; set; }

        public void Add(Topping topping)
        {
            if (Toppings.Count + 1 >= 0 && Toppings.Count + 1 <= 10)
            {
                Toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public double GetPizzaCalories()
        {
            double toppingCalories = 0;
            double doughCalories = 0;

            foreach (var topping in this.Toppings)
            {
                toppingCalories += topping.GetCalories();
            }

            doughCalories += Dough.GetCalories();

            return toppingCalories + doughCalories;
        }
    }
}