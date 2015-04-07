namespace Models
{
    using System.Collections.Generic;
 
    public interface IAnimal
    {
        string Name { get; }
        
        Gender Sex { get; }

        List<Food> FoodsInfinite { get; }

        string[] Pictures { get; }
    }
}
