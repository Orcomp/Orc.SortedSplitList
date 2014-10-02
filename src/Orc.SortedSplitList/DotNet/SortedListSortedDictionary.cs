#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedListSortedDictionary.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList.DotNet
{
	#region using...
	using System.Collections;
	using System.Linq;

	#region using...
	using System.Collections.Generic;

	#endregion

	#endregion

	#region using...
	#endregion

	public class SortedListSortedDictionary<TSorter, TValue> : ISortedDictionary<TSorter, TValue>
	{
		#region Fields
		private readonly SortedList<TSorter, TValue> _sortedList;
		#endregion

		#region Constructors
		public SortedListSortedDictionary()
		{
			_sortedList = new SortedList<TSorter, TValue>();
		}
		#endregion

		#region ISortedDictionary<TSorter,TValue> Members
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
			// Performance tested: There is no measurable performance overhead:
			var index = BinarySearch(key);
			if (index < 0)
			{
				return false;
			}

			while (_sortedList.Keys[index].Equals(key))
			{
				if (Equals(_sortedList.Values[index], value))
				{
					_sortedList.Remove(key);
					return true;
				}
				index++;
			}
			return false;
		}

		public int BinarySearch(TSorter key)
		{
			return _sortedList.IndexOfKey(key);
		}

		public bool IsAdvancedBinarySearchSupported
		{
			get { return false; }
		}

		public void Clear()
		{
			_sortedList.Clear();
		}

		TValue ISortedDictionary<TSorter, TValue>.this[int index]
		{
			get { return _sortedList.Values[index]; }
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return _sortedList.Select(keyValuePair => keyValuePair.Value).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}