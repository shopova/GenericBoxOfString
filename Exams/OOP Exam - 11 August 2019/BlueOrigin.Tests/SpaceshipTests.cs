namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Astronaut astronaut1;
        private Astronaut astronaut2;
        private Astronaut astronaut3;
        private Astronaut astronaut4;

        [SetUp]
        public void Init()
        {
            this.astronaut = new Astronaut("Gosho", 10);
            this.astronaut1 = new Astronaut("Misho", 20);
            this.astronaut2 = new Astronaut("Pesho", 100);
            this.astronaut3 = new Astronaut("Az", 78);
            this.astronaut4 = new Astronaut("Ti", 30);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Spaceship spaceship = new Spaceship("Millennium falcon", 4);

            Assert.AreEqual("Gosho", this.astronaut.Name);
            Assert.AreEqual(10, this.astronaut.OxygenInPercentage);

            Assert.AreEqual("Millennium falcon", spaceship.Name);
            Assert.AreEqual(4, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void InvalidNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, 13));
        }

        [Test]
        public void ValidNameShouldSetValue()
        {
            Spaceship spaceship = new Spaceship("Millennium falcon", 4);

            string expexted = "Millennium falcon";
            string actual = spaceship.Name;

            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void InvalidCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Millennium falcon", -12));
        }


        [Test]
        public void ValidCapacityShouldSetValue()
        {
            Spaceship spaceship = new Spaceship("Millennium falcon", 4);

            int expexted = 4;
            int actual = spaceship.Capacity;

            Assert.AreEqual(expexted, actual);
        }


        [Test]
        public void AddingAstronautOutsideCapacityShouldThrowException()
        {
            Spaceship spaceship = new Spaceship("Millennium falcon", 4);

            spaceship.Add(astronaut);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            spaceship.Add(astronaut3);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut4));
        }

        [Test]
        public void AddingExistindAstronautShouldThrowException()
        {
            Spaceship spaceship = new Spaceship("Millennium falcon", 4);

            spaceship.Add(astronaut);
            spaceship.Add(astronaut1);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void RemovingAstronautShouldDecreaseCount()
        {
            Spaceship spaceship = new Spaceship("Millennium falcon", 4);

            spaceship.Add(astronaut);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);

            spaceship.Remove(astronaut1.Name);

            Assert.AreEqual(2, spaceship.Count);
        }


    }
}