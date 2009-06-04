using System;
using System.Collections.Generic;
using System.Text;
using PrecMaths;
using NUnit.Framework;
using Mono.Math;

namespace FracTests
{
    class program
    {
        public static void Main()
        {
            Rational e = new Rational(2, 1);
            IrrationalFormA a = new IrrationalFormA(1, e, new Rational(1, 2));
            Console.WriteLine(a.Evaluate(15));
            Console.WriteLine("1.41421356");
            Console.ReadLine();
        }
    }
}
