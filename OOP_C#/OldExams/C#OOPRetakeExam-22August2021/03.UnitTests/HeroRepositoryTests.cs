using System;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{
    HeroRepository heroRepo;
    [SetUp]
    public void SetUp()
    {
        heroRepo = new HeroRepository();
    }
    [Test]
    public void Ctor_ShouldWorkCorrectly()
    {
        Assert.That(0 == heroRepo.Heroes.Count);
    }
    [Test]
    public void CreateMethodShouldWorkCorrect()
    {
        Hero hero = new Hero("Vasil", 100);
        heroRepo.Create(hero);
        Assert.AreEqual(1, heroRepo.Heroes.Count);
    }
    [Test]
    public void CreateMethodShouldWorkCorrectAndReturnMessage()
    {
        Hero hero = new Hero("Vasil", 100);
        Assert.AreEqual($"Successfully added hero {hero.Name} with level {hero.Level}", heroRepo.Create(hero));
    }
    [Test]
    public void CreateMethodShouldThrowsExceptionWhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepo.Create(null));
    }
    [Test]
    [TestCase(100)]
    [TestCase(200)]
    public void CreateMethodShouldThrowsExceptionWhenTryToAddExistingHero(int level)
    {
        Hero hero = new Hero("Vasil", 100);
        heroRepo.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroRepo.Create(new Hero("Vasil", level)));
    }
    [Test]
    public void RemoveMethodShouldWorkCorrect()
    {
        Hero hero = new Hero("Vasil", 100);
        heroRepo.Create(hero);
        heroRepo.Create(new Hero("Viktor", 200));
        Assert.IsTrue(heroRepo.Remove("Viktor"));
    }
    [Test]
    public void RemoveMethodShouldThrowsExceptionWhenParameterIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepo.Remove(null));
    }
    [Test]
    public void RemoveMethodShouldWorkCorrectAndCountDecrease()
    {
        Hero hero = new Hero("Vasil", 100);
        heroRepo.Create(hero);
        heroRepo.Create(new Hero("Viktor", 200));
        heroRepo.Remove("Viktor");
        Assert.AreEqual(1, heroRepo.Heroes.Count);
    }
    [Test]
    public void GetHeroWithHighestLevelMethodShouldWorkCorrect()
    {
        Hero hero = new Hero("Vasil", 200);
        heroRepo.Create(hero);
        heroRepo.Create(new Hero("Viktor", 100));
        Assert.AreSame(hero, heroRepo.GetHeroWithHighestLevel());
    }
    [Test]
    public void GetHeroMethodShouldWorkCorrect()
    {
        Hero hero = new Hero("Vasil", 200);
        heroRepo.Create(hero);
        heroRepo.Create(new Hero("Viktor", 100));
        Assert.AreSame(hero, heroRepo.GetHero("Vasil"));

    }

}