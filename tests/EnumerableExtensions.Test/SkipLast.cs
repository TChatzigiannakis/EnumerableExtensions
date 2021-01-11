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
    using System.Linq;
    using EnumerableExtensions;
    using NUnit.Framework;

    [TestFixture]
    class SkipLast
    {
        [Test]
        public void SkipLastSimple()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var skipped = data.SkipLast(3);
            var skippedTooMany = data.SkipLast(15);

            Assert.IsTrue(skipped.SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
            Assert.IsFalse(skippedTooMany.Any());
        }

        [Test]
        public void SkipLastNull() => Assert.Throws<ArgumentNullException>(() => { ((System.Collections.Generic.IEnumerable<int>)null).SkipLast(3); });
    }
}
