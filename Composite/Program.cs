using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var drawing = new Square("My Drawing", "Black");

            drawing.Children.Add(new Square("Red Square", "Red"));
            drawing.Children.Add(new Circle("Yellow Circle", "Yellow", 3.0));

            var group = new Square("Group", "White"); 
            group.Children.Add(new Square("Blue Square", "Blue"));
            group.Children.Add(new Circle("Blue Circle", "Blue", 4.0));
            drawing.Children.Add(group);

            drawing.Print(0); 
            Console.ReadKey();
        }

    }

    // Lớp cơ sở cho hình vuông và hình tròn
    public abstract class GraphObject
    {
        public abstract void Print(int depth); 
        public abstract override string ToString();
    }

    // Lớp hình vuông
    public class Square : GraphObject
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public List<GraphObject> Children { get; set; }

        public Square(string name, string color)
        {
            Name = name;
            Color = color;
            Children = new List<GraphObject>();
        }

        public override void Print(int depth)
        {
            Console.WriteLine(new string('*', depth) + Name); 
            foreach (var child in Children)
            {
                child.Print(depth + 1); 
            }
        }

        public override string ToString()
        {
            return $"Square: Name = {Name}, Color = {Color}";
        }
    }

    // Lớp hình tròn
    public class Circle : GraphObject
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double Radius { get; set; }

        public Circle(string name, string color, double radius)
        {
            Name = name;
            Color = color;
            Radius = radius;
        }

        public override void Print(int depth)
        {
            Console.WriteLine(new string('*', depth) + Name);
        }

        public override string ToString()
        {
            return $"Circle: Name = {Name}, Color = {Color}, Radius = {Radius}";
        }
    }
}
