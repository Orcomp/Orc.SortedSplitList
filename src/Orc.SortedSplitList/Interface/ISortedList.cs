// -------------------------------------------------------------------------------------------------------------------
// <copyright file="ISortedList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList
{
	using System;
	using System.Collections.Generic;

	public interface ISortedList<T> : ICollection<T>
	{
		#region Properties
		/// <summary>
		/// Gets the element at the specified index. 
		/// Note: As this is a _sorted_ list only read operation makes sense.
		/// </summary>
		/// <returns>
		/// The element at the specified index.
		/// </returns>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index" /> is not a valid index in the <see cref="T:ISortedDictionary{TSorter,TValue}" />.</exception>
		T this[int index] { get; }

		/// <summary>
		/// Gets a value indicating whether this instance supports advanced binary search operation,
		/// when no exact match found.
		/// </summary>
		/// <value><c>true</c> if this instance is advance binary search supported; otherwise, <c>false</c>.</value>
		bool IsAdvancedBinarySearchSupported { get; }

		/// <summary>
		/// Indicates if the collection supports object duplicates based on reference equality.
		/// As a convention the collection should have a constructor parameter what allows to set this value
		/// </summary>
		/// <value>True if this collection allows reference duplicates.</value>
		bool AllowsReferenceDuplicates { get; }


		#endregion

		#region Methods
		/// <summary>
		/// Performs binary search by the given key.
		/// </summary>
		/// <param name="item">The item to as search key.</param>
		/// <returns>
		/// The index of the key if found otherwhise -1.
		/// Some implementations can provide the next greater keyed item.
		/// This case the implementation returns with the following:
		/// The index of the specified value in the specified array, if value is found. If value is not found
		/// and value is less than one or more elements in array, a negative number which is the bitwise
		/// complement of the index of the first element that is larger than value. If value is not found
		/// and value is greater than any of the elements in array, a negative number which is the bitwise
		/// complement of (the index of the last element plus 1).
		/// </returns>
		int BinarySearch(T item);


		/// <summary>
		/// Finds the exact equal items if any.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		IEnumerable<Tuple<T, int>> FindExact(T item);

		/// <summary>
		/// Adds the specified item. Conforms to C5 Intervals semantics, returns false if the item would be 
		/// a reference duplicate and reference duplicates are not allowed. 
		/// </summary>
		/// <param name="item">The item to Add.</param>
		/// <returns><c>true</c> if success, <c>false</c> otherwise.</returns>
		bool Add(T item);

		#endregion
	}
}