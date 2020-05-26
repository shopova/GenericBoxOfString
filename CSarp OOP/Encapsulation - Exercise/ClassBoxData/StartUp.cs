using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine(box.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
