namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;

        public Pistol(string name) 
            : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            this.bulletsPerTrigger = 1;
            return base.Fire();
        }
    }
}
