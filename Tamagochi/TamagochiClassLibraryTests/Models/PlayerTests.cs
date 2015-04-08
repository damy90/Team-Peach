using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Models.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void InitializeTest()
        {
            //Animal pet = new Dog(Gender.Male, "Rex");
            ////Player player = Player.Initialize("dany", pet);
            //Assert.AreEqual(pet.Name, "Rex");
            ////Assert.AreEqual(player.Pet.Name, "Rex");
            Assert.Fail();
        }

        [TestMethod()]
        public void AddItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeTest()
        {
            var pet = AnimalFactory.CreateAnimal("Cat", Gender.Male, "Wiskers");
            var pizza = new Pizza();
            var steak = new Steak();
            pet.FoodsInfinite = new List<Food> { pizza, steak };
            var player = new Player(pet);
            player.Serialize();
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            var player = Player.Deserialize();
        }
    }
}
