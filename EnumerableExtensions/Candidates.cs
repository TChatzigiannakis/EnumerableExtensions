using System;
using System.Collections.Generic;

namespace EnumerableExtensions
{
	public static class Candidates
	{
		public static T OperatorPlus<T>(this T operand1, T operand2)
		{
			object op1 = operand1;
			object op2 = operand2;
			object result = null;

			if (typeof(T) == typeof(int))
				result = (int)op1 + (int)op2;
			else if (typeof(T) == typeof(float))
				result = (float)op1 + (float)op2;
			else if (typeof(T) == typeof(double))
				result = (double)op1 + (double)op2;
			else if (typeof(T) == typeof(decimal))
				result = (decimal)op1 + (decimal)op2;
			else if (typeof(T) == typeof(byte))
				result = (byte)op1 + (byte)op2;
			else if (typeof(T) == typeof(string))
				result = (string)op1 + (string)op2;

			if(result == null)
				throw new ArgumentException ();

			return (T)result;
		}

		public static bool OperatorGreaterThan<T>(this T operand1, T operand2)
		{
			object op1 = operand1;
			object op2 = operand2;

			if (typeof(T) == typeof(int))
				return (int)op1 > (int)op2;
			else if (typeof(T) == typeof(float))
				return (float)op1 > (float)op2;
			else if (typeof(T) == typeof(double))
				return (double)op1 > (double)op2;
			else if (typeof(T) == typeof(decimal))
				return (decimal)op1 > (decimal)op2;

			throw new ArgumentException ();
		}

	}
}

