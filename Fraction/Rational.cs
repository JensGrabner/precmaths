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
        public SignedBigInteger Numerator;
        public SignedBigInteger Denominator;
        public Rational(SignedBigInteger Numerator, SignedBigInteger Denominator)
        {
            this.Numerator = Numerator.Clone();
            this.Denominator = Denominator.Clone();
            if (this.Denominator == 0)
            {
                throw new ArgumentOutOfRangeException("denominators of rationals cannot be zero");
            }
        }
        public Rational(SignedBigInteger Numerator)
        {
            this.Numerator = Numerator.Clone();
            this.Denominator = 1;
        }
        public void Reduce()
        {
            SignedBigInteger a = this.Numerator;
            SignedBigInteger b = this.Denominator;
            while (b != 0)
            {
                SignedBigInteger t = b;
                b = a % b;
                a = t;
            }
            this.Numerator /= a;
            this.Denominator /= a;
            if (this.Denominator.Negative)
            {
                this.Numerator *= -1;
                this.Denominator *= -1;
            }
        }
        public static Rational operator *(Rational a, Rational b)
        {
            Rational r = new Rational(a.Numerator * b.Numerator, b.Denominator * a.Denominator);
            r.Reduce();
            return r;
        }
        public static Rational operator /(Rational a, Rational b)
        {
            Rational r = new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
            r.Reduce();
            return r;
        }
        public static Rational operator +(Rational a, Rational b)
        {
            SignedBigInteger commonbase = a.Denominator * b.Denominator;
            SignedBigInteger atop = a.Numerator * b.Denominator;
            SignedBigInteger btop = b.Numerator * a.Denominator;
            Rational r = new Rational(atop + btop, commonbase);
            r.Reduce();
            return r;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            SignedBigInteger commonbase = a.Denominator * b.Denominator;
            SignedBigInteger atop = a.Numerator * b.Denominator;
            SignedBigInteger btop = b.Numerator * a.Denominator;
            Rational r = new Rational(atop - btop, commonbase);
            r.Reduce();
            return r;
        }
        public static bool operator ==(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs == rhs;
        }
        public static bool operator !=(Rational a, Rational b)
        {
            return !(a == b);
        }
        public static bool operator <(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs < rhs;
        }
        public static bool operator >(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs > rhs;
        }
        public static bool operator >=(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs >= rhs;
        }
        public static bool operator <=(Rational a, Rational b)
        {
            SignedBigInteger lhs = a.Numerator * b.Denominator;
            SignedBigInteger rhs = b.Numerator * a.Denominator;
            return lhs <= rhs;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return (Rational)obj == this;
            }
            if (obj.GetType() == 1.GetType())
            {
                return (int)obj == this;
            }
            if (obj.GetType() == 1L.GetType())
            {
                return (long)obj == this;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Numerator.Number.GetBytes()[0];
        }
        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }
        public static implicit operator Rational(long a)
        {
            return new Rational(a);
        }
    }
}
