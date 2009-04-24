using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths;

namespace FracTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r_1 = new Rational(409813082319810617,-122332313750680800);
            Rational r_2 = new Rational(1, 44);
            r_1 -= r_2;
            Console.WriteLine(r_1.PrettyPrint());
            Console.ReadLine();
            
        }
    }
}
