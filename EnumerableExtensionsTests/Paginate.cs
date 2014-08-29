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
    class Paginate
    {
        [Test]
        public void PaginateIntegers()
        {
            var seq = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}.Paginate(3, 3).ToArray();

            Assert.AreEqual(3, seq.Count());
            Assert.AreEqual(4, seq[0]);
            Assert.AreEqual(5, seq[1]);
            Assert.AreEqual(6, seq[2]);
        }

        [Test]
        public void PaginateNestedWithRemainder()
        {
            var seq = new[] {1, 2, 3, 4, 5, 6, 7}.Paginate(3).ToArray();

            Assert.AreEqual(3, seq.Count());

            Assert.AreEqual(3, seq[0].Count());
            Assert.AreEqual(1, seq[0].ElementAt(0));
            Assert.AreEqual(2, seq[0].ElementAt(1));
            Assert.AreEqual(3, seq[0].ElementAt(2));

            Assert.AreEqual(3, seq[1].Count());
            Assert.AreEqual(4, seq[1].ElementAt(0));
            Assert.AreEqual(5, seq[1].ElementAt(1));
            Assert.AreEqual(6, seq[1].ElementAt(2));

            Assert.AreEqual(1, seq[2].Count());
            Assert.AreEqual(7, seq[2].ElementAt(0));
        }

        [Test]
        public void PaginateNestedWithoutRemainder()
        {
            var seq = new[] {1, 2, 3, 4, 5, 6}.Paginate(3).ToArray();

            Assert.AreEqual(2, seq.Count());

            Assert.AreEqual(3, seq[0].Count());
            Assert.AreEqual(1, seq[0].ElementAt(0));
            Assert.AreEqual(2, seq[0].ElementAt(1));
            Assert.AreEqual(3, seq[0].ElementAt(2));

            Assert.AreEqual(3, seq[1].Count());
            Assert.AreEqual(4, seq[1].ElementAt(0));
            Assert.AreEqual(5, seq[1].ElementAt(1));
            Assert.AreEqual(6, seq[1].ElementAt(2));
        }
    }
}
