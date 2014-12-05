// -------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareByDateId.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.Test
{
	using System.Collections.Generic;

	public class CompareByDateId : IComparer<TestObject>
	{
		#region IComparer<TestObject> Members
		public int Compare(TestObject x, TestObject y)
		{
			var dateResult = x.Date.CompareTo(y.Date);
			if (dateResult == 0)
			{
				if (x.Id == y.Id)
				{
					return 0;
				}
				if (x.Id < y.Id)
				{
					return -1;
				}
				return 1;
			}
			return dateResult;
		}
		#endregion
	}
}