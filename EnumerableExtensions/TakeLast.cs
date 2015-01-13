using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Takes a number of elements from the given sequence, leading up to the last one. If the original sequence doesn't contain enough elements, then all of its elements are returned. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> sequence, int count)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (count <= 0) return new T[0];

            var buffer = new T[count];
            var index = 0;
            var pastFull = false;

            foreach (var e in sequence)
            {
                buffer[index++] = e;
                if (index == count)
                {
                    index = 0;
                    pastFull = true;
                }
            }

            if (!pastFull) return buffer.Take(index);

            return buffer.Skip(index).Concat(buffer.Take(index));
        }
    }
}
