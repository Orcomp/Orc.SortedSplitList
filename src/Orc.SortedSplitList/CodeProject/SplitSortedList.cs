// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SplitSortedList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList
{
	using System.Collections;
	using System.Collections.Generic;

	public class SplitSortedList<T> : ISortedList<T>
	{
		#region Fields
		private readonly SortedSplitList<T> _sortedSplitList;
		#endregion

		#region Constructors
		public SplitSortedList(IComparer<T> comparer = null)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			_sortedSplitList = new SortedSplitList<T>(comparer);
		}
		#endregion

		#region ISortedList<T> Members
		public int Count
		{
			get { return _sortedSplitList.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public void Add(T item)
		{
			_sortedSplitList.Add(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new System.NotImplementedException();
		}

		public bool Remove(T item)
		{
			// Performance tested: There is no measurable performance overhead:
			var index = BinarySearch(item);
			if (index < 0)
			{
				return false;
			}

			_sortedSplitList.Remove(item);
			return true;
		}

		public int BinarySearch(T item)
		{
			return _sortedSplitList.BinarySearch(item);
		}

		public bool IsAdvancedBinarySearchSupported
		{
			get { return true; }
		}

		public void Clear()
		{
			_sortedSplitList.Clear();
		}

		public bool Contains(T item)
		{
			return BinarySearch(item) >= 0;
		}

		T ISortedList<T>.this[int index]
		{
			get { return _sortedSplitList[index]; }
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _sortedSplitList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}