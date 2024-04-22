using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Patterns
{
    public interface IDog
    {
        void Action();
        void Speak();
    }

    public interface ITiger
    {
        void Action();
        void Speak();
    }

    public interface IAnimalFactory
    {
        IDog GetDog();
        ITiger GetTiger();
    }
    public class WildDog : IDog
    {
        public void Action()
        {
            Console.WriteLine("Wild Dogs prefer to roam freely in jungles.");
        }

        public void Speak()
        {
            Console.WriteLine("Wild Dog says: Bow-Wow");
        }
    }

    public class PetDog : IDog
    {
        public void Action()
        {
            Console.WriteLine("Pet Dogs prefer to stay at home.");
        }

        public void Speak()
        {
            Console.WriteLine("Pet Dog says: Bow-Wow.");
        }
    }

    public class WildTiger : ITiger
    {
        public void Action()
        {
            Console.WriteLine("Wild Tigers prefer hunting in jungles.");
        }

        public void Speak()
        {
            Console.WriteLine("Wild Tiger says: Halum.");
        }
    }

    public class PetTiger : ITiger
    {
        public void Action()
        {
            Console.WriteLine("Pet Tigers play in an animal circus.");
        }

        public void Speak()
        {
            Console.WriteLine("Pet Tiger says: Halum.");
        }
    }
    public class WildFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new WildDog();
        }

        public ITiger GetTiger()
        {
            return new WildTiger();
        }
    }

    public class PetFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }

        public ITiger GetTiger()
        {
            return new PetTiger();
        }
    }



}
