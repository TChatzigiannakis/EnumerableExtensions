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
    class FirstOrEmpty
    {
        [Test]
        public void FirstOrEmptySimple()
        {
            var seq1 = new[] {1, 2, 3, 4, 5}.FirstOrEmpty().ToArray();
            var seq2 = new int[0].FirstOrEmpty().ToArray();

            Assert.AreEqual(1, seq1.Count());
            Assert.AreEqual(1, seq1.First());
            Assert.AreEqual(0, seq2.Count());
        }
    }
}
