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
    class Flatten
    {
        [Test]
        public void FlattenSimple()
        {
            var s1 = new[] { 1, 2, 3, 4, 5 };
            var s2 = new[] { 6, 7, 8, 9, 10 };
            var s3 = new[] { 11, 12, 13, 14, 15 };
            var nested = new[] { s1, s2, s3 };
            var flat = nested.Flatten();
            var match = Enumerable.Range(1, 15);

            Assert.IsTrue(flat.SequenceEqual(match));
        }
    }
}
