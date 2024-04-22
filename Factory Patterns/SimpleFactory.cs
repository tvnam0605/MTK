using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Patterns
{
    //public interface IAnimal
    //{
    //    void Action();
    //    void Speak();
    //}
    //public class Tiger: IAnimal
    //{
    //    public void Action()
    //    {
    //        Console.WriteLine("The tiger hunts.");
    //    }

    //    public void Speak()
    //    {
    //        Console.WriteLine("The tiger roars.");
    //    }
    //}
    //public class Dog : IAnimal
    //{
    //    public void Action()
    //    {
    //        Console.WriteLine("The dog runs.");
    //    }

    //    public void Speak()
    //    {
    //        Console.WriteLine("The dog barks.");
    //    }
    //}
    //public interface ISimpleFactory
    //{
    //    IAnimal CreateAnimal(string animalType);
    //}
    //public class SimpleFactory : ISimpleFactory
    //{
    //    public IAnimal CreateAnimal(string animalType)
    //    {
    //        switch (animalType.ToLower())
    //        {
    //            case "tiger":
    //                return new Tiger();
    //            case "dog":
    //                return new Dog();
    //            default:
    //                throw new ArgumentException("Unknown animal type");
    //        }
    //    }
    //}
}
