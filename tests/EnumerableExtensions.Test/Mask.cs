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
    class Mask
    {
        [Test]
        public void MaskIntegers()
        {
            var seq = new[] { 1, 2, 3, 4, 5 }.Mask(x => x < 3).ToArray();

            Assert.AreEqual(5, seq.Count());
            Assert.AreEqual(1, seq[0]);
            Assert.AreEqual(2, seq[1]);
            Assert.AreEqual(0, seq[2]);
            Assert.AreEqual(0, seq[3]);
            Assert.AreEqual(0, seq[4]);
        }

        [Test]
        public void MaskNull()
        {
            Assert.Throws<ArgumentNullException>(() => { ((IEnumerable<int>)null).Mask(x => x < 3); });
            Assert.Throws<ArgumentNullException>(() => { new[] { 1, 2, 3, 4, 5 }.Mask((Func<int, bool>)null); });
        }
    }
}
