﻿/*
 * Copyright Sam Phippen 2009
 */
 
using System;
using System.Collections.Generic;
using System.Text;
using Mono.Math;

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
        public double Evaluate()
        {
            if ((Numerator / Denominator).Number > new BigInteger(ulong.MaxValue))
            {
                throw new InvalidOperationException("evaluation cannot be done on huge values");
            }
            else
            {
                this.Reduce();
                bool negative = Numerator.Negative;
                BigInteger p1 = Numerator.Number;
                BigInteger p2 = Denominator.Number;
                byte[] beforepoint = (p1 / p2).GetBytes();
                double result = 0;
                for (int i = 0; i < beforepoint.Length; i++)
                {
                    result += beforepoint[i] << (8 * i);
                }
                BigInteger remainder = p1 % p2;
                int shifts = 0;
                for (int i = 0; i < 64; i++)
                {
                    remainder *= 10;
                    shifts += 1;
                    byte[] some_more_juice = (remainder/p2).GetBytes();
                    for (int j = 0; j < some_more_juice.Length; j++)
                    {
                        result += (float)some_more_juice[j] / (Math.Pow(10,shifts));
                    }
                    remainder = remainder % p2;
                }
                if (negative)
                {
                    return -1 * result;
                }
                else
                {
                    return result;
                }
            }

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
