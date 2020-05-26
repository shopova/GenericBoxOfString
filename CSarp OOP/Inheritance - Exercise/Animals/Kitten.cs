using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat, IProduceSound
    {
        public Kitten(string name, int age) 
            : base(name, age, "female")
        {
        }

        public string ProduceSound()
        {
            return "Meow";
        }

        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
