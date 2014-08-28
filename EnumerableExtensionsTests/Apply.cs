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
    class Apply
    {
        [Test]
        public void ApplyToAll()
        {
            var seq = new[] {"a", "b", "c", "d", "e"};
            var str = "";
            seq.Apply(x => str += x).ToAll();

            Assert.AreEqual("abcde", str);
        }

        [Test]
        public void ApplyToExceptLast()
        {
            var seq = new[] { "a", "b", "c", "d", "e" };
            var str = "";
            seq.Apply(x => str += x).ToAllExceptLast();

            Assert.AreEqual("abcd", str);
        }

        [Test]
        public void ApplyToAllAndThenApplyToLast()
        {
            var seq = new[] { "a", "b", "c", "d", "e" };
            var str = "";
            seq.Apply(x => str += x).ToAllAndThenApplyToLast(x => str += x);

            Assert.AreEqual("abcdee", str);
        }

        [Test]
        public void ApplyToAllWithDifferentLast()
        {
            var seq = new[] { "a", "b", "c", "d", "e" };
            var str = "";
            seq.Apply(x => str += x).ToAllWithDifferentLast(x => str += " " + x);

            Assert.AreEqual("abcd e", str);
        }
    }
}
