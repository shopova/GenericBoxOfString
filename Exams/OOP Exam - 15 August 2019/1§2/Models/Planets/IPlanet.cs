namespace SpaceStation.Models.Planets
{
    using System.Collections.Generic;
    using Repositories;

    public interface IPlanet
    {
        ICollection<string> Items { get; set; }

        string Name { get; }
    }
}