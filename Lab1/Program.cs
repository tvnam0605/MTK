using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Singleton;
namespace Singleton
{
    public class Program
    {
        public static void Main()
        {
            // Singleton in single-threaded environment
            //var s1 = Singleton.GetInstance();
            //var s2 = Singleton.GetInstance();

            //Console.WriteLine(s1 == s2
            //    ? "Singleton works, both variables contain the same instance."
            //    : "Singleton failed, variables contain different instances.");

            // Singleton in multi-threaded environment
            var tasks = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                tasks[i] = new Thread(TestSingleton);
                tasks[i].Start();
            }

            foreach (var t in tasks)
            {
                t.Join();
            }
        }

        private static void TestSingleton()
        {
            var singleton = Singleton.GetInstance();
            Console.WriteLine(singleton);
        }
    }
}
