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
            if(typeof(T).IsValueType) return sequence.Except (x => x.Equals (default(T)));
            return RemoveNull<T> (sequence);
        }

        /// <summary>
        /// Filters out all null instances from the given sequence.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> sequence) 
        {
            return sequence.Except (x => object.ReferenceEquals(x, null));
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
                if(object.ReferenceEquals(x, null)) return true;
                if(!x.GetType().IsValueType) return false;
                return x.Equals(Activator.CreateInstance(x.GetType()));
            });
        }
    }
}

