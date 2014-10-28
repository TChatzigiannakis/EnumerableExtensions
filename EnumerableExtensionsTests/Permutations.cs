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
    class Permutations
    {
        [Test]
        public void PermutationsSimple()
        {
            var original = new[] {1, 2, 3, 4, 4};
            var permutations = original.Permutations().ToList();

            Assert.AreEqual(1 * 2 * 3 * 4 * 5, permutations.Count);
            Assert.IsTrue(original.SequenceEqual(permutations.First()));
            Assert.IsTrue(original.Reverse().SequenceEqual(permutations.Last()));
        }

        [Test]
        public void PermutationsEmpty()
        {
            var perms = new int[] {}.Permutations();
            Assert.AreEqual(1, perms.Count());
        }
    }
}
