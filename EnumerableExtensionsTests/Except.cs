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
    public class Except
    {
        [Test]
        public void ExceptSingleElement()
        {
            var seq = new[] {1, 2, 3, 4, 5};
            var filtered = seq.Except(2).ToArray();

            Assert.AreEqual(1, filtered[0]);
            Assert.AreEqual(3, filtered[1]);
            Assert.AreEqual(4, filtered[2]);
            Assert.AreEqual(5, filtered[3]);

            var empty = new int[0];
            var filteredEmpty = empty.Except(5).ToArray();

            Assert.AreEqual(0, filteredEmpty.Count());
        }

        [Test]
        public void ExceptByPredicate()
        {
            var seq = new[] { 1, 2, 3, 4, 5 };
            var filtered = seq.Except(x => x < 3).ToArray();

            Assert.AreEqual(3, filtered[0]);
            Assert.AreEqual(4, filtered[1]);
            Assert.AreEqual(5, filtered[2]);

            var empty = new int[0];
            var filteredEmpty = empty.Except(x => x > 3).ToArray();

            Assert.AreEqual(0, filteredEmpty.Count());
        }
    }
}
