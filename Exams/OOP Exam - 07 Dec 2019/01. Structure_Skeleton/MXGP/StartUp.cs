namespace MXGP
{
    using MXGP.Core.Contracts;
    using MXGP.IO.Contracts;
    using MXGP.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var a = 3;

            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
