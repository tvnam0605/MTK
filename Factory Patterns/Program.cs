using System;
namespace Factory_Patterns
{
    #region Factory
    public enum CoordinateSystem
    {
        Polar,
        Cartesian
    }

    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(float r, float theta)
        {
            X = r * Math.Cos(theta);
            Y = r * Math.Sin(theta);
        }

        public Point(double a, double b, CoordinateSystem cs)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    X = a * Math.Cos(b);
                    Y = a * Math.Sin(b);
                    break;
                case CoordinateSystem.Cartesian:
                    X = a;
                    Y = b;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cs), cs, null);
            }
        }

        public double X { get; }
        public double Y { get; }
    }
    #endregion 


    public class Program
    {
        public class PointFactory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta * (Math.PI / 180)), rho * Math.Sin(theta * (Math.PI / 180)));
            }
        }
        public static void Main()
        {
            //var p1 = new Point(12, 5);
            //var p2 = new Point(13, 22.6);
            //var p3 = new Point(13, 22.6, CoordinateSystem.Polar);
            //Console.WriteLine($"Point p1: X = {p1.X}, Y = {p1.Y}");
            //var p1 = PointFactory.NewCartesianPoint(12, 5);
            //var p2 = PointFactory.NewPolarPoint(13, 22.6);
            //Console.WriteLine($"Point p1: X = {p1.X}, Y = {p1.Y}");
            //Console.WriteLine($"Point p2: X = {p2.X}, Y = {p2.Y}");
            //ISimpleFactory animalFactory = new SimpleFactory();

            //IAnimal tiger = animalFactory.CreateAnimal("tiger");
            //tiger.Action();
            //tiger.Speak();
            //tiger.Action();

            //IAnimal dog = animalFactory.CreateAnimal("dog");
            //dog.Action();
            //dog.Speak();

            //AnimalFactory dogFactory = new DogFactory();
            //    AnimalFactory tigerFactory = new TigerFactory();

            //    // Use the factories to create animals.
            //    IAnimal dog = dogFactory.MakeAnimal();
            //    IAnimal tiger = tigerFactory.MakeAnimal();

            // Since MakeAnimal already calls Speak and Action, no need to call them here


            //AnimalWorld world;

            //world = new AnimalWorld(new AfricaFactory());
            //world.RunFoodChain();

            //world = new AnimalWorld(new AmericaFactory());
            //world.RunFoodChain();

            //world = new AnimalWorld(new AsiaFactory());
            //world.RunFoodChain();
            Console.WriteLine("***Abstract Factory Pattern Demo***\n");
            //Making a wild dog through WildAnimalFactory
            var wildAnimalFactory = new WildFactory();
            var wildDog = wildAnimalFactory.GetDog();
            wildDog.Speak();
            wildDog.Action();
            //Making a wild tiger through WildAnimalFactory
            var wildTiger = wildAnimalFactory.GetTiger();
            wildTiger.Speak();
            wildTiger.Action();
            Console.WriteLine("******************");
            //Making a pet dog through PetAnimalFactory
            var petAnimalFactory = new PetFactory();
            var petDog = petAnimalFactory.GetDog();
            petDog.Speak();
            petDog.Action();
            //Making a pet tiger through PetAnimalFactory
            var petTiger = petAnimalFactory.GetTiger();
            petTiger.Speak();
            petTiger.Action();
            Console.ReadLine();

        }
    }
}
