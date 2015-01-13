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
    class DistinctAdjacent
    {
        [Test]
        public void DistinctAdjacentSimple()
        {
            var data = new[] {0, 1, 1, 1, 2, 2, 2, 2, 3, 4, 4, 4, 2, 5, 5};
            var distinctAdj = data.DistinctAdjacent().ToArray();

            Assert.IsTrue(distinctAdj.SequenceEqual(new[] {0, 1, 2, 3, 4, 2, 5}));
        }
    }
}
