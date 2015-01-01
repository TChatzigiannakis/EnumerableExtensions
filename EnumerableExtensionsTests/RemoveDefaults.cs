using System;
using EnumerableExtensions;
using NUnit.Framework;
using System.Linq;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class RemoveDefaults
    {
        [Test]
        public void RemoveDefaultsSimple ()
        {
            var q1 = new[] { 0, 1, 2, 5, 0, 3, 4 }.RemoveDefaults ();
            var q2 = new[] { "a", "b", null, null, "c" }.RemoveDefaults ();
            Assert.AreEqual (5, q1.Count ());
            Assert.AreEqual (3, q2.Count ());
        }

        [Test]
        public void RemoveIndividualDefaults()
        {
            var arr = new object[] { 0, 1, "2", null, "3", 0.0f, 0.0m };
            var q1 = arr.RemoveDefaults ();
            var q2 = arr.RemoveIndividualDefaults ();
            Assert.AreEqual (6, q1.Count ());
            Assert.AreEqual (3, q2.Count ());
        }
    }
}

