using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitRider unitRider1;
        private UnitRider unitRider2;
        private UnitRider unitRider3;
        private UnitRider unitRider4;
        private UnitRider unitRider5;

        private UnitMotorcycle unitMotorcycle1;
        private UnitMotorcycle unitMotorcycle2;
        private UnitMotorcycle unitMotorcycle3;
        private UnitMotorcycle unitMotorcycle4;
        private UnitMotorcycle unitMotorcycle5;



        [SetUp]
        public void Setup()
        {
            this.unitMotorcycle1 = new UnitMotorcycle("KMD", 15, 3.2);
            this.unitMotorcycle2 = new UnitMotorcycle("Ya", 20, 4.2);
            this.unitMotorcycle3 = new UnitMotorcycle("Ma", 100, 3.6);
            this.unitMotorcycle4 = new UnitMotorcycle("Ha", 78, 7.3);
            this.unitMotorcycle5 = new UnitMotorcycle("Ti", 30, 12.9);
            
            this.unitRider1 = new UnitRider("Gosho", unitMotorcycle1);
            this.unitRider2 = new UnitRider("Misho", unitMotorcycle2);
            this.unitRider3 = new UnitRider("Pesho", unitMotorcycle3);
            this.unitRider4 = new UnitRider("Az", unitMotorcycle4);
            this.unitRider5 = new UnitRider("Ti", unitMotorcycle5);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Dictionary<string, UnitRider> riders = new Dictionary<string, UnitRider>();
            int actual = riders.Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Gosho", this.unitRider1.Name);
            Assert.AreEqual(unitMotorcycle5, this.unitRider5.Motorcycle);

            Assert.AreEqual(3.6, unitMotorcycle3.CubicCentimeters);
            Assert.AreEqual(30, unitMotorcycle5.HorsePower);
            Assert.AreEqual("Ti", unitMotorcycle5.Model);
        }

        [Test]
        public void AddingNullRiderToCollectionShoouldThrowException()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitRider asd = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(asd));
        }

        [Test]
        public void AddingExcistingRiderToCollectionShoouldThrowException()
        {
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddRider(unitRider1);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider1));
        }

        [Test]
        public void AddingValidRiderToCollectionShoouldIncreaseCount()
        {
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddRider(unitRider1);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculatingMinPowerWithLessThanMinParticipantsShouldThrowException()
        {
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddRider(unitRider1);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculatingAveragePowerWithValidParticipantsShouldCalculateCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddRider(unitRider1);
            raceEntry.AddRider(unitRider2);
            raceEntry.AddRider(unitRider3);

            // 15 20 100
            double expextedHorsePower = 45;
            double actualHorsePower = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expextedHorsePower, actualHorsePower);
        }


    }
}
