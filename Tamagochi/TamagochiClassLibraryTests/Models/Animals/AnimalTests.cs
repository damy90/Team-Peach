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
    public class AnimalTests
    {
        [TestMethod()]
        public void AnimalTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AnimalTest1()
        {
            Assert.Fail();
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
    }
}
