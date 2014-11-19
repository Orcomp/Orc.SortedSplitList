// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedArraySortedList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.C5
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using global::C5;

	public class SortedArraySortedList<T> : ISortedList<T>
	{
		#region Fields
		private readonly SortedArray<T> _sortedArray;
		#endregion

		#region Constructors
		public SortedArraySortedList(IComparer<T> comparer = null)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			_sortedArray = new SortedArray<T>(comparer);
		}
		#endregion

		#region ISortedList<T> Members
		public int Count
		{
			get { return _sortedArray.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public IEnumerable<Tuple<T, int>> FindExact(T item)
		{
			throw new System.NotImplementedException();
		}

		void System.Collections.Generic.ICollection<T>.Add(T item)
		{
			_sortedArray.Add(item);
		}

		public bool Add(T item)
		{
			return _sortedArray.Add(item);
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

			return _sortedArray.Remove(item);
		}

		public bool AllowsReferenceDuplicates
		{
			get { return false; }
		}

		public int BinarySearch(T item)
		{
			return _sortedArray.IndexOf(item);
		}


		public bool IsAdvancedBinarySearchSupported
		{
			get { return true; }
		}

		public void Clear()
		{
			_sortedArray.Clear();
		}

		public bool Contains(T item)
		{
			return _sortedArray.Contains(item);
		}

		T ISortedList<T>.this[int index]
		{
			get { return _sortedArray[index]; }
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _sortedArray.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}