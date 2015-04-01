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
            var pet = new Cat(Gender.Male, "Wiskers");
            Assert.AreEqual(pet.MeatFoodAllowed.Count(), 1);
        }

        [TestMethod()]
        public void AnimalSerializeTest()
        {
            Animal pet = new Cat(Gender.Male, "wiskers");
            pet.Serialize();
        }

        [TestMethod()]
        public void AnimalDeserializeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AnimalChangeConditionTest()
        {
            Animal pet = new Cat(Gender.Male, "wiskers");
            pet.CurrentCondition.ChangeHappiness(-10);
            Assert.AreEqual(pet.CurrentCondition.Happiness, 90);
            pet.CurrentCondition.ChangeFeed(10);
            Assert.AreEqual(pet.CurrentCondition.Feed, 100);
            //Assert.AreEqual(pet.CurrentCondition.Happiness, 90);
        }
    }
}
