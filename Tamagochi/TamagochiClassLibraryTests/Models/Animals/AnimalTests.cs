using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
//using TamagochiClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Models.Tests
{
    [TestClass()]
    public class AnimalTests
    {
        [TestMethod()]
        public void AnimalFoodIsInitializedTest()
        {
            var pet = (Cat)AnimalFactory.CreateAnimal("Cat", Gender.Male, "Wiskers");
            //var pet = new Cat(Gender.Male, "Wiskers");
            Assert.AreEqual(pet.MeatFoodAllowed.Count(), 1);
        }

        [TestMethod()]
        public void AnimalSerializeTest()
        {
            var pet = AnimalFactory.CreateAnimal("Cat", Gender.Male, "Wiskers");
            var pizza = new Pizza();
            var steak = new Steak();
            pet.FoodsInfinite = new List<Food> { pizza, steak };
            pet.Serialize();
        }

        [TestMethod()]
        public void AnimalDeserializeTest()
        {
            var pet = Animal.Deserialize("../../wiskers.xml");
            //TODO check all properties
        }

        [TestMethod()]
        public void AnimalChangeConditionTest()
        {
            var pet = AnimalFactory.CreateAnimal("Cat", Gender.Male, "Wiskers");
            pet.CurrentCondition.ChangeHappiness(-10);
            Assert.AreEqual(pet.CurrentCondition.Happiness, 90);
            pet.CurrentCondition.ChangeFeed(10);
            Assert.AreEqual(pet.CurrentCondition.Feed, 100);
            //Assert.AreEqual(pet.CurrentCondition.Happiness, 90);
        }

        [TestMethod()]
        public void AnimalInitializeWithoutFactoryTest()
        {
            //this should not compile if uncommented
            //var pet = new Cat(Gender.Male, "Wiskers");
        }
    }
}