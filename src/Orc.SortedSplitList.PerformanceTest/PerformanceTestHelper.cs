// -------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTestHelper.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.PerformanceTest
{
	using System.Collections.Generic;

	public static class PerformanceTestHelper
	{
		#region Methods
		public static void Enumerate<T>(this IEnumerable<T> enumerable)
		{
			foreach (var item in enumerable)
			{
				;
			}
		}
		#endregion
	}
}