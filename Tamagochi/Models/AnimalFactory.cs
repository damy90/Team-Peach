using System;

namespace Models
{
    public static class AnimalFactory
    {
        public static Animal Pet;

        public static Animal CreateAnimal(string species, Gender gender, string name)
        {
            if (Pet != null)
            {
                throw new ApplicationException("You can only have one pet!");
            }

            switch (species)
                {
                    case "Cat":
                        Pet = new Cat(gender, name);
                        break;
                    case "Dog":
                        Pet = new Dog(gender, name);
                        break;
                    case "Camelopard":
                        Pet = new Camelopard(gender, name);
                        break;
                    case "Carp":
                        Pet = new Carp(gender, name);
                        break;
                    case "Eagle":
                        Pet = new Eagle(gender, name);
                        break;
                    case "Parrot":
                        Pet = new Parrot(gender, name);
                        break;
                    case "Piranha":
                        Pet = new Piranha(gender, name);
                        break;
                    //etc...
                    default:
                        throw new ArgumentException(String.Format("Animal {0} does not exist!", species));
                }

            return Pet;
        }

        public static void KillPet()
        {
            Pet = null;
        }
    }
}
