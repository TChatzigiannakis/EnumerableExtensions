using System;
using NUnit.Framework;
using System.Linq;
using EnumerableExtensions;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class Consume
    {
        [Test]
        public void ConsumeClosure()
        {
            var i = 0;
            var q = Enumerable.Range (0, 5).Select (x => i += x);
            q.Consume ();
            Assert.AreEqual (10, i);
        }
    }
}

