using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumerableExtensions;
using NUnit.Framework;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class SkipLast
    {
        [Test]
        public void SkipLastSimple()
        {
            var data = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var skipped = data.SkipLast(3).ToArray();
            var skippedTooMany = data.SkipLast(15).ToArray();

            Assert.IsTrue(skipped.SequenceEqual(new[] {1, 2, 3, 4, 5, 6}));
            Assert.IsFalse(skippedTooMany.Any());
        }
    }
}
