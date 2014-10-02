#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedArraySortedDictionaryTest.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.Test.Implementations
{
	#region using...
	using C5;
	using Interface;
	using NUnit.Framework;

	#endregion

	[TestFixture]
	public class SortedArraySortedDictionaryTest : SortedDictionaryTest
	{
		#region Setup/Teardown
		[SetUp]
		public new void SetUp()
		{
			base.SetUp();
		}
		#endregion

		protected override ISortedDictionary<int, int> CreateTarget()
		{
			return new SortedArraySortedDictionary<int, int>();
		}
	}
}