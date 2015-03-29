using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public abstract class Animal
    {
        private const int ConditionMaxValue = 100;

        private Condition initialCondition;
        private Gender sex;
        private string name;
        protected readonly Random random;
        private IList<Food> foodsAllowed = new List<Food>();
        private Dictionary<Food, int> foodsAvailable = new Dictionary<Food, int>();
        private IList<Food> foodsInfinite  = new List<Food>();

        #region Constructors
        public Animal()
        {
            this.name = this.GetType().Name;
            this.Sex = Gender.Male;
            this.initialCondition = new Condition(ConditionMaxValue);
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
            this.initialCondition = initialCondition;
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
            private set
            {
                if (value != null)
                {
                    this.sex = value;
                }
            }
        }

        public Condition CurrentCondition
        {
            get
            {
                return this.initialCondition;
            }
            set
            {
                this.initialCondition = value;
            }
        }

        public Dictionary<Food, int> FoodsAvailable
        {
            get
            {
                return this.foodsAvailable;
            }
            set
            {
                if (value != null)
                {
                    this.foodsAvailable = value;
                }
                else
                {
                    throw new ArgumentNullException("List of available foods cannot be null");
                }
            }
        }

        public IList<Food> FoodsInfinite
        {
            get
            {
                return this.foodsInfinite;
            }
            private set
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

        public IList<Food> FoodsAllowed
        {
            get
            {
                return this.foodsAllowed;
            }
            private set
            {
                if (value != null)
                {
                    this.foodsAllowed = value;
                }
                else
                {
                    throw new ArgumentNullException("List of allowed foods cannot be null");
                }
            }
        }
        #endregion

        #region Public Methods
        public void AddToAvailableFoods(Food food, int quantity)
        {
            if (this.FoodsAvailable.ContainsKey(food))
            {
                this.FoodsAvailable[food] += quantity;
            }
            else
            {
                this.FoodsAvailable.Add(food, quantity);
            }
        }

        // Cheks if there is enough of the quantity demanded and removes it from the dictioanry value
        public void RemoveFromAvailableFoods(Food food, int quantity)
        {
            if (this.FoodsAvailable.ContainsKey(food))
            {
                if (this.FoodsAvailable[food] >= quantity)
                {
                    this.FoodsAvailable[food] -= quantity;
                }
                else
                {
                    throw new ArgumentException("Not enough quantity of food");
                }
            }
            else
            {
                throw new ArgumentException("This food is missing from the list");
            }
        }
        #endregion
       
        public void Serialize(string path = "../../")
        {
            XmlSerializer xml = new XmlSerializer(this.GetType());
            StreamWriter file = new StreamWriter(path + this.name + ".xml");
            xml.Serialize(file, this);
            file.Close();
        }

        public Animal Deserialize(string path = "../../player.xml")
        {
            XmlSerializer xml = new XmlSerializer(this.GetType());
            StreamReader file = new StreamReader(path);
            Animal _instance = (Animal)xml.Deserialize(file);
            file.Close();
            return _instance;
        }
    }
}
