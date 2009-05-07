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
            Rational e = new Rational(1, 2);
            Console.WriteLine(e.Evaluate());
            e = new Rational(1, 3);
            Console.WriteLine(e.Evaluate());
            Console.ReadLine();
        }
    }
}
