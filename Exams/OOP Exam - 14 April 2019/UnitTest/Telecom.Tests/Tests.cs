namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void ConstructorShouldInitializeProperrly()
        {
            Phone phone = new Phone("Nokia", "3310");

            int expected = 0;
            int actual = phone.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakingNullOrEmptyPhoneShouldThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Phone(name, "3310"));
        }

        [Test]
        public void MakeValidPhoneShouldCreateProperly()
        {
            Phone phone = new Phone("Nokia", "3310");

            string expected = "Nokia";
            string actual = phone.Make;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakingNullOrEmptyModelShouldThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone("name", model));
        }

        [Test]
        public void ValidPhoneShouldCreateProperly()
        {
            Phone phone = new Phone("Nokia", "3310");

            string expected = "3310";
            string actual = phone.Model;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddingExcistingContactShouldThrowException()
        {
            Phone phone = new Phone("Nokia", "3310");

            phone.AddContact("Gosho", "08888888");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Gosho", "08888888"));
        }

        [Test]
        public void AddingAccurateContactShouldIncreaseCount()
        {
            Phone phone = new Phone("Nokia", "3310");

            phone.AddContact("Gosho", "08888888");

            int expected = 1;
            int actual = phone.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CallingNonExcistingContactShouldThrowException()
        {
            Phone phone = new Phone("Nokia", "3310");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

        [Test]
        public void CallingAccurateContactShouldIncreaseCount()
        {
            Phone phone = new Phone("Nokia", "3310");

            phone.AddContact("Gosho", "08888888");

            string expected = "Calling Gosho - 08888888...";
            string actual = phone.Call("Gosho");

            Assert.AreEqual(expected, actual);
        }
    }
}