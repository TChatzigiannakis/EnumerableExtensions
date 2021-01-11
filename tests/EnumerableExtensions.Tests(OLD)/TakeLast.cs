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
using EnumerableExtensions;
using NUnit.Framework;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class TakeLast
    {
        [Test]
        public void TakeLastSimple()
        {
            var data = new[] {1, 2, 3, 4, 5};
            
            var lastThree = data.TakeLast(3).ToArray();
            Assert.IsTrue(lastThree.SequenceEqual(new[] {3, 4, 5}));

            var lastSix = data.TakeLast(6).ToArray();
            Assert.IsTrue(lastSix.SequenceEqual(data));
        }
    }
}
