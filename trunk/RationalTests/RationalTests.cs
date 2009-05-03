using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using PrecMaths;
using Mono.Math;

namespace RationalTests
{
    [TestFixture]
    public class RationalTests
    {
        [Test]
        public void RationalInitialiseFromInt()
        {
            Rational r = 4;
            Assert.AreEqual(4,r.Numerator);
            Assert.AreEqual(1,r.Denominator);
        }
        [Test]
        public void RationalInitialiseFromLong()
        {
            Rational r = 12888888888888;
            Assert.AreEqual(12888888888888, r.Numerator);
            Assert.AreEqual(1, r.Denominator);
        }
        [Test]
        public void RationalMultiply1()
        {
            Rational r1 = new Rational(1, 4);
            Rational r2 = new Rational(7, 2);
            Rational output = r1 * r2;
            Assert.AreEqual(7, output.Numerator);
            Assert.AreEqual(8, output.Denominator);
        }
        [Test]
        public void RationalMultiply2()
        {
            Rational r1 = new Rational(2, 3);
            Rational output = r1 * 3;
            Assert.AreEqual(2, output.Numerator);
            Assert.AreEqual(1, output.Denominator);
        }
        [Test]
        public void RationalMultiply3()
        {
            Rational r1 = new Rational(7, 19);
            r1 *= 128888888888;
            Assert.AreEqual(7 * 128888888888, r1.Numerator);
            Assert.AreEqual(19, r1.Denominator);
        }
        [Test]
        public void RationalAdd1()
        {
            Rational r1 = new Rational(1, 2);
            r1 += r1;
            Assert.AreEqual(new Rational(1), r1);
        }
        [Test]
        public void RationalAdd2()
        {
            Rational r1 = new Rational(3, 7);
            r1 += 3;
            //3*7+3 = 24
            Assert.AreEqual(24, r1.Numerator);
            Assert.AreEqual(7, r1.Denominator);
        }
        [Test]
        public void RationalAdd3()
        {
            Rational r1 = new Rational(7);
            Rational r2 = new Rational(14);
            r1 += r2;
            Assert.AreEqual(7 + 14, r1.Numerator);
            Assert.AreEqual(1, r1.Denominator);
        }
        [Test]
        public void RationalDivide1()
        {
            Rational r1 = new Rational(1, 3);
            Rational r2 = new Rational(2, 7);
            r1 /= r2;
            Assert.AreEqual(7, r1.Numerator);
            Assert.AreEqual(2 * 3, r1.Denominator);
        }
        [Test]
        public void RationalDivide2()
        {
            Rational r1 = new Rational(1, 7);
            r1 /= 3;
            Assert.AreEqual(1, r1.Numerator);
            Assert.AreEqual(21, r1.Denominator);
        }
        [Test]
        public void RationalDivide3()
        {
            Rational r1 = new Rational(3, 1);
            r1 /= 4L;
            Assert.AreEqual(3, r1.Numerator);
            Assert.AreEqual(4, r1.Denominator);
        }
        [Test]
        public void RationalSubtract1()
        {
            Rational r1 = new Rational(0);
            r1 -= new Rational(1, 2);
            Assert.AreEqual(-1, r1.Numerator);
            Assert.AreEqual(2, r1.Denominator);
        }
        [Test]
        public void RationalSubtract2()
        {
            Rational r1 = new Rational(1);
            r1 -= 1;
            Assert.AreEqual(0, r1.Numerator);
            Assert.AreEqual(1, r1.Denominator);
        }
        [Test]
        public void RationalSubtract3()
        {
            Rational r1 = new Rational(4L);
            r1 -= -1L;
            Assert.AreEqual(5, r1.Numerator);
            Assert.AreEqual(1, r1.Denominator);
        }
        [Test]
        public void RationalReduce()
        {
            Rational r1 = new Rational(2, 2);
            r1.Reduce();
            Assert.AreEqual(1, r1.Numerator);
            Assert.AreEqual(1, r1.Denominator);
            r1 = new Rational(3, 9);
            r1.Reduce();
            Assert.AreEqual(1, r1.Numerator);
            Assert.AreEqual(3, r1.Denominator);

            
        }
        [Test]
        public void RationalIntCompare()
        {
            Assert.That(1 == new Rational(1));
            Assert.That(1L == new Rational(1));
            Assert.That(3L == new Rational(3, 1));
            Assert.That(5 == new Rational(5));
            Assert.That(4 < new Rational(5));
            Assert.That(6 > new Rational(5));

        }
        [Test]
        public void RationalLongCompare()
        {
            Rational r1 = new Rational(5);
            Assert.That(r1 == 5L);
            Assert.That(r1 > 4L);
            Assert.That(r1 < 6L); 

        }
        [Test]
        public void RationalEvaluate()
        {
            Assert.AreEqual(1.0 / 7.0, new Rational(1, 7).Evaluate());
        }
        [Test]
        public void RationalErrors()
        {
            Assert.Throws<InvalidOperationException>(new TestDelegate(InitialiseZeroDenominator));
            Assert.Throws<InvalidOperationException>(new TestDelegate(InitialseZeroLongDenominator));
            Assert.Throws<InvalidOperationException>(new TestDelegate(DivideByZero));

        }
        public void DivideByZero()
        {
            Rational r = new Rational(4);
            r /= 0;
        }
        public void InitialiseZeroDenominator()
        {
            Rational r = new Rational(1, 0);
        }
        public void InitialseZeroLongDenominator()
        {
            Rational r = new Rational(1L, 0L);
        }
    }
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
            e = e / 6;
            Assert.AreEqual(false, e.Negative);
            Assert.AreEqual(new BigInteger(4), e.Number);
            e = new SignedBigInteger(24);
            e = e / -8;
            Assert.AreEqual(true, e.Negative);
            Assert.AreEqual(new BigInteger(3), e.Number);
        }
    }
}
