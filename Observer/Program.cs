using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
	public class FallsIllEventArgs : EventArgs
	{
		public string Address { get; set; }
	}

	public class Person
	{
		public event EventHandler<FallsIllEventArgs> FallsIll;

		public void CatchACold()
		{
			FallsIll?.Invoke(this, new FallsIllEventArgs { Address = "1 TNT P8" });
		}
	}

	public class Program
	{
		//public static void Main()
		//{
		//	var person = new Person();
		//	person.FallsIll += Person_FallsIll;

		//	person.CatchACold();
		//	person.CatchACold();

		//	person.FallsIll -= Person_FallsIll;

		//	person.CatchACold();
		//	Console.ReadKey();
		//}

		//private static void Person_FallsIll(object sender, FallsIllEventArgs e)
		//{
		//	Console.WriteLine("A doctor has been called to " + e.Address);
			
		//}
		
	}
	
}
