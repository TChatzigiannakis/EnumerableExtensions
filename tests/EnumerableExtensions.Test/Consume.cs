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
    class Consume
    {
        [Test]
        public void ConsumeClosure()
        {
            var i = 0;
            var q = Enumerable.Range(0, 5).Select(x => i += x);
            q.Consume();
            Assert.AreEqual(10, i);
        }
    }
}

