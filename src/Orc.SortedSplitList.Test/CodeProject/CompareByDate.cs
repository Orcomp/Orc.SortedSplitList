// -------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareByDate.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.Test
{
	using System.Collections.Generic;

	public class CompareByDate : IComparer<TestObject>
	{
		#region IComparer<TestObject> Members
		public int Compare(TestObject x, TestObject y)
		{
			return x.Date.CompareTo(y.Date);
		}
		#endregion
	}
}