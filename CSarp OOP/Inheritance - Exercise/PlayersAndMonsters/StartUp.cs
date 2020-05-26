using System.Collections.Generic;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main()
        {
            List<Hero> list = new List<Hero>();

            var knight = new Knight("asd", 4);
            var elf = new Elf("asd", 4);

            list.Add(knight);
            list.Add(elf);
        }
    }
}
