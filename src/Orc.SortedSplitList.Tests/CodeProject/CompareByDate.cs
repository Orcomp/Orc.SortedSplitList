#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareByDate.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.Test
{
	#region using...
	using System.Collections.Generic;

	#endregion

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