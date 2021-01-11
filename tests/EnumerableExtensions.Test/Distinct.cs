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
    class Distinct
    {
        [Test]
        public void DistinctPredicate()
        {
            var seq = new[] { 1, 2, -1, 3, -2, -3 }.Distinct((x, y) => Math.Abs(x) == Math.Abs(y)).ToArray();

            Assert.AreEqual(3, seq.Count());
            Assert.AreEqual(1, seq[0]);
            Assert.AreEqual(2, seq[1]);
            Assert.AreEqual(3, seq[2]);
        }

        [Test]
        public void DistinctNull()
        {
            Assert.Throws<ArgumentNullException>(() => { ((IEnumerable<int>)null).Distinct((x, y) => Math.Abs(x) == Math.Abs(y)); });
            Assert.Throws<ArgumentNullException>(() => { new[] { 1, 2, -1, 3, -2, -3 }.Distinct((Func<int, int, bool>)null); });
        }
    }
}
