#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="TestConfiguration.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.PerformanceTest
{
	#region using...
	using System;
	using NUnitBenchmarker.Configuration;

	#endregion

	public class TestConfiguration : PerformanceTestCaseConfigurationBase
	{
		#region Properties
		public int Size { get; set; }
		public string TestName { get; set; }
		public ISortedDictionary<DateTime, long> Target { get; set; }
		public long[] RandomLongs { get; set; }
		public DateTime[] RandomDateTimes { get; set; }
		#endregion

		#region Methods
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString()
		{
			return TestName;
		}
		#endregion
	}
}