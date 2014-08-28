/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * Copyright (C) 2014  Theodoros Chatzigiannakis
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EnumerableExtensions;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class Around
    {
        [Test]
        public void AroundSimple()
        {
            var seq = new[] {1, 2, 3, 4, 5};
            var aroundOne = seq.Around(x => x == 1).ToArray();
            var aroundTwo = seq.Around(x => x == 2).ToArray();
            var aroundFive = seq.Around(x => x == 5).ToArray();

            Assert.AreEqual(0, aroundOne[0]);
            Assert.AreEqual(1, aroundOne[1]);
            Assert.AreEqual(2, aroundOne[2]);

            Assert.AreEqual(1, aroundTwo[0]);
            Assert.AreEqual(2, aroundTwo[1]);
            Assert.AreEqual(3, aroundTwo[2]);

            Assert.AreEqual(4, aroundFive[0]);
            Assert.AreEqual(5, aroundFive[1]);
            Assert.AreEqual(0, aroundFive[2]);
        }
    }
}
