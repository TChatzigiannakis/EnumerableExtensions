using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumerableExtensions;

namespace EnumerableExtensionsManualTests
{
    class Program
    {
        static void Main(string[] args)
        {
			var inf = Enumerable.Range (0, 100);
			var result = inf.AccumulateAtLeast (5, x => x);
			result.ForEach (Console.WriteLine);
			Console.ReadLine ();
        }
    }
}
