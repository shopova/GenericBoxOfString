using ViceCity.Core.Contracts;
using System;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

        }

        Controller controller = new Controller();

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                string result = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        string playerUsername = input[1];
                        result = controller.AddPlayer(playerUsername);
                    }
                    else if (input[0] == "AddGun")
                    {
                        string type = input[1];
                        string name = input[2];

                        result = controller.AddGun(type, name);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        string playerName = input[1];

                        result = controller.AddGunToPlayer(playerName);
                    }
                    else if (input[0] == "Fight")
                    {
                        result = controller.Fight();
                    }
                    writer.WriteLine(result);   
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
