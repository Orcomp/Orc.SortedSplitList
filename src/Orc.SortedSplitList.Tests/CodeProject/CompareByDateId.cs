#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareByDateId.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.Test
{
	#region using...
	using System.Collections.Generic;

	#endregion

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