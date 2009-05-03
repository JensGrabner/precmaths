using System;
using System.Collections.Generic;
using System.Text;
using PrecMaths;
using NUnit.Framework;

namespace FracTests
{
    [TestFixture]
    class TestRunner
    {
        [Test]
        public void FracInitialiseFromInt()
        {
            Rational r = 4;
            Assert.AreEqual(r.Numerator, 4);
            Assert.AreEqual(r.Denominator, 1);
        }
        public void FracInitialiseFromLong()
        {
            Rational r = (long)12388888888888;
            Assert.AreEqual(r.Numerator, (long)12388888888888);
            Assert.AreEqual(r.Denominator, 1);

        }
    }
}
