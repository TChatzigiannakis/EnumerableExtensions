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
    class ForEach
    {
        [Test]
        public void ForEachSimple()
        {
            var str = "";
            new[] {"a", "b", "c", "d", "e"}.ForEach(x => str += x);

            Assert.AreEqual("abcde", str);

            var str2 = "";
            new string[0].ForEach(x => str2 += x);

            Assert.AreEqual("", str2);
        }
    }
}
