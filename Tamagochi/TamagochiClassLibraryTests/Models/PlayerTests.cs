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
            Animal pet = new Dog(Gender.Male, "Rex");
            //Player player = Player.Initialize("dany", pet);
            Assert.AreEqual(pet.Name, "Rex");
            //Assert.AreEqual(player.Pet.Name, "Rex");
        }

        [TestMethod()]
        public void AddItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeTest()
        {
            Animal pet = new Dog(Gender.Male, "Rex");
            //Player player = Player.Initialize("dany", pet);
            //player.Serialize();
            //Assert.Fail();
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            Assert.Fail();
        }
    }
}
