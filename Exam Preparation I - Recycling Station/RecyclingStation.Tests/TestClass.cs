using NUnit.Framework;
using System;
using System.Linq;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.BusinessLayer.Strategies;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal;
using System.Collections.Generic;
using RecyclingStation.BusinessLayer.Attributes;

[TestFixture]
public class StrategyHolderTests
{
    private IGarbageDisposalStrategy ds;
    private Dictionary<Type, IGarbageDisposalStrategy> strategies;

    [SetUp]
    public void TestInit()
    {
        ds = new BurnableGarbageDisposalStrategy();
        strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
    }
    
    [Test]
    public void TestPropertyForReadOnlyCollection()
    {
        //Arrange
        Type disType = typeof(DisposableAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Act
        Type type = sut.GetDisposalStrategies.GetType();

        //Assert
        var test = type.GetInterfaces();
        Assert.IsTrue(type.GetInterfaces().Contains(typeof(System.Collections.Generic.IReadOnlyCollection<>)));

    }
    
    [Test]
    public void AddStrategy()
    {
        //Arrange
        Type disType = typeof(DisposableAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        //Assert
        Assert.IsTrue(sut.AddStrategy(disType, ds));
    }

    [Test]
    public void AddSameStrategiesAndCheckCollectionHaveOne()
    {
        //Arrange
        Type disType = typeof(DisposableAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        bool result = sut.AddStrategy(disType, ds);
        bool result1 = sut.AddStrategy(disType, ds);
        bool result2 = sut.AddStrategy(disType, ds);

        //Assert
        Assert.AreEqual(1, sut.GetDisposalStrategies.Count);
    }

    [Test]
    public void AddDifferentStrategiesAndCheckCollection()
    {
        //Arrange
        Type disType = typeof(BurnableStrategyAttribute);
        Type disType1 = typeof(StorableStrategyAttribute);
        Type disType2 = typeof(RecyclableStrategyAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        bool result = sut.AddStrategy(disType, ds);
        bool result1 = sut.AddStrategy(disType1, ds);
        bool result2 = sut.AddStrategy(disType2, ds);

        //Assert
        Assert.AreEqual(3, sut.GetDisposalStrategies.Count);
    }

    [Test]
    public void RemoveStrategies()
    {
        //Arrange
        Type disType = typeof(DisposableAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        bool result = sut.AddStrategy(disType, ds);

        //Assert
        Assert.IsTrue(sut.RemoveStrategy(disType));
    }

    [Test]
    public void RemoveStrategiesAndCheckCount()
    {
        //Arrange
        Type disType = typeof(BurnableStrategyAttribute);
        Type disType1 = typeof(StorableStrategyAttribute);
        Type disType2 = typeof(RecyclableStrategyAttribute);
        IStrategyHolder sut = new StrategyHolder(strategies);

        bool result = sut.AddStrategy(disType, ds);
        bool result1 = sut.AddStrategy(disType1, ds);
        bool result2 = sut.AddStrategy(disType2, ds);

        bool removeResult = sut.RemoveStrategy(disType);

        //Assert
        Assert.AreEqual(2, sut.GetDisposalStrategies.Count);
    }
}

