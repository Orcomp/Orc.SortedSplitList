#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="ITestOperations.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList
{
	public interface ITestOperations<TSorter, TValue>
	{
		#region Properties
		int Count { get; }
		#endregion

		#region Methods
		void Add(TSorter key, TValue value);
		bool Remove(TSorter key, TValue value);
		int BinarySearch(TSorter key);
		TValue Item(int index);
		#endregion
	}
}