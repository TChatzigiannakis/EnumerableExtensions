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
    class SequenceEqual
    {
        [Test]
        public void SequenceEqualIntegers()
        {
            var seq1 = new[] { 1, 2, 3, 4, 5 };
            var seq2 = seq1.Select(x => x * x);

            Assert.IsTrue(seq1.SequenceEqual(seq2, (x, y) => x * x == y));
        }
    }
}
