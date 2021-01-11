/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

namespace EnumerableExtensionsTests
{
    using EnumerableExtensions;
    using NUnit.Framework;

    [TestFixture]
    class Apply
    {
        [Test]
        public void ApplyToAll()
        {
            var seq = new[] { "a", "b", "c", "d", "e" };
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
