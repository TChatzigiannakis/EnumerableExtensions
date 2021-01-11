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
    class EveryOtherAfterFirst
    {
        [Test]
        public void EveryOtherAfterFirstSimple()
        {
            var seq = new[] { 1, 2, 3, 4, 5 }.EveryOtherAfterFirst().ToArray();

            Assert.AreEqual(2, seq[0]);
            Assert.AreEqual(4, seq[1]);
        }
    }
}
