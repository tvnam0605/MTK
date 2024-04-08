using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("Create Singleton");
        }

        private DateTime DateCreated { get; } = DateTime.Now;

        public override string ToString()
        {
            return DateCreated.ToString("O");
        }

        private static Lazy<Singleton> _lazyInstance = new Lazy<Singleton>(() => new Singleton());

        public static Singleton GetInstance()
        {
            return _lazyInstance.Value;
        }


    }
}
