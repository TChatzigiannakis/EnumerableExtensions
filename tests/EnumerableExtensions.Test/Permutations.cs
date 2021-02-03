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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EnumerableExtensions;
    using NUnit.Framework;

    [TestFixture]
    class Permutations
    {
        [Test]
        public void PermutationsSimple()
        {
            var original = new[] { 1, 2, 3, 4, 4 };
            var permutations = original.Permutations().ToList();

            Assert.AreEqual(1 * 2 * 3 * 4 * 5, permutations.Count);
            Assert.IsTrue(original.SequenceEqual(permutations.First()));
            Assert.IsTrue(original.Reverse().SequenceEqual(permutations.Last()));
        }

        [Test]
        public void PermutationsEmpty()
        {
            var perms = new int[] { }.Permutations();
            Assert.AreEqual(1, perms.Count());
        }

        [Test]
        public void PermutationsNull() => Assert.Throws<ArgumentNullException>(() => { ((IEnumerable<int>)null).Permutations(); });
    }
}
