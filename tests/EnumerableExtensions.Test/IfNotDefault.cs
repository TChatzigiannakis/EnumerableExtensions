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
    class IfNotDefault
    {
        [Test]
        public void IfNotDefaultSimple()
        {
            var obj = new object();
            var t = false;
            obj.IfNotDefault(x => t = true);
            object n = null;

            Assert.IsTrue(t);

            n.IfNotDefault(x => Assert.Fail());
        }
    }
}
