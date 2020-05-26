using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        ICollection<Private> Privates { get; }
    }
}
