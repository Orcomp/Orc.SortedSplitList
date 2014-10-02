#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="ISortedDictionary.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList
{
	#region using...
	using System.Collections.Generic;

	#endregion

	/// <summary>
	/// Interface ISortedDictionary
	/// Defines methods to manipulate generic sorted lists / dictionaries.
	/// </summary>
	/// <typeparam name="TSorter">The type of the sorter key. Elements will be enumerably and binary searchable by this key.</typeparam>
	/// <typeparam name="TValue">The type of the value associated with each key.</typeparam>
	public interface ISortedDictionary<in TSorter, TValue> : IEnumerable<TValue>
	{
		#region Properties
		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:ISortedDictionary{TSorter,TValue}" />.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the <see cref="T:ISortedDictionary{TSorter,TValue}" />.
		/// </returns>
		int Count { get; }

		/// <summary>
		/// Gets the element at the specified index. Currently only the read operation is suported
		/// </summary>
		/// <returns>
		/// The element at the specified index.
		/// </returns>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index" /> is not a valid index in the <see cref="T:ISortedDictionary{TSorter,TValue}" />.</exception>
		TValue this[int index] { get; }

		/// <summary>
		/// Gets a value indicating whether this instance supports advanced binary search operation,
		/// when no exact match found.
		/// </summary>
		/// <value><c>true</c> if this instance is advance binary search supported; otherwise, <c>false</c>.</value>
		bool IsAdvancedBinarySearchSupported { get; }
		#endregion

		#region Methods
		/// <summary>
		/// Adds an item to the <see cref="T:ISortedDictionary{TSorter,TValue}" />.
		/// </summary>
		/// <param name="key">The key associated to the value. The ordering and indexed access order done by this key</param>
		/// <param name="value">The object to add to the <see cref="T:ISortedDictionary{TSorter,TValue}" />.</param>
		void Add(TSorter key, TValue value);

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:ISortedDictionary{TSorter,TValue}" />.
		/// </summary>
		/// <returns>
		/// true if <paramref name="value" /> was successfully removed from the <see cref="T:ISortedDictionary{TSorter,TValue}" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:ISortedDictionary{TSorter,TValue}" />.
		/// </returns>
		/// <param name="key">The key and value to remove. In case there are multiple match, one of them will be removed.</param>
		/// <param name="value">The object to remove from the <see cref="T:ISortedDictionary{TSorter,TValue}" />.</param>
		bool Remove(TSorter key, TValue value);

		/// <summary>
		/// Performs binary search by the key.
		/// </summary>
		/// <param name="key">The key to search by.</param>
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
		int BinarySearch(TSorter key);

		/// <summary>
		/// Removes all items from the <see cref="T:ISortedDictionary{TSorter,TValue}" />.
		/// </summary>
		void Clear();
		#endregion
	}
}