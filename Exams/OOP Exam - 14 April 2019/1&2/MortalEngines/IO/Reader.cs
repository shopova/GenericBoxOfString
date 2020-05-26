using MortalEngines.IO.Contracts;
using System;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        public Reader()
        {
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
