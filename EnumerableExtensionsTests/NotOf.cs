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
    class NotOf
    {
        [Test]
        public void NotOfType()
        {
            var seq = new object[] {1, 2, 3, "hey", 5.2, 3m };

            Assert.AreEqual(5, seq.NotOf().Type<string>().Count());
            Assert.AreEqual(3, seq.NotOf().Type<int>().Count());
            Assert.AreEqual(5, seq.NotOf().Type<double>().Count());
            Assert.AreEqual(5, seq.NotOf().Type<decimal>().Count());

            Assert.AreEqual(4, seq.NotOf().Type<double, decimal>().Count());
            Assert.AreEqual(2, seq.NotOf().Type<int, string>().Count());
        }

        [Test]
        public void NotOfExactType()
        {
            var seq = new object[] {1, 2, 3, "hey", 5.2, 3m, new[] {1, 2}, new[] {3, 4}};

            Assert.AreEqual(6, seq.NotOf().ExactType<int[]>().Count());
            Assert.AreEqual(5, seq.NotOf().ExactType<int[], string>().Count());
        }

        [Test]
        public void NotOfTypeClassOrStruct()
        {
            var seq = new object[] { 1, 2, 3, "hey", 5.2, 3m, new[] { 1, 2 }, new[] { 3, 4 } };

            Assert.AreEqual(3, seq.NotOf().AnyStructType().Count());
            Assert.AreEqual(5, seq.NotOf().AnyClassType().Count());
        }
    }
}
