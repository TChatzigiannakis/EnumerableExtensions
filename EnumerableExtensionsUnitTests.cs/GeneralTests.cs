using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnumerableExtensions;
using System.Linq;

namespace EnumerableExtensionsUnitTests.cs
{
    [TestClass]
    public class GeneralTests
    {
        private int[] data1 = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
        private int[] data2 = {5, 5, 5, 5};
        private object[] data3 = {10, 325, "Hello", 'N', 3.2m, 48.0};

        private int[] data4 = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private int[] data5 = { 2, 4, 6, 8, 10, 12, 14, 16 };
        private int[] data6 = { 2, 4, 6, 8 };
        private int[] data7 = { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
        private int[] data8 = { };

        private object[] data9 = { };

        private int[] data10 = { 1, 4, 16, 9, 36, 25, 64, 49, 81, 100};
        private int[] data11 = { 1, 4, 16};

        [TestMethod]
        public void Around()
        {
            var around = data1.Around(x => x == 16).ToList();
            Assert.AreEqual(9, around[0]);
            Assert.AreEqual(16, around[1]);
            Assert.AreEqual(25, around[2]);
        }

        [TestMethod]
        public void AroundFirst()
        {
            var around = data1.Around(x => x == 1).ToList();
            Assert.AreEqual(0, around[0]);
            Assert.AreEqual(1, around[1]);
            Assert.AreEqual(4, around[2]);
        }

        [TestMethod]
        public void AroundLast()
        {
            var around = data1.Around(x => x == 100).ToList();
            Assert.AreEqual(81, around[0]);
            Assert.AreEqual(100, around[1]);
            Assert.AreEqual(0, around[2]);
        }

        [TestMethod]
        public void Second()
        {
            var second = data1.Second();
            Assert.AreEqual(4, second);
        }

        [TestMethod]
        public void SecondWithPredicate()
        {
            var second = data1.Second(x => x >= 9);
            Assert.AreEqual(16, second);
        }

        [TestMethod]
        public void TakeUntilFirst()
        {
            var results = data1.TakeUntilFirst(x => x == 9);
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void TakeAfterFirst()
        {
            var results = data1.TakeAfterFirst(x => x == 81);
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void PreviousOf()
        {
            var previous = data1.PreviousOf(x => x == 36);
            Assert.AreEqual(25, previous);
        }

        [TestMethod]
        public void PreviousOfFirst()
        {
            var previous = data1.PreviousOf(x => x == 1);
            Assert.AreEqual(0, previous);
        }

        [TestMethod]
        public void PreviousOfLast()
        {
            var previous = data1.PreviousOf(x => x == 100);
            Assert.AreEqual(81, previous);
        }

        [TestMethod]
        public void NextOf()
        {
            var next = data1.NextOf(x => x == 36);
            Assert.AreEqual(49, next);
        }

        [TestMethod]
        public void NextOfFirst()
        {
            var next = data1.NextOf(x => x == 1);
            Assert.AreEqual(4, next);
        }

        [TestMethod]
        public void NextOfLast()
        {
            var next = data1.NextOf(x => x == 100);
            Assert.AreEqual(0, next);
        }

        [TestMethod]
        public void Pagination()
        {
            var paginated = data1.Paginate(3, 3).ToList();
            Assert.AreEqual(16, paginated[0]);
            Assert.AreEqual(25, paginated[1]);
            Assert.AreEqual(36, paginated[2]);
        }

        [TestMethod]
        public void PaginationAtBeginning()
        {
            var paginated = data1.Paginate(0, 3).ToList();
            Assert.AreEqual(1, paginated[0]);
            Assert.AreEqual(4, paginated[1]);
            Assert.AreEqual(9, paginated[2]);
        }

        [TestMethod]
        public void PaginationAtEnd()
        {
            var paginated = data1.Paginate(7, 3).ToList();
            Assert.AreEqual(64, paginated[0]);
            Assert.AreEqual(81, paginated[1]);
            Assert.AreEqual(100, paginated[2]);
        }

        [TestMethod]
        public void PaginationBeyondEnd()
        {
            var paginated = data1.Paginate(7, 4).ToList();
            Assert.AreEqual(64, paginated[0]);
            Assert.AreEqual(81, paginated[1]);
            Assert.AreEqual(100, paginated[2]);
            Assert.AreEqual(3, paginated.Count);
        }

        [TestMethod]
        public void ForEach()
        {
            var sum = 0;
            data1.ForEach(x => sum += x);
            Assert.AreEqual(385, sum);
        }

        [TestMethod]
        public void ForEachWithDifferentLast()
        {
            var sum = 0;
            data1.ForEachWithDifferentLast(x => sum += x, x => sum *= x);
            Assert.AreEqual(28500, sum);
        }

        [TestMethod]
        public void ForEachAndAlsoForLast()
        {
            var sum = 0;
            data1.ForEachAndAlsoForLast(x => sum += x, x => sum -= x);
            Assert.AreEqual(285, sum);

            data9.ForEachAndAlsoForLast(x => x.Equals(x), x => x.Equals(x));
        }

        [TestMethod]
        public void ForEachButExceptForLast()
        {
            var sum = 0;
            data1.ForEachButExceptForLast(x => sum += x, x => sum += x);
            Assert.AreEqual(385*2 - 100, sum);

            data9.ForEachButExceptForLast(x => x.Equals(x), x => x.Equals(x));
        }

        [TestMethod]
        public void OnlyOne()
        {
            var one = data1.Where(x => x == 64).OnlyOne();
            Assert.AreEqual(true, one);
        }

        [TestMethod]
        public void MoreThanOne()
        {
            var many = data1.Where(x => x > 64).MoreThanOne();
            Assert.AreEqual(true, many);            
            var none = data1.Where(x => x > 100).MoreThanOne();
            Assert.AreEqual(false, none);
            var one = data1.Where(x => x == 100).MoreThanOne();
            Assert.AreEqual(false, one);
        }

        [TestMethod]
        public void Except()
        {
            var sumWithout64 = data1.Except(64).Sum();
            Assert.AreEqual(321, sumWithout64);
        }

        [TestMethod]
        public void AllEqual()
        {
            var eq1 = data1.AllEqual();
            var eq2 = data2.AllEqual();
            Assert.AreEqual(false, eq1);
            Assert.AreEqual(true, eq2);
        }

        [TestMethod]
        public void ButFirst()
        {
            var butFirst = data1.ButFirst();
            Assert.AreEqual(4, butFirst.First());
            Assert.AreEqual(9, butFirst.Count());
        }

        [TestMethod]
        public void ButLast()
        {
            var butLast = data1.ButLast();
            Assert.AreEqual(81, butLast.Last());
            Assert.AreEqual(9, butLast.Count());
        }

        [TestMethod]
        public void FirstIfAny()
        {
            data1.FirstIfAny(x => x == 5).ForEach(x => Assert.Fail());
            Assert.AreEqual(0, data1.FirstIfAny(x => x == 5).Count());
            Assert.AreEqual(1, data1.FirstIfAny(x => x == 4).Count());
            Assert.AreEqual(1, data1.FirstIfAny(x => x <= 100).Count());
            Assert.AreEqual(1, data1.FirstIfAny().Count());
        }

        [TestMethod]
        public void LastIfAny()
        {
            data1.LastIfAny(x => x == 5).ForEach(x => Assert.Fail());
            Assert.AreEqual(0, data1.LastIfAny(x => x == 5).Count());
            Assert.AreEqual(1, data1.LastIfAny(x => x == 4).Count());
            Assert.AreEqual(1, data1.LastIfAny(x => x <= 100).Count());
            Assert.AreEqual(1, data1.LastIfAny().Count());
        }

        [TestMethod]
        public void WhereIndex()
        {
            var matches = data1.WhereIndex(x => 5 <= x && x <= 8).ToList();
            Assert.AreEqual(36, matches[0]);
            Assert.AreEqual(49, matches[1]);
            Assert.AreEqual(64, matches[2]);
            Assert.AreEqual(81, matches[3]);
            Assert.AreEqual(4, matches.Count());
        }

        [TestMethod]
        public void EveryOther()
        {
            var matches = data1.EveryOther().ToList();
            Assert.AreEqual(1, matches[0]);
            Assert.AreEqual(9, matches[1]);
            Assert.AreEqual(25, matches[2]);
            Assert.AreEqual(49, matches[3]);
            Assert.AreEqual(81, matches[4]);
        }

        [TestMethod]
        public void EveryOtherAfterFirst()
        {
            var matches = data1.EveryOtherAfterFirst().ToList();
            Assert.AreEqual(4, matches[0]);
            Assert.AreEqual(16, matches[1]);
            Assert.AreEqual(36, matches[2]);
            Assert.AreEqual(64, matches[3]);
        }

        [TestMethod]
        public void Mask()
        {
            var masked = data1.Mask(x => x <= 16);
            Assert.AreEqual(6, masked.Count(x => x == 0));
        }

        [TestMethod]
        public void MaskIndex()
        {
            var masked = data1.MaskIndex(x => x <= 1);
            Assert.AreEqual(2, masked.Count(x => x != 0));
        }

        [TestMethod]
        public void RemoveDefaults()
        {
            var masked = data1.MaskIndex(x => x <= 1);
            Assert.AreEqual(2, masked.RemoveDefaults().Count());
        }

        [TestMethod]
        public void NotOfType()
        {
            var filtered = data3.NotOf().Type<string>();
            Assert.AreEqual(1, data3.OfType<string>().Count());
            Assert.AreEqual(0, filtered.OfType<string>().Count());
            Assert.AreEqual(2, filtered.OfType<int>().Count());

        }

        [TestMethod]
        public void IndexOf()
        {
            var index = data1.IndexOf(25);
            Assert.AreEqual(4, index);

            var index2 = data1.IndexOf(1);
            Assert.AreEqual(0, index2);

            var index3 = data1.IndexOf(100);
            Assert.AreEqual(9, index3);

            try
            {
                var otherIndex = data1.IndexOf(123);
                Assert.Fail();
            }
            catch (KeyNotFoundException)
            {
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Corresponding()
        {
            var corresponding = data1.Corresponding(9, data3);
            Assert.AreEqual("Hello", corresponding);
        }

        [TestMethod]
        public void SequenceEqual()
        {
            Func<int, int, bool> predicate = (x, y) => 2 * x == y;
            Assert.IsTrue(data4.SequenceEqual(data5, predicate));
            Assert.IsFalse(data4.SequenceEqual(data6, predicate));
            Assert.IsFalse(data4.SequenceEqual(data7, predicate));
            Assert.IsFalse(data4.SequenceEqual(data8, predicate));
            Assert.IsFalse(data8.SequenceEqual(data4, predicate));
        }

        [TestMethod]
        public void IsPermutationOf()
        {
            Assert.IsTrue(data1.IsPermutationOf(data10));
            Assert.IsTrue(data10.IsPermutationOf(data1));

            Assert.IsFalse(data10.IsPermutationOf(data11));
            Assert.IsFalse(data11.IsPermutationOf(data10));
        }

        [TestMethod]
        public void Shuffle()
        {
            for (var i = 0; i < 500; i++)
            {
                var shuffled = data1.Shuffle();
                Assert.IsTrue(shuffled.All(x => data1.Contains(x)));
                Assert.IsTrue(shuffled.IsPermutationOf(data1));
            }
        }

        [TestMethod]
        public void IfNotDefault()
        {
            var flag = false;
            data3.OfType<string>().FirstOrDefault().IfNotDefault(x => flag = true);
            Assert.IsTrue(flag);

            data9.FirstOrDefault().IfNotDefault(x => Assert.Fail());
        }
    }
}
