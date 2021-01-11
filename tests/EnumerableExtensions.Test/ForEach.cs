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
    class ForEach
    {
        [Test]
        public void ForEachSimple()
        {
            var str = "";
            new[] { "a", "b", "c", "d", "e" }.ForEach(x => str += x);

            Assert.AreEqual("abcde", str);

            var str2 = "";
            new string[0].ForEach(x => str2 += x);

            Assert.AreEqual("", str2);
        }
    }
}
