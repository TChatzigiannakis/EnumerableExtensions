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
    using EnumerableExtensions;
    using NUnit.Framework;

    [TestFixture]
    class AllEqual
    {
        [Test]
        public void AllEqualSimple()
        {
            var seq1 = new[] { 1, 2, 3, 4, 5 };
            var seq2 = new[] { 1, 1, 1, 1, 1 };

            Assert.IsFalse(seq1.AllEqual());
            Assert.IsTrue(seq2.AllEqual());
        }
    }
}
