#region Copyright (c) 2014 Orcomp development team.
// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleSortedList.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace Orc.SortedSplitList
{
	#region using...
	using System;
	using System.Collections.Generic;

	#endregion

	public class SimpleSortedList<TSorter, TValue>
	{
		#region Fields
		private readonly IComparer<TSorter> _comparer;
		private TSorter[] _keys;
		private TValue[] _values;
		private int _count;
		#endregion

		#region Constructors
		public SimpleSortedList()
		{
			_keys = new TSorter[0];
			_values = new TValue[0];
			_count = 0;
			_comparer = Comparer<TSorter>.Default;
		}
		#endregion

		#region Properties
		private int Capacity
		{
			get { return _keys.Length; }
			set
			{
				if (value != _keys.Length)
				{
					if (value < _count)
					{
						throw new ArgumentException("value < _count");
					}

					if (value > 0)
					{
						var newKeys = new TSorter[value];
						var newValues = new TValue[value];
						if (_count > 0)
						{
							Array.Copy(_keys, 0, newKeys, 0, _count);
							Array.Copy(_values, 0, newValues, 0, _count);
						}
						_keys = newKeys;
						_values = newValues;
					}
					else
					{
						_keys = new TSorter[0];
						_values = new TValue[0];
					}
				}
			}
		}

		/// <summary>
		/// Gets the Keys as read/write array.
		/// Note: Do not alter the array values
		/// Note: Use list's Count property to get the data size of this array, and do not use Length
		/// </summary>
		/// <value>The keys.</value>
		public TSorter[] Keys
		{
			// TODO: Make the array read only with acceptable performance
			// TODO: The count/length shoud be equal with Count
			get { return _keys; }
		}

		/// <summary>
		/// Gets the Values as read/write array.
		/// Note: Use list's Count property to get the data size of this array, and do not use Length
		/// </summary>
		/// <value>The values.</value>
		public TValue[] Values
		{
			// TODO: The count/length shoud be equal with Count
			// Note: Do not make this array read only.
			get { return _values; }
		}

		public int Count
		{
			get { return _count; }
		}

		public KeyValuePair<TSorter, TValue> this[int index]
		{
			get
			{
				if (index < 0 || index >= _count)
				{
					throw new IndexOutOfRangeException("Key not found");
				}
				return new KeyValuePair<TSorter, TValue>(_keys[index], _values[index]);
			}
		}
		#endregion

		#region Methods
		public IEnumerable<int> Between(TSorter low, TSorter high, bool lowIncluded = true, bool highIncluded = false)
		{
			var lowIndex = BinarySearch(low);
			if (lowIndex < 0)
			{
				lowIndex = ~lowIndex;
			}

			var highIndex = BinarySearch(high);

			if (highIndex < 0)
			{
				highIndex = ~highIndex - 1;
			}

			if (!lowIncluded && lowIndex < Count && _comparer.Compare(low, _keys[lowIndex]) == 0)
			{
				lowIndex++;
			}

			if (!highIncluded && highIndex >= 0 && highIndex < Count && _comparer.Compare(high, _keys[highIndex]) == 0)
			{
				highIndex--;
			}

			for (var i = lowIndex; i <= highIndex; i++)
			{
				yield return i;
			}
		}

		public void Add(TSorter key, TValue value)
		{
			var i = Array.BinarySearch(_keys, 0, _count, key, _comparer);
			if (i >= 0)
			{
				throw new ArgumentException("Duplicate keys are not allowed");
			}
			Insert(~i, key, value);
		}

		public bool Remove(TSorter key, TValue value)
		{
			var index = BinarySearch(key);
			if (index < 0)
			{
				return false;
			}

			while (Keys[index].Equals(key))
			{
				if (Equals(Values[index], value))
				{
					RemoveAt(index);
					return true;
				}
				index++;
			}
			return false;
		}

		public int BinarySearch(TSorter key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			// That's is point: Do not swallow the informantion of the negative value.
			return Array.BinarySearch(_keys, 0, _count, key, _comparer);
		}

		private void Insert(int index, TSorter key, TValue value)
		{
			if (_count == _keys.Length)
			{
				Capacity = _keys.Length == 0 ? 1024 : Math.Max(_count + 1, Math.Min(_keys.Length*2, 0X7FEFFFFF));
			}
			if (index < _count)
			{
				Array.Copy(_keys, index, _keys, index + 1, _count - index);
				Array.Copy(_values, index, _values, index + 1, _count - index);
			}
			_keys[index] = key;
			_values[index] = value;
			_count++;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= _count)
			{
				throw new ArgumentException("index < 0 || index >= _count");
			}
			_count--;
			if (index < _count)
			{
				Array.Copy(_keys, index + 1, _keys, index, _count - index);
				Array.Copy(_values, index + 1, _values, index, _count - index);
			}
			_keys[_count] = default(TSorter);
			_values[_count] = default(TValue);
		}

		public void Clear()
		{
			_keys = new TSorter[0];
			_values = new TValue[0];
			_count = 0;
		}
		#endregion
	}
}