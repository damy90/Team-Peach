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
        private const int MaxValue = 100;

        private Condition initialCondition;
        private Gender sex;
        private string name;
        protected readonly Random random;

        public Animal() { }

        public Animal(Gender sex, string name)
        {
            this.Name = name;
            this.sex = sex;
            this.initialCondition = new Condition(MaxValue);
            if (this is ICarnivorous)
                random = new Random();
        }

        public Animal(Gender sex, string name, Condition initialCondition)
            : this(sex, name)
        {
            this.initialCondition = initialCondition;
        }

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
