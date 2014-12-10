// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SplitSortedList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	public class SplitSortedList<T> : ISortedList<T>
	{
		#region Fields
		private readonly SortedSplitList<T> _sortedSplitList;
		private readonly bool _allowsReferenceDuplicates;
		private readonly Dictionary<long, T> _ids;
		private readonly ObjectIDGenerator _idGenerator;

		#endregion

		#region Constructors
		public SplitSortedList(IComparer<T> comparer = null, bool allowsReferenceDuplicates = false)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			_sortedSplitList = new SortedSplitList<T>(comparer);
			_allowsReferenceDuplicates = allowsReferenceDuplicates;
			_idGenerator = new ObjectIDGenerator();
			_ids = new Dictionary<long, T>();
		
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

		public IEnumerable<Tuple<T, int>> FindExact(T item)
		{
			var foundIndex = BinarySearch(item);
			if (foundIndex < 0)
			{
				yield break;;
			}
			
			// Find first backward:
			var index = foundIndex;
			for (; index >= 0; index--)
			{
				if (!_sortedSplitList[index].Equals(item));
				{
					break;
				}
			}
			index++;
			for (; index < _sortedSplitList.Count; index++)
			{
				var current = _sortedSplitList[index];
				if (current.Equals(item));
				{
					yield return new Tuple<T, int>(current, index);
				}				
			}
		}

		void ICollection<T>.Add(T item)
		{
			Add(item);
		}

		public bool Add(T item)
		{
			bool firstTime;
			var id = _idGenerator.GetId(item, out firstTime);
			
			// Using firstTime here would be a bad idea. It prevents not only the referece duplicates
			// but also "adding, removing, then adding again" the same instance.

			if (!_ids.ContainsKey(id))
			{
				_ids.Add(id, item);
				_sortedSplitList.Add(item);
				return true;
			}
				
				
			if (!_allowsReferenceDuplicates)
			{
				return false;
			}
			_sortedSplitList.Add(item);
			return true;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new System.NotImplementedException();
		}

		// To conform C5 Intervals: Remove is done by 'reference equality' not by equality:
		public bool Remove(T item)
		{
			// Performance tested: There is no measurable performance overhead:
			var foundIndex = BinarySearch(item);
			if (foundIndex < 0)
			{
				return false;
			}
			// Try forward:
			for (var index = foundIndex; index < _sortedSplitList.Count; index++)
			{
				var current = _sortedSplitList[index];
				if (ReferenceEquals(current, item))
				{
					_sortedSplitList.RemoveAt(index);
					return true;
				}
				if (!current.Equals(item))
				{
					break;
				}
			}
			// Try backward:
			for (var index = foundIndex-1; index >= 0; index--)
			{
				var current = _sortedSplitList[index];
				if (ReferenceEquals(current, item))
				{
					_sortedSplitList.RemoveAt(index);
					return true;
				}
				if (!current.Equals(item))
				{
					break;
				}
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			_sortedSplitList.RemoveAt(index);
		}

		public bool AllowsReferenceDuplicates
		{
			get { return _allowsReferenceDuplicates;  }
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