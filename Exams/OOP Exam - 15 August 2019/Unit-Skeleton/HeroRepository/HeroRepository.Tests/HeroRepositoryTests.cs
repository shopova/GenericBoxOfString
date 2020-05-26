using System;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void Init()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void ConstructorInitializeCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();

        var expectedNumberOfItems = 0;
        var actual = heroRepository.Heroes.Count;

        Assert.AreEqual(expectedNumberOfItems, actual);
    }

    [Test]
    public void CreateWithNullHeroShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateWithExistingHeroShouldThrowException()
    {
        Hero hero = new Hero("Gosho", 16);

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateWithValidHeroShouldAddToCollection()
    {
        Hero hero = new Hero("Gosho", 16);
        heroRepository.Create(hero);

        int actual = heroRepository.Heroes.Count;
        int expected = 1;

        Assert.AreEqual(expected, actual);
    }

    [TestCase(null)]
    [TestCase("")]
    public void RemoveNotValudHeroShouldThrowException(string name)
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name));
    }

    [Test]
    public void RemoveValidNonExistingHeroShouldReturnFalse()
    {
        Assert.AreEqual(false, this.heroRepository.Remove("asd"));
    }

    [Test]
    public void RemoveValidHeroShouldDecreaseCount()
    {
        Hero hero = new Hero("Gosho", 16);
        Hero hero1 = new Hero("Pesho", 16);

        heroRepository.Create(hero);
        heroRepository.Create(hero1);

        heroRepository.Remove("Gosho");

        int actual = heroRepository.Heroes.Count;
        int expected = 1;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MothodShouldReturnHeroWithHighestLevel()
    {
        Hero hero = new Hero("Gosho", 16);
        Hero hero1 = new Hero("Pesho", 12);

        heroRepository.Create(hero);
        heroRepository.Create(hero1);

        Assert.AreEqual(hero, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void MothodShouldReturnHeroWithGivenName()
    {
        Hero hero = new Hero("Gosho", 16);
        Hero hero1 = new Hero("Pesho", 12);

        heroRepository.Create(hero);
        heroRepository.Create(hero1);

        Assert.AreEqual(hero, this.heroRepository.GetHero("Gosho"));
    }

    [Test]
    public void GetNullHeroShouldReturnNull()
    {
        Assert.AreEqual(null, this.heroRepository.GetHero("null"));
    }
}