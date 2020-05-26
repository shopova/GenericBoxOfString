namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier
    {
        public enum Corps
        {
            Airforces,
            Marines
        }
        public interface ISpecialisedSoldier
        {
            Corps Corps { get; }
        }
    }
}
