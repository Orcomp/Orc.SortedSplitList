// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SplitListSortedDictionary.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public class SplitListSortedDictionary<TSorter, TValue> : ISortedDictionary<TSorter, TValue>
	{
		#region Fields
		private readonly SortedSplitList<SimplestKeyValuePair> _sortedSplitList;
		private readonly TValue _dummyValue;
		#endregion

		#region Constructors
		public SplitListSortedDictionary()
		{
			_sortedSplitList = new SortedSplitList<SimplestKeyValuePair>(new SimplestKeyValuePairComparer());
			_dummyValue = default(TValue);
		}
		#endregion

		#region ISortedDictionary<TSorter,TValue> Members
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

			// Performance tested: There is no measurable performance overhead:
			var index = BinarySearch(key);
			if (index < 0)
			{
				return false;
			}

			while (_sortedSplitList[index].Sorter.Equals(key))
			{
				if (Equals(_sortedSplitList[index].Value, value))
				{
					_sortedSplitList.Remove(kvp);
					return true;
				}
				index++;
			}
			return false;
		}

		public int BinarySearch(TSorter key)
		{
			SimplestKeyValuePair kvp;
			kvp.Sorter = key;
			kvp.Value = _dummyValue;
			return _sortedSplitList.BinarySearch(kvp);
		}

		public bool IsAdvancedBinarySearchSupported
		{
			get { return true; }
		}

		public void Clear()
		{
			_sortedSplitList.Clear();
		}

		TValue ISortedDictionary<TSorter, TValue>.this[int index]
		{
			get { return _sortedSplitList[index].Value; }
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return _sortedSplitList.Select(keyValuePair => keyValuePair.Value).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion

		#region Methods
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

			#region IComparer<SplitListSortedDictionary<TSorter,TValue>.SimplestKeyValuePair> Members
			public int Compare(SimplestKeyValuePair x, SimplestKeyValuePair y)
			{
				return _comparer.Compare(x.Sorter, y.Sorter);
			}
			#endregion
		}
		#endregion
	}
}