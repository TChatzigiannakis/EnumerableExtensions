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
    class OnlyOne
    {
        [Test]
        public void OnlyOneInteger()
        {
            Assert.IsTrue(new int[1].OnlyOne());
            Assert.IsFalse(new int[0].OnlyOne());
            Assert.IsFalse(new int[2].OnlyOne());
        }
    }
}
