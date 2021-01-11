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
    class IsPermutationOf
    {
        [Test]
        public void IsPermutationOfIntegers()
        {
            var seq1 = new[] {1, 2, 3, 4, 5};
            var seq2 = new[] {1, 2, 3, 4};
            var seq3 = new[] {3, 1, 2, 5, 4};
            var seq4 = new[] {5, 4, 3, 2, 1, 1};

            Assert.IsTrue(seq1.IsPermutationOf(seq3));
            Assert.IsTrue(seq3.IsPermutationOf(seq1));

            Assert.IsFalse(seq1.IsPermutationOf(seq2));
            Assert.IsFalse(seq2.IsPermutationOf(seq1));

            Assert.IsFalse(seq1.IsPermutationOf(seq4));
            Assert.IsFalse(seq4.IsPermutationOf(seq1));
        }

        [Test]
        public void IsPermutationOfStrings()
        {
            var seq1 = new[] {"A", "B", "C", "D"};
            var seq2 = new[] {"A", "C", "D", "B"};
            var seq3 = new[] {"A", "B", "D"};
            var seq4 = new[] {"A", "B", "D", "E"};

            Assert.IsTrue(seq1.IsPermutationOf(seq2));
            Assert.IsTrue(seq2.IsPermutationOf(seq1));
            
            Assert.IsFalse(seq1.IsPermutationOf(seq3));
            Assert.IsFalse(seq3.IsPermutationOf(seq1));
            
            Assert.IsFalse(seq1.IsPermutationOf(seq4));
            Assert.IsFalse(seq4.IsPermutationOf(seq1));

            Assert.IsFalse(seq3.IsPermutationOf(seq4));
            Assert.IsFalse(seq4.IsPermutationOf(seq3));
        }
    }
}
