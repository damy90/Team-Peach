using System;
using Models;

namespace Models
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string species, Gender gender, string name)
        {
            Animal pet;
            switch (species)
                {
                    case "Cat":
                        pet = new Cat(gender, name);
                        break;
                    case "Dog":
                        pet = new Dog(gender, name);
                        break;
                    //etc...
                    default:
                        throw new ArgumentException("Animal does not exist!");
                }

            return pet;
        }
    }
}
