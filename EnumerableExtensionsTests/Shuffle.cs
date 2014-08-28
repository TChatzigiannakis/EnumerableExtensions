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
    class Shuffle
    {
        [Test]
        public void ShuffleIntegers()
        {
            var seq = new[] {1, 2, 3, 4, 5};
            var sum = seq.Sum();

            for (var i = 0; i < 20; i++)
            {
                Assert.AreEqual(sum, seq.Shuffle().Sum());
                Assert.IsTrue(seq.Shuffle().IsPermutationOf(seq));
            }
        }
    }
}
