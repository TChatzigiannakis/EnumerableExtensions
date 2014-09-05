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
    class Distinct
    {
        [Test]
        public void DistinctPredicate()
        {
            var seq = new[] {1, 2, -1, 3, -2, -3}.Distinct((x, y) => Math.Abs(x) == Math.Abs(y)).ToArray();

            Assert.AreEqual(3, seq.Count());
            Assert.AreEqual(1, seq[0]);
            Assert.AreEqual(2, seq[1]);
            Assert.AreEqual(3, seq[2]);
        }
    }
}
