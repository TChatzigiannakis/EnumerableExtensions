using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EnumerableExtensions;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class AccumulateAtLeast
    {
        [Test]
        public void Integers()
        {
            var seq = new[] {1, 2, 3, 4, 5};

            Assert.AreEqual(3, seq.AccumulateAtLeast(6, x => x).Count());
            Assert.AreEqual(4, seq.AccumulateAtLeast(7, x => x).Count());
        }

        [Test]
        public void GenericInt()
        {
            var seq = new[] {1, 2, 3, 4, 5};

            Assert.AreEqual(3, seq.AccumulateAtLeast<int, int>(6, x => x).Count());
            Assert.AreEqual(4, seq.AccumulateAtLeast<int, int>(7, x => x).Count());
        }

        [Test]
        public void GenericGeneral()
        {
            var seq = new decimal[] { 1, 2, 3, 4, 5 };

            Assert.AreEqual(3, seq.AccumulateAtLeast<decimal, decimal>(6, x => x).Count());
            Assert.AreEqual(4, seq.AccumulateAtLeast<decimal, decimal>(7, x => x).Count());
        }
    }
}
