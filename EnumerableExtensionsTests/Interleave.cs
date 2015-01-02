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
    class Interleave
    {
        [Test]
        public void InterleaveMinimum()
        {
            var seq1 = new[] {1, 2, 3, 4, 5, 6, 7};
            var seq2 = new[] {-1, -2, -3, -4, -5};
            var interleaving = seq1.Interleave(seq2).Minimum().ToArray();

            Assert.AreEqual(10, interleaving.Count());
            Assert.AreEqual(1, interleaving[0]);
            Assert.AreEqual(-1, interleaving[1]);
            Assert.AreEqual(5, interleaving[8]);
            Assert.AreEqual(-5, interleaving[9]);
        }

        [Test]
        public void InterleavePadMaximum()
        {
            var seq1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var seq2 = new[] { -1, -2, -3, -4, -5 };
            var interleaving = seq1.Interleave(seq2).PadMaximum().ToArray();

            Assert.AreEqual(14, interleaving.Count());
            Assert.AreEqual(1, interleaving[0]);
            Assert.AreEqual(-1, interleaving[1]);
            Assert.AreEqual(6, interleaving[10]);
            Assert.AreEqual(0, interleaving[11]);
            Assert.AreEqual(7, interleaving[12]);
            Assert.AreEqual(0, interleaving[13]);
        }

        [Test]
        public void InterleaveAndAddRest()
        {
            var seq1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var seq2 = new[] { -1, -2, -3, -4, -5 };
            var interleaving = seq1.Interleave(seq2).AndAddRest().ToArray();
            
            Assert.AreEqual(12, interleaving.Count());
            Assert.AreEqual(1, interleaving[0]);
            Assert.AreEqual(-1, interleaving[1]);
            Assert.AreEqual(6, interleaving[10]);
            Assert.AreEqual(7, interleaving[11]);
        }
    }
}
