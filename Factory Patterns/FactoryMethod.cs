//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Factory_Patterns
//{
//    public interface IAnimal
//    {
//        void Action();
//        void Speak();
//    }

//    public class Dog : IAnimal
//    {
//        public void Action()
//        {
//            Console.WriteLine("Dog says: Bow-wow");
//        }

//        public void Speak()
//        {
//            Console.WriteLine("Dogs prefer barking...");
//        }
//    }

//    public class Tiger : IAnimal
//    {
//        public void Action()
//        {
//            Console.WriteLine("Tigers prefer hunting...\r\n");
//        }

//        public void Speak()
//        {
//            Console.WriteLine("Tiger says: Halum.");
//        }
//    }

//    public abstract class AnimalFactory
//    {
//        public IAnimal MakeAnimal()
//        {
//            Console.WriteLine("AnimalFactory.MakeAnimal()-You cannot ignore parent rules.");
//            var animal = CreateAnimal();
//            animal.Speak();
//            animal.Action();
//            return animal;
//        }
//        protected abstract IAnimal CreateAnimal();
//    }

//    public class DogFactory : AnimalFactory
//    {
//        protected override IAnimal CreateAnimal()
//        {
//            return new Dog();
//        }
//    }

//    public class TigerFactory : AnimalFactory
//    {
//        protected override IAnimal CreateAnimal()
//        {
//            return new Tiger();
//        }
//    }

    

//}
