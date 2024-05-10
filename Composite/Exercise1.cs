//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Composite
//{
//	public interface IGraphic
//	{
//		void Move(int x, int y);
//		void Draw();
//	}
//	public class Dot : IGraphic
//	{
//		public int X { get; private set; }
//		public int Y { get; private set; }
//		public Dot(int x, int y)
//		{
//			X = x;
//			Y = y;
//		}
//		public void Move(int x, int y)
//		{
//			X += x;
//			Y += y;
//		}
//		public void Draw()
//		{
//			Console.WriteLine($"Ve mot dau cham tai ({X}, {Y})");
//		}
//	}
//	public class Circle : IGraphic
//	{
//		public int X { get; private set; }
//		public int Y { get; private set; }
//		public int Radius { get; private set; }
//		public Circle(int x, int y, int radius)
//		{
//			X = x;
//			Y = y;
//			Radius = radius;
//		}
//		public void Move(int x, int y)
//		{
//			X += x;
//			Y += y;
//		}
//		public void Draw()
//		{
//			Console.WriteLine($"Ve mot hinh tron tai ({X}, {Y}) co ban kinh {Radius}.");
//		}
//	}
//	public class CompoundGraphic : IGraphic
//	{
//		private List<IGraphic> children = new List<IGraphic>();
//		public void Add(IGraphic child)
//		{
//			children.Add(child);
//		}
//		public void Remove(IGraphic child)
//		{
//			children.Remove(child);
//		}
//		public void Move(int x, int y)
//		{
//			foreach (var child in children)
//			{
//				child.Move(x, y);
//			}
//		}
//		public void Draw()
//		{
//			foreach (var child in children)
//			{
//				child.Draw();
//			}
//		}
//	}
//	class Program
//	{
//		static void Main(string[] args)
//		{
//			var dot = new Dot(1, 1);
//			var circle = new Circle(5, 5, 3);
//			var compoundGraphic = new CompoundGraphic();

//			compoundGraphic.Add(dot);
//			compoundGraphic.Add(circle);

//			compoundGraphic.Draw();

//			compoundGraphic.Move(2, 2);

//			compoundGraphic.Draw();
//			Console.ReadKey();
//		}
//	}
//}
