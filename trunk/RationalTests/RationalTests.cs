using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using PrecMaths;
using Mono.Math;

namespace RationalTests
{
    [TestFixture]
    public class SignedBigIntegerTests
    {
        [Test]
        public void InitialiseFromInt()
        {
            SignedBigInteger e = new SignedBigInteger(1);
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(1), e.Number);
            e = new SignedBigInteger(-4);
            Assert.AreEqual(true, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
        }
        [Test]
        public void MultiplicationTest()
        {
            SignedBigInteger e = new SignedBigInteger(1);
            e *= 4;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
            e *= -1;
            Assert.AreEqual(true, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
            e *= e;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(16), e.Number);
        }
        [Test]
        public void AdditionTest()
        {
            SignedBigInteger e = new SignedBigInteger(2);
            e += e;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
            e += new SignedBigInteger(-6);
            Assert.AreEqual(true, e.Negative);
            Assert.AreEqual(new BigInteger(2), e.Number);
            e += 3;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(1), e.Number);
        }
        [Test]
        public void SubtractionTest()
        {
            SignedBigInteger e = new SignedBigInteger(2);
            e -= 2;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(0), e.Number);
            e = new SignedBigInteger(4);
            e -= new SignedBigInteger(-6);
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(10), e.Number);
            e -= 14;
            Assert.AreEqual(true, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
        }
        [Test]
        public void DivisionTest()
        {
            SignedBigInteger e = new SignedBigInteger(24);
            e = e / 6L;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
            e = new SignedBigInteger(24);
            e = e / -8;
            Assert.AreEqual(true, e.Negative);
            Assert.AreEqual(new BigInteger(3), e.Number);
        }
        [Test]
        public void CompareTest()
        {
            SignedBigInteger e = new SignedBigInteger(24);
            Assert.That(24 == e);
            Assert.That(23 < e);
            Assert.That(24 <= e);
            Assert.That(!(23 >= e));
            Assert.That(-1 < e);
            Assert.That(25 > e);
            Assert.That(-1 != e);
            
        }
    }
    [TestFixture]
    public class RationalTests
    {
        [Test]
        public void InitialiseTest()
        {
            Rational r = new Rational(12);
            Assert.That(12 == r);
            r = new Rational(-12);
            Assert.That(-12 == r);
            r = new Rational(120L);
            Assert.That(120 == r);
        }
        [Test]
        public void MultiplyTest()
        {
            Rational r = new Rational(2);
            r = r * 4;
            Assert.That(8 == r);
            r *= -1;
            Assert.That(-8 == r);
            r = new Rational(1, 4);
            r = r * 6;
            Assert.AreEqual(new Rational(3, 2), r);
        }
        [Test]
        public void DivideTest()
        {
            Rational r = new Rational(1, 2);
            r /= 2;
            Assert.AreEqual(new Rational(1, 4), r);
            r = new Rational(-1, 2);
            r /= 2;
            Assert.AreEqual(new Rational(-1, 4), r);
        }
        [Test]
        public void AddTest()
        {
            Rational r = new Rational(1, 3);
            r += new Rational(1, 4);
            Assert.AreEqual(new Rational(7, 12), r);
            r += new Rational(-3, 4);
            Assert.AreEqual(new Rational(-2, 12), r);
        }
        [Test]
        public void SubtractTest()
        {
            Rational r = new Rational(1, 3);
            r -= new Rational(5, 6);
            Assert.AreEqual(new Rational(-1, 2), r);
            r -= new Rational(-4, 6);
            Assert.AreEqual(new Rational(1, 6), r);
        }
        [Test]
        public void ReduceTest()
        {
            Rational r = new Rational(-1, -6);
            r.Reduce();
            Assert.AreEqual(r.Numerator.Negative, false);
            Assert.AreEqual(r.Denominator.Negative, false);
            Assert.AreEqual(new BigInteger(1),r.Numerator.Number);
            Assert.AreEqual(new BigInteger(6), r.Denominator.Number);
            r = new Rational(3, 6);
            r.Reduce();
            Assert.AreEqual(r.Numerator.Negative, false);
            Assert.AreEqual(r.Denominator.Negative, false);
            Assert.AreEqual(new BigInteger(1), r.Numerator.Number);
            Assert.AreEqual(new BigInteger(2), r.Denominator.Number);
            r = new Rational(1, -6);
            r.Reduce();
            Assert.AreEqual(r.Numerator.Negative, true);
            Assert.AreEqual(r.Denominator.Negative, false);
            Assert.AreEqual(new BigInteger(1), r.Numerator.Number);
            Assert.AreEqual(new BigInteger(6), r.Denominator.Number);
        }
        [Test]
        public void EvaluateTest()
        {
            Rational e = new Rational(1, 2);
            Assert.AreEqual(0.5, e.Evaluate());
            e = new Rational(1, 3);
            Assert.AreEqual(Math.Round(1.0 / 3.0,4), Math.Round(e.Evaluate(),4));
            Console.WriteLine(e.Evaluate());
            e = new Rational(3, 2);
            Assert.AreEqual(1.5, e.Evaluate());
            e = new Rational(-3, 2);
            Assert.AreEqual(-1.5, e.Evaluate());
            
        }
    }
}
