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
    class Union
    {
        [Test]
        public void UnionIntegers()
        {
            var seq = new[] { 1, 2, 3 }.Union(4).ToArray();

            Assert.AreEqual(4, seq.Count());
            Assert.AreEqual(1, seq[0]);
            Assert.AreEqual(2, seq[1]);
            Assert.AreEqual(3, seq[2]);
            Assert.AreEqual(4, seq[3]);
        }
    }
}
