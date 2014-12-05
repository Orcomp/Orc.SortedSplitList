// -------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareById.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.Test
{
	using System.Collections.Generic;

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