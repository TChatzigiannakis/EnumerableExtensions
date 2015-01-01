using System;
using System.Linq;
using System.Collections.Generic;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Filters out all instances equal to the default value of the given sequence.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveDefaults<T>(this IEnumerable<T> sequence) 
        {
            return sequence.Except (x => x.Equals (default(T)));
        }

        /// <summary>
        /// Filters out all null instances from the given sequence.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> sequence) 
            where T : class
        {
            return sequence.Except (x => x.Equals (null));
        }

        /// <summary>
        /// Filters out all instances equal to the default value of their own individual type.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveIndividualDefaults<T>(this IEnumerable<T> sequence)
        {
            return sequence.Except (x => {
                if(!x.GetType().IsValueType) return x.Equals(null);
                else return x.Equals(Activator.CreateInstance(x.GetType()));
            });
        }
    }
}

