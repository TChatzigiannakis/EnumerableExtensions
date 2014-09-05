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
    class Cartesian
    {
        [Test]
        public void CartesianSimple()
        {
            var seq1 = new[] {1, 2, 3, 4, 5};
            var seq2 = new[] {1, 2, 3, 4, 5};
            var cartesian = seq1.Cartesian(seq2).ToArray();

            Assert.AreEqual(25, cartesian.Count());
            Assert.AreEqual(1, cartesian[0].Item1);
            Assert.AreEqual(1, cartesian[0].Item2);
            Assert.AreEqual(5, cartesian[23].Item1);
            Assert.AreEqual(5, cartesian[24].Item2);
        }
    }
}
