using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ');

            string[] websites = Console.ReadLine().Split(' ');

            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                Console.WriteLine(smartphone.Call(phoneNumbers[i]));
            }

            for (int i = 0; i < websites.Length; i++)
            {
                Console.WriteLine(smartphone.Browse(websites[i]));
            }
        }
    }
}
