using System;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (value == "meat" || value == "veggies" || value == "cheese" || value == "sauce")
                {
                    this.toppingType = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {GetFirstUpperLetter(value).ToString()} on top of your pizza.");
                }
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value >= 1 && value <= 50)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException($"{GetFirstUpperLetter(this.toppingType).ToString()} weight should be in the range [1..50].");
                }
            }
        }

        private StringBuilder GetFirstUpperLetter(string value)
        {
            char[] topping = value.ToCharArray();
            StringBuilder sb = new StringBuilder();
            sb.Append(topping[0].ToString().ToUpper());
            for (int i = 1; i < topping.Length; i++)
            {
                sb.Append(topping[i]);
            }

            return sb;
        }

        public double Calories { get; private set; }

        public double GetCalories()
        {
            Calories = weight * 2;
            if (toppingType == "meat")
            {
                Calories *= 1.2;
            }
            else if (toppingType == "veggies")
            {
                Calories *= 0.8;
            }
            else if (toppingType == "cheese")
            {
                Calories *= 1.1;
            }
            else if (toppingType == "sauce")
            {
                Calories *= 0.9;
            }
            
            return this.Calories;
        }
    }
}
