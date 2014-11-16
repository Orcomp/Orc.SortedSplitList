// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedArraySortedDictionary.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.C5
{
	using System.Collections;
	using System.Collections.Generic;
	using global::C5;

	public class SortedArraySortedDictionary<TSorter, TValue> : global::Orc.SortedSplitList.ISortedDictionary<TSorter, TValue>
	{
		#region Fields
		private readonly SortedArray<SimplestKeyValuePair> _sortedArray;
		private readonly TValue _dummyValue;
		#endregion

		#region Constructors
		public SortedArraySortedDictionary()
		{
			_sortedArray = new SortedArray<SimplestKeyValuePair>(new SimplestKeyValuePairComparer());
			_dummyValue = default(TValue);
		}
		#endregion

		#region ISortedDictionary<TSorter,TValue> Members
		public int Count
		{
			get { return _sortedArray.Count; }
		}

		public void Add(TSorter key, TValue value)
		{
			SimplestKeyValuePair kvp;
			kvp.Sorter = key;
			kvp.Value = value;
			_sortedArray.Add(kvp);
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

			while (_sortedArray[index].Sorter.Equals(key))
			{
				if (Equals(_sortedArray[index].Value, value))
				{
					_sortedArray.Remove(kvp);
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
			return _sortedArray.IndexOf(kvp);
		}

		public bool IsAdvancedBinarySearchSupported
		{
			get { return true; }
		}

		public void Clear()
		{
			_sortedArray.Clear();
		}

		TValue global::Orc.SortedSplitList.ISortedDictionary<TSorter, TValue>.this[int index]
		{
			get { return _sortedArray[index].Value; }
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			for (var i = 0; i < _sortedArray.Count; i++)
			{
				yield return _sortedArray[i].Value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
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

			#region IComparer<SortedArraySortedDictionary<TSorter,TValue>.SimplestKeyValuePair> Members
			public int Compare(SimplestKeyValuePair x, SimplestKeyValuePair y)
			{
				return _comparer.Compare(x.Sorter, y.Sorter);
			}
			#endregion
		}
		#endregion
	}
}