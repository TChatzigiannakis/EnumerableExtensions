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

namespace EnumerableExtensions
{
	internal static class GenericOperatorCalls
	{
		public static T OperatorPlus<T>(this T operand1, T operand2)
		{
            if (typeof(T) == typeof(int)) return (T)(object)((int)(object)operand1 + (int)(object)operand2);
		    return (T) typeof (T).GetMethod("op_Addition").Invoke(null, new object[] {operand1, operand2});
		}

		public static bool OperatorGreaterThan<T>(this T operand1, T operand2)
        {
            if (typeof(T) == typeof(int)) return ((int)(object)operand1 > (int)(object)operand2);
		    return (bool) typeof (T).GetMethod("op_GreaterThan").Invoke(null, new object[] {operand1, operand2});
		}

        public static bool OperatorLessThan<T>(this T operand1, T operand2)
        {
            if (typeof(T) == typeof(int)) return ((int)(object)operand1 < (int)(object)operand2);
            return (bool)typeof(T).GetMethod("op_LessThan").Invoke(null, new object[] { operand1, operand2 });
        }
	}
}

