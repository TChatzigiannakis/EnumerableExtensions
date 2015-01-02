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
    class AccumulateAtLeast
    {
        [Test]
        public void AccumulateIntegers()
        {
            var seq = new[] {1, 2, 3, 4, 5};

            Assert.AreEqual(3, seq.AccumulateAtLeast(6, x => x).Count());
            Assert.AreEqual(4, seq.AccumulateAtLeast(7, x => x).Count());
        }

        [Test]
        public void AccumulateFloats()
        {
            var seq = new[] {0.1f, 0.2f, 0.3f, 0.4f, 0.5f};

            Assert.AreEqual(2, seq.AccumulateAtLeast(0.3f, x => x).Count());
        }

        [Test]
        public void AccumulateDoubles()
        {
            var seq = new[] {0.1, 0.2, 0.3, 0.4, 0.5};

            Assert.AreEqual(2, seq.AccumulateAtLeast(0.3, x => x).Count());
        }

        [Test]
        public void AccumulateDecimals()
        {
            var seq = new[] {0.1m, 0.2m, 0.3m, 0.4m, 0.5m};

            Assert.AreEqual(2, seq.AccumulateAtLeast(0.3m, x => x).Count());
            Assert.AreEqual(2, seq.AccumulateAtLeast(0.6m, x => 2 * x).Count());
        }

        [Test]
        public void AccumulateBytes()
        {
            var seq = new byte[] {1, 2, 3, 4, 5};

            Assert.AreEqual(2, seq.AccumulateAtLeast((byte)3, x => x).Count());
            Assert.AreEqual(2, seq.AccumulateAtLeast(3, x => x).Count());
        }

        [Test]
        public void AccumulateIntegersGeneric()
        {
            var seq = new[] {1, 2, 3, 4, 5};

            Assert.AreEqual(3, seq.AccumulateAtLeast<int, int>(6, x => x).Count());
            Assert.AreEqual(4, seq.AccumulateAtLeast<int, int>(7, x => x).Count());
        }

        [Test]
        public void AccumulateGeneric()
        {
            var seq = new decimal[] { 1, 2, 3, 4, 5 };

            Assert.AreEqual(3, seq.AccumulateAtLeast<decimal, decimal>(6, x => x).Count());
            Assert.AreEqual(4, seq.AccumulateAtLeast<decimal, decimal>(7, x => x).Count());
        }
    }
}
