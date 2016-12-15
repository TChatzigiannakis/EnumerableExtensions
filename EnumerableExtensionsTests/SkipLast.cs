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
using EnumerableExtensions;
using NUnit.Framework;

namespace EnumerableExtensionsTests
{
    [TestFixture]
    class SkipLast
    {
        [Test]
        public void SkipLastSimple()
        {
            var data = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var skipped = data.SkipLast(3).ToArray();
            var skippedTooMany = data.SkipLast(15).ToArray();

            Assert.IsTrue(skipped.SequenceEqual(new[] {1, 2, 3, 4, 5, 6}));
            Assert.IsFalse(skippedTooMany.Any());
        }

	    [Test]
	    public void SkipLastNull()
	    {
		    Assert.Throws<ArgumentNullException>(() => { ((IEnumerable<int>) null).SkipLast(3); });
	    }
    }
}
