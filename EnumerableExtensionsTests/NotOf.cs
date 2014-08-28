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
            var seq = new object[] {1, 2, 3, "hey", 5.2, 3m};

            Assert.AreEqual(5, seq.NotOf().Type<string>().Count());
            Assert.AreEqual(3, seq.NotOf().Type<int>().Count());
            Assert.AreEqual(5, seq.NotOf().Type<double>().Count());
            Assert.AreEqual(5, seq.NotOf().Type<decimal>().Count());
        }
    }
}
