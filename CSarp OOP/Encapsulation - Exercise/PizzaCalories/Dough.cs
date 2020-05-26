using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value == "white" || value == "wholegrain")
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value == "crispy" || value == "chewy" || value == "homemade")
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of bakingTechnique.");
                }
            }
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value >= 1 && value <= 200)
                {
                    this.grams = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double Calories { get; private set; }

        public double GetCalories()
        {
            Calories = grams * 2;
            if (flourType == "white")
            {
                Calories *= 1.5;
            }
            else if (flourType == "wholegrain")
            {
                Calories *= 1.0;
            }

            if (bakingTechnique == "crispy")
            {
                Calories *= 0.9;
            }
            else if (bakingTechnique == "chewy")
            {
                Calories *= 1.1;
            }
            else if (bakingTechnique == "homemade")
            {
                Calories *= 1.0;
            }

            return this.Calories;
        }
    }
}