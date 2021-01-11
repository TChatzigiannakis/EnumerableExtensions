/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
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
    class EveryOther
    {
        [Test]
        public void EveryOtherSimple()
        {
            var seq = new[] {1, 2, 3, 4, 5}.EveryOther().ToArray();

            Assert.AreEqual(1, seq[0]);
            Assert.AreEqual(3, seq[1]);
            Assert.AreEqual(5, seq[2]);
        }
    }
}
