using System;
using System.Text;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main()
        {
            string command = Console.ReadLine();

            string[] commandArgs = command.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (commandArgs[0] == "pizza")
            {
                try
                {
                    Pizza pizza = new Pizza(commandArgs[1]);

                    command = Console.ReadLine();

                    while (command != "END")
                    {
                        commandArgs = command.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        if (commandArgs[0] == "dough")
                        {
                            try
                            {
                                Dough dough = new Dough(commandArgs[1], commandArgs[2], double.Parse(commandArgs[3]));
                                pizza.Dough = dough;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                        }
                        else if (commandArgs[0] == "topping")
                        {
                            try
                            {
                                if (pizza.Toppings.Count >= 0 && pizza.Toppings.Count <= 10)
                                {
                                    Topping topping = new Topping(commandArgs[1], double.Parse(commandArgs[2]));
                                    pizza.Toppings.Add(topping);
                                }
                                else
                                {
                                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                        }
                        command = Console.ReadLine();
                    }

                    char[] pizzaArray = pizza.Name.ToCharArray();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(pizzaArray[0].ToString().ToUpper());
                    for (int i = 1; i < pizzaArray.Length; i++)
                    {
                        sb.Append(pizzaArray[i]);
                    }
                    Console.WriteLine($"{sb.ToString()} - {pizza.GetPizzaCalories():f2} Calories.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}
