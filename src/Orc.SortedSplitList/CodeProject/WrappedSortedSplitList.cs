#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="WrappedSortedSplitList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList
{
	#region using...
	using System.Collections.Generic;

	#endregion

	public class WrappedSortedSplitList<TSorter, TValue> : ITestOperations<TSorter, TValue>
	{
		#region Fields
		private readonly SortedSplitList<SimplestKeyValuePair> _sortedSplitList;
		private readonly TValue _dummyValue;
		#endregion

		#region Constructors
		public WrappedSortedSplitList()
		{
			_sortedSplitList = new SortedSplitList<SimplestKeyValuePair>(new SimplestKeyValuePairComparer());
			_dummyValue = default(TValue);
		}
		#endregion

		#region ITestOperations<TSorter,TValue> Members
		public int Count
		{
			get { return _sortedSplitList.Count; }
		}

		public void Add(TSorter key, TValue value)
		{
			SimplestKeyValuePair kvp;
			kvp.Sorter = key;
			kvp.Value = value;
			_sortedSplitList.Add(kvp);
		}

		public bool Remove(TSorter key, TValue value)
		{
			SimplestKeyValuePair kvp;
			kvp.Sorter = key;
			kvp.Value = value;
			_sortedSplitList.Remove(kvp);
			return true;
		}

		public int BinarySearch(TSorter key)
		{
			SimplestKeyValuePair kvp;
			kvp.Sorter = key;
			kvp.Value = _dummyValue;
			return _sortedSplitList.BinarySearch(kvp);
		}

		public TValue Item(int index)
		{
			return _sortedSplitList[index].Value;
		}
		#endregion

		#region Nested type: SimplestKeyValuePair
		private struct SimplestKeyValuePair
		{
			#region Fields
			public TSorter Sorter;
			public TValue Value;
			#endregion
		}
		#endregion

		#region Nested type: SimplestKeyValuePairComparer
		private class SimplestKeyValuePairComparer : IComparer<SimplestKeyValuePair>
		{
			#region Constants
			private static IComparer<TSorter> _comparer = Comparer<TSorter>.Default;
			#endregion

			#region IComparer<WrappedSortedSplitList<TSorter,TValue>.SimplestKeyValuePair> Members
			public int Compare(SimplestKeyValuePair x, SimplestKeyValuePair y)
			{
				return _comparer.Compare(x.Sorter, y.Sorter);
			}
			#endregion
		}
		#endregion
	}
}