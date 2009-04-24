/*
 * Copyright Sam Phippen 2009
 */
 
using System;
using System.Collections.Generic;
using System.Text;

namespace PrecMaths
{
    /// <summary>
    /// This defines a class that represents rational numbers
    /// </summary>
    public class Rational
    {
        /// <summary>
        /// The numerator of the rational number
        /// </summary>
        private Int64 Numerator;
        /// <summary>
        /// The denominator of the rational number
        /// </summary>
        private Int64 Denominator;
        
        /// <summary>
        /// this creates a new rational number,
        /// with a numerator and a denominator
        /// </summary>
        /// <param name="Numerator">The numerator</param>
        /// <param name="Denominator">The denominator</param>
        public Rational(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            if (this.Denominator == 0)
            {
                throw new InvalidOperationException("the denominator can't be zero");
            }
        }
        /// <summary>
        /// this initialises the numerator and sets the denominator to one
        /// </summary>
        /// <param name="Numerator">The numerator of the rational number</param>
        public Rational(int Numerator)
        {
            this.Numerator = Numerator;
            this.Denominator = 1;
        }
        /// <summary>
        /// this initialises the numerator and sets the denominator to one
        /// </summary>
        /// <param name="Numerator">The numerator of the rational number</param>
        public Rational(Int64 Numerator)
        {
            this.Numerator = Numerator;
            this.Denominator = 1;
        }
        /// <summary>
        /// this initialises the numerator and denominator
        /// </summary>
        /// <param name="Numerator">the numerator</param>
        /// <param name="Denominator">the denominator</param>
        public Rational(Int64 Numerator, Int64 Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            if (this.Denominator == 0)
            {
                throw new InvalidOperationException("the denominator can't be zero");
            }
        }
        /// <summary>
        /// evaluates the rational as a double
        /// </summary>
        /// <param name="nprec">the precision to evaluate to</param>
        /// <returns>the number as a double</returns>
        public double Evaluate(int nprec){
            Int64 n = Numerator;
            string result = "";
            for (int i = 0; i < nprec; i++)
            {
                result += (n/this.Denominator);
                if (i == 0)
                {
                    result += ".";
                }
                n = Math.Abs(n % this.Denominator)*10;
            }
            return double.Parse(result);

        }
        /// <summary>
        /// evaluates the rational as a double
        /// </summary>
        /// <returns>the number as a double</returns>
        public double Evaluate()
        {
            Int64 n = Numerator;
            string result = "";
            if (n < 0)
            {
                result += "-";
            }
            for (int i = 0; i < 64; i++)
            {
                result += (Math.Abs(n) / this.Denominator);
                if (i == 0)
                {
                    result += ".";
                }
                n = Math.Abs(n % this.Denominator) * 10;
            }
            return double.Parse(result);
        }
        /// <summary>
        /// evaluates the rational as a string
        /// </summary>
        /// <param name="nprec">the precision to evaluate to</param>
        /// <returns>the number as a string</returns>
        public string EvaluateString(int nprec)
        {
            Int64 n = Numerator;
            string result = "";
            if (n < 0)
            {
                result += "-";
            }
            n = Math.Abs(n);
            for (int i = 0; i <= nprec; i++)
            {
                result += (n / this.Denominator);

                if (i == 0)
                {
                    result += ".";
                }
                n = Math.Abs(n % this.Denominator) * 10;
            }
            return result;

        }
        /// <summary>
        /// creates a pretty version of the number
        /// </summary>
        /// <returns>a string that represents the number</returns>
        //TODO: make this print on three lines with a line of dashes in the middle
        public string PrettyPrint()
        {
            string top = this.Numerator.ToString();
            string bottom = this.Numerator.ToString();
            if (top.Length > bottom.Length)
            {

            }
            return this.Numerator.ToString() + "/" + this.Denominator.ToString();
        }
        /// <summary>
        /// converts the number to a string
        /// </summary>
        /// <returns>the number pretty printed</returns>
        public override string ToString()
        {
            return this.PrettyPrint();
        }
        /// <summary>
        /// this reduces the fraction such that gcd(numerator,denominator) = 1
        /// </summary>
        public void Reduce()
        {
            Int64 gcd;
            Int64 a = this.Numerator;
            Int64 b = this.Denominator;
            while (b != 0)
            {
                Int64 t = b;
                b = a % b;
                a = t;
            }
            gcd = a;
            this.Numerator = this.Numerator / a;
            this.Denominator = this.Denominator / a;

            
        }
        /// <summary>
        /// this clones the rational number
        /// </summary>
        /// <returns>an instance of the rational number with the same numerator and denominator</returns>
        public Rational Clone()
        {
            return new Rational(this.Numerator, this.Denominator);
        }
        public static implicit operator Rational(Int64 a)
        {
            return new Rational(a);
        }
        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            Rational result = new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            result.Reduce();
            return result;
        }
        public static Rational operator /(Rational a, Rational b)
        {
            Rational result = new Rational(a.Numerator * b.Denominator, b.Numerator * a.Denominator);
            result.Reduce();
            return result;
        }
        public static Rational operator +(Rational a, Rational b)
        {
            Int64 commonbase = a.Denominator * b.Denominator;
            Int64 top = (a.Numerator * b.Denominator)+(b.Numerator*b.Denominator);
            Rational result = new Rational(top, commonbase);
            result.Reduce();
            return result;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            Int64 commonbase = a.Denominator * b.Denominator;
            Int64 top = (a.Numerator * b.Denominator) - (b.Numerator * a.Denominator);
            Rational result = new Rational(top, commonbase);
            result.Reduce();
            return result;
        }
        public static bool operator ==(Rational a, Rational b)
        {
            Rational r_1 = a.Clone();
            Rational r_2 = b.Clone();
            r_1.Reduce();
            r_2.Reduce();
            return (r_1.Numerator == r_2.Numerator && r_1.Denominator == r_2.Denominator);
            
             
        }
        public static bool operator !=(Rational a, Rational b)
        {
            Rational r_1 = a.Clone();
            Rational r_2 = b.Clone();
            r_1.Reduce();
            r_2.Reduce();
            return (r_1.Numerator != r_2.Numerator || r_1.Denominator != r_2.Denominator);
        }
        public static bool operator >(Rational a, Rational b)
        {
            Rational r_1 = a.Clone();
            Rational r_2 = b.Clone();
            r_1.Reduce();
            r_2.Reduce();
            Int64 lhs = r_1.Numerator * r_2.Denominator;
            Int64 rhs = r_2.Numerator * r_1.Denominator;
            return (lhs > rhs);
        }
        public static bool operator <(Rational a, Rational b)
        {
            Rational r_1 = a.Clone();
            Rational r_2 = b.Clone();
            r_1.Reduce();
            r_2.Reduce();
            Int64 lhs = r_1.Numerator * r_2.Denominator;
            Int64 rhs = r_2.Numerator * r_1.Denominator;
            return (lhs < rhs);
        }
        public static bool operator >=(Rational a, Rational b)
        {
            Rational r_1 = a.Clone();
            Rational r_2 = b.Clone();
            r_1.Reduce();
            r_2.Reduce();
            Int64 lhs = r_1.Numerator * r_2.Denominator;
            Int64 rhs = r_2.Numerator * r_1.Denominator;
            return (lhs >= rhs);
        }
        public static bool operator <=(Rational a, Rational b)
        {
            Rational r_1 = a.Clone();
            Rational r_2 = b.Clone();
            r_1.Reduce();
            r_2.Reduce();
            Int64 lhs = r_1.Numerator * r_2.Denominator;
            Int64 rhs = r_2.Numerator * r_1.Denominator;
            return (lhs <= rhs);
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return this == (Rational)obj;
            }
            return false;
            
        }
        public override int GetHashCode()
        {
            return (int)((this.Denominator-this.Numerator)%Math.Pow(2,32));
        }
    }
}
