using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
	public class GraphObject
	{
		public string Name { get; set; } = "Group";
		public string Color { get; set; }
		public List<GraphObject> Children { get; set; } = new List<GraphObject>();
		public virtual void Print(StringBuilder sb, int depth)
		{
			sb.Append(new string('*', depth)).Append(string.IsNullOrEmpty(Color) ? "" : $"{Color} ").AppendLine(Name);
			foreach (var child in Children)
			{
				child.Print(sb, depth + 1);
			}
		}
		public override string ToString()
		{
			var sb = new StringBuilder();
			Print(sb, 0);
			return sb.ToString();
		}

	}
	public class Square : GraphObject
	{
		public Square()
		{
			Name = nameof(Square);
		}
	}
	public class Circle : GraphObject
	{
		public Circle()
		{
			Name = nameof(Circle);
		}
	}
	public static class GeometricShapes
	{
		public static void Run()
		{
			var drawing = new GraphObject { Name = "My Drawing" };
			drawing.Children.Add(new Square { Color = "Red" });
			drawing.Children.Add(new Circle { Color = "Yellow" });

			var group = new GraphObject();
			group.Children.Add(new Square { Color = "Blue" });
			group.Children.Add(new Circle { Color = "Blue" });
			drawing.Children.Add(group);

			Console.WriteLine(drawing);
			Console.ReadKey();

		}
	}

	class Exercise2
	{
		static void Main(string[] args)
		{
			GeometricShapes.Run();
		}
	}
}
