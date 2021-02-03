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
    class MoreThanOne
    {
        [Test]
        public void MoreThanOneIntegers()
        {
            Assert.IsTrue(new[] { 1, 2, 3, 4, 5 }.MoreThanOne());
            Assert.IsFalse(new[] { 1 }.MoreThanOne());
            Assert.IsFalse(new int[0].MoreThanOne());
        }
    }
}
