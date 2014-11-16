// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleSortedListSortedDictionary.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public class SimpleSortedListSortedDictionary<TSorter, TValue> : ISortedDictionary<TSorter, TValue>
	{
		#region Fields
		private readonly SimpleSortedList<TSorter, TValue> _simpleSortedList;
		#endregion

		#region Constructors
		public SimpleSortedListSortedDictionary()
		{
			_simpleSortedList = new SimpleSortedList<TSorter, TValue>();
		}
		#endregion

		#region ISortedDictionary<TSorter,TValue> Members
		public int Count
		{
			get { return _simpleSortedList.Count; }
		}

		public void Add(TSorter key, TValue value)
		{
			_simpleSortedList.Add(key, value);
		}

		public bool Remove(TSorter key, TValue value)
		{
			return _simpleSortedList.Remove(key, value);
		}

		public int BinarySearch(TSorter key)
		{
			return _simpleSortedList.BinarySearch(key);
		}

		public bool IsAdvancedBinarySearchSupported
		{
			get { return true; }
		}

		public void Clear()
		{
			_simpleSortedList.Clear();
		}

		TValue ISortedDictionary<TSorter, TValue>.this[int index]
		{
			get
			{
				if (index < 0 || index > Count - 1)
				{
					throw new IndexOutOfRangeException();
				}
				return _simpleSortedList.Values[index];
			}
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			var index = 0;
			return _simpleSortedList.Values.TakeWhile(value => index++ <= Count - 1).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}