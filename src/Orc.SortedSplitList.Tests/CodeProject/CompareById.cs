#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareById.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.Test
{
	#region using...
	using System.Collections.Generic;

	#endregion

	public class CompareById : IComparer<TestObject>
	{
		#region IComparer<TestObject> Members
		public int Compare(TestObject x, TestObject y)
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
		#endregion
	}
}