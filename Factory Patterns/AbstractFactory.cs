using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Patterns
{
    public abstract class Herbivore
    {
        
    }
    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore herbivore);
    }
    public class Bison: Herbivore { }
    public class Wildebeest:Herbivore { }
    public class Deer : Herbivore { }

    public class Wolf :Carnivore {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().Name} eats {herbivore.GetType().Name}");
        }
    }
    public class Lion : Carnivore {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().Name} eats {herbivore.GetType().Name}");
        }
    }
    public class Tiger : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().Name} eats {herbivore.GetType().Name}");
        }
    }
    public interface IContinentFactory {
        Herbivore CreateHerbivore();
        Carnivore CreateCarnivore();

    }
    public class AfricaFactory: IContinentFactory
    {
        public Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
    public class AmericaFactory : IContinentFactory
    {
        public Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
    public class AsiaFactory : IContinentFactory
    {
        public Herbivore CreateHerbivore()
        {
            return new Deer();
        }

        public Carnivore CreateCarnivore()
        {
            return new Tiger();
        }
    }
    public class AnimalWorld
    {
        private Carnivore _carnivore;
        private Herbivore _herbivore;
        public AnimalWorld(IContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {

            _carnivore.Eat(_herbivore);
        }
    }

}
