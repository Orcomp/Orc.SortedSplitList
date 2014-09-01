#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="WrappedSortedtList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList
{
	#region using...
	
	#endregion

	public class WrappedDotNetSortedList<TSorter, TValue> : ITestOperations<TSorter, TValue>
	{
		#region Fields
		private readonly System.Collections.Generic.SortedList<TSorter, TValue> _sortedList;
		#endregion

		#region Constructors
		public WrappedDotNetSortedList()
		{
			_sortedList = new System.Collections.Generic.SortedList<TSorter, TValue>();
		}
		#endregion

		#region ITestOperations<TSorter,TValue> Members
		public int Count
		{
			get { return _sortedList.Count; }
		}

		public void Add(TSorter key, TValue value)
		{
			_sortedList.Add(key, value);
		}

		public bool Remove(TSorter key, TValue value)
		{
			return _sortedList.Remove(key);
		} 

		public int BinarySearch(TSorter key)
		{
			return _sortedList.IndexOfKey(key);
		}

		public TValue Item(int index)
		{
			return _sortedList.Values[index];
		}
		#endregion
	}
}