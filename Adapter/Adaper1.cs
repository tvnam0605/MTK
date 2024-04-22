using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class RoundHole
    {
        private int Radius { get; }
        public RoundHole(int radius) 
        {
            Radius = radius;
        }
        public bool Fits(RoundPeg peg)
        {
            return Radius >= peg.Radius;
        }

        
    }
    public class RoundPeg
    {
        public RoundPeg(int radius)
        {
            Radius = radius;
        }
        public virtual int Radius { get; }   
    }
    public class SquarePeg
    {
        public int Width { get; }
        public SquarePeg(int width)
        {
            Width = width;
        }
        public double  CaculateArea()
        {
            return Width * Width;
        }
    }
    public class SquarePegAdapter : RoundPeg
    {
        private SquarePeg peg;
        
        public SquarePegAdapter(SquarePeg peg):base(0)
        {
            this.peg = peg;
        }
        public override int Radius
        {
            get
            {
                return (int)(peg.Width * Math.Sqrt(2) / 2);
            }
        }
    }

    //public class Program
    //{
    //    static void Main()
    //    {
    //        // Round fits round, no surprise.
    //        var hole = new RoundHole(5);
    //        var rpeg = new RoundPeg(5);
    //        if (hole.Fits(rpeg))
    //        {
    //            Console.WriteLine("Round peg r5 fits round hole r5.");
    //        }

    //        var smallSqPeg = new SquarePeg(2);
    //        var largeSqPeg = new SquarePeg(20);
    //        // hole.Fits(smallSqPeg); // Won't compile.

    //        // Adapter solves the problem.
    //        var smallSqPegAdapter = new SquarePegAdapter(smallSqPeg);
    //        var largeSqPegAdapter = new SquarePegAdapter(largeSqPeg);
    //        if (hole.Fits(smallSqPegAdapter))
    //        {
    //            Console.WriteLine("Square peg w2 fits round hole r5.");
    //        }

    //        if (!hole.Fits(largeSqPegAdapter))
    //        {
    //            Console.WriteLine("Square peg w20 does not fit into round hole r5.");
    //        }
    //    }
    //}
}
