using System;
using System.Collections.Generic;
using Polenter.Serialization;

namespace Models
{
    //[Serializable]
    public abstract class Animal
    {
        //Wintellect.PowerCollections. d;
        #region Constants
        private const int ConditionMaxValue = 100;
        #endregion

        #region Fields
        private string[] pictures;

        // Cannot encapsulate because it would break the serialization or the methods for changing conditions
        public Condition CurrentCondition{ get; set; }

        private Gender sex;
        private string name;
        protected readonly Random random;
        private List<Food> foodsAllowed = new List<Food>();
        private Dictionary<Food, int> foodsAvailable = new Dictionary<Food, int>();
        private List<Food> foodsInfinite = new List<Food>();
        #endregion

        #region Constructors
        public Animal()
        {
            this.name = this.GetType().Name;
            this.Sex = Gender.Male;
            this.CurrentCondition = new Condition(ConditionMaxValue);
        }

        public Animal(Gender sex, string name)
            : this()
        {
            this.Name = name;
            this.sex = sex;
            if (this is ICarnivorous)
            {
                random = new Random();
            }
        }

        public Animal(Gender sex, string name, Condition initialCondition)
            : this(sex, name)
        {
            this.CurrentCondition = initialCondition;
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public Gender Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public List<Food> FoodsInfinite
        {
            get
            {
                return this.foodsInfinite;
            }
            set
            {
                if (value != null)
                {
                    this.foodsInfinite = value;
                }
                else
                {
                    throw new ArgumentNullException("List of infinite foods cannot be null");
                }
            }
        }

        public string[] Pictures
        {
            get
            {
                return this.pictures;
            }
            set
            {
                this.pictures = value;
            }
        }
        #endregion

        

        #region Serialization
        //[XmlArray("FoodsAvailable")]
        //public List<Pair<Food, int>> SerializeDictionary
        //{
        //    get
        //    {
        //        var test=this.FoodsAvailable.Select(x=>new Pair<Food, int>(x.Key, x.Value)).ToList();
        //        return test;
        //    }
        //    set
        //    {
        //        this.FoodsAvailable = value.ToDictionary(x=>x.ToKeyValuePair().Key, x=>x.ToKeyValuePair().Value);
        //    }
        //}

        public void Serialize(string path = "../../")
        {
            var serializer = new SharpSerializer();
            serializer.Serialize(this, path + this.name + ".xml");
        }

        public static Animal Deserialize(string path = "../../player.xml")
        {
            var serializer = new SharpSerializer();
            return (Animal)serializer.Deserialize(path); ;
        }

        #endregion
    }
}
