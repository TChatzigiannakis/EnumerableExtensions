/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

namespace EnumerableExtensionsTests
{
    using System.Linq;
    using EnumerableExtensions;
    using NUnit.Framework;

    [TestFixture]
    public class Except
    {
        [Test]
        public void ExceptSingleElement()
        {
            var seq = new[] { 1, 2, 3, 4, 5 };
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
