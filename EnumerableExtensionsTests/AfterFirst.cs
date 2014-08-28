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
    class AfterFirst
    {
        [Test]
        public void AfterFirstSimple()
        {
            var seq = new[] {1, 2, 3, 4, 5};

            Assert.AreEqual(2, seq.AfterFirst(x => x == 3).Count());
            Assert.AreEqual(0, seq.AfterFirst(x => x == 5).Count());
            Assert.AreEqual(0, seq.AfterFirst(x => x == 6).Count());
        }

        [Test]
        public void AfterFirstEmpty()
        {
            var seq = new int[0];

            Assert.AreEqual(0, seq.AfterFirst(x => x > 2).Count());
        }
    }
}
