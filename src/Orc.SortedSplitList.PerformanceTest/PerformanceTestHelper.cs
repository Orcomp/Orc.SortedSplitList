#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTestHelper.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.PerformanceTest
{
	#region using...
	using System.Collections.Generic;

	#endregion

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