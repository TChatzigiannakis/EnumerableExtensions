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
    class ButFirst
    {
        [Test]
        public void ButFirstSimple()
        {
            var seq = new[] { 1, 2, 3, 4, 5 };

            Assert.AreEqual(4, seq.ButFirst().Count());
            Assert.AreEqual(2, seq.ButFirst().First());
            Assert.AreEqual(0, new int[0].ButFirst().Count());
        }
    }
}
