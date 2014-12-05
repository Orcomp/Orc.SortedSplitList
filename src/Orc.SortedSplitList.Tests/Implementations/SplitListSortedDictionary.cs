// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SplitListSortedDictionary.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.Test.Implementations
{
	using Interface;
	using NUnit.Framework;

	[TestFixture]
	public class SplitListSortedDictionary : SortedDictionaryTest
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
			return new SplitListSortedDictionary<int, int>();
		}
	}
}