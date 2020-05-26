using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
            IMachinesManager machinesManager = new MachinesManager();

            IEngine engine = new Engine(reader, writer, machinesManager);

            engine.Run();
        }
    }
}