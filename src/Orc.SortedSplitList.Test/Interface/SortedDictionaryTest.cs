// -------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedDictionaryTest.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.Test.Interface
{
	using System;
	using System.Linq;
	using NUnit.Framework;

	[TestFixture]
	[Explicit]
	public abstract class SortedDictionaryTest
	{
		#region Setup/Teardown
		[SetUp]
		public void SetUp()
		{
			_target = CreateTarget();

			for (var index = _keys.Length - 1; index >= 0; index--)
			{
				_target.Add(_keys[index], ValueComplementer - _keys[index]);
			}
			_emptyTarget = CreateTarget();
		}
		#endregion

		protected abstract ISortedDictionary<int, int> CreateTarget();

		private ISortedDictionary<int, int> _emptyTarget;
		private ISortedDictionary<int, int> _target;
		private const int ValueComplementer = 100;
		private readonly int[] _keys = {0, 10, 20, 30, 40, 50, 60, 70, 80, 90};

		[Test]
		public void Add_Empty_OK()
		{
			const int key = -1;
			_emptyTarget.Add(key, ValueComplementer - key);
			Assert.AreEqual(1, _emptyTarget.Count);
		}

		[Test]
		public void Add_OK()
		{
			var count = _target.Count;
			const int key = -1;
			_target.Add(key, ValueComplementer - key);
			Assert.AreEqual(count + 1, _target.Count);
		}

		[Test]
		public void BinarySearch_Empty_NotFound()
		{
			Assert.AreEqual(-1, _emptyTarget.BinarySearch(123456));
		}

		[Test]
		public void BinarySearch_Exact_Match_Found()
		{
			for (var index = 0; index < _keys.Length; index++)
			{
				Assert.AreEqual(index, _target.BinarySearch(_keys[index]));
			}
		}

		[Test]
		public void BinarySearch_Match_OK()
		{
			if (_emptyTarget.IsAdvancedBinarySearchSupported)
			{
				for (var index = 0; index < _keys.Length; index++)
				{
					Assert.AreEqual(-(index + 2), _target.BinarySearch(_keys[index] + 1));
				}

				Assert.AreEqual(-1, _target.BinarySearch(int.MinValue));
				Assert.AreEqual(-(_target.Count + 1), _target.BinarySearch(int.MaxValue));
			}
			else
			{
				foreach (var key in _keys)
				{
					Assert.AreEqual(-1, _target.BinarySearch(key + 1));
				}

				Assert.AreEqual(-1, _target.BinarySearch(int.MinValue));
				Assert.AreEqual(-1, _target.BinarySearch(int.MaxValue));
			}
		}

		[Test]
		public void ClearTest()
		{
			_target.Clear();
			Assert.AreEqual(0, _target.Count);
		}

		[Test]
		public void Count_OK()
		{
			Assert.AreEqual(_keys.Length, _target.Count);
		}

		[Test]
		public void Enumerator_WorksAsExpected()
		{
			var array = _target.ToArray();
			Assert.AreEqual(_keys.Length, array.Length);
			var index = 0;
			foreach (var value in _target)
			{
				Assert.AreEqual(ValueComplementer - _keys[index++], value);
			}
		}

		[Test]
		public void GetEnumerator_Different()
		{
			var enumerator = _target.GetEnumerator();
			var otherEnumerator = _target.GetEnumerator();
			Assert.IsFalse(otherEnumerator.Equals(enumerator));
		}

		[Test]
		public void IndexOfOutOfRangeTest_GreaterThanCountMinusOne()
		{
			// Different implementations are throwing different type of Exceptions
			try
			{
				var dummy = _target[_keys.Length];
				Assert.Fail("No Exception was thrown");
			}
			catch (IndexOutOfRangeException e)
			{
				return;
			}
			catch (ArgumentOutOfRangeException e)
			{
				return;
			}
			catch (Exception e)
			{
			}
			Assert.Fail("Unexpected type of excetption was thrown");
		}

		[Test]
		public void IndexOfOutOfRangeTest_LessThanZero()
		{
			// Different implementations are throwing different type of Exceptions
			try
			{
				var dummy = _target[-1];
				Assert.Fail("No Exception was thrown");
			}
			catch (IndexOutOfRangeException e)
			{
				return;
			}
			catch (ArgumentOutOfRangeException e)
			{
				return;
			}
			catch (Exception e)
			{
			}
			Assert.Fail("Unexpected type of excetption was thrown");
		}

		[Test]
		public void Indexer_WorksAsExpected()
		{
			for (var i = 0; i < _keys.Length; i++)
			{
				Assert.AreEqual(ValueComplementer - _keys[i], _target[i]);
			}
		}

		[Test]
		public void Remove_Existing_OK()
		{
			for (var index = 0; index < _keys.Length; index++)
			{
				//Assert.AreEqual(index, _target.BinarySearch(_keys[index]));
				var result = _target.Remove(_keys[index], ValueComplementer - _keys[index]);
				Assert.IsTrue(result);
				Assert.AreNotEqual(index, _target.BinarySearch(_keys[index]));
			}
		}

		[Test]
		public void Remove_Not_Existing_OK()
		{
			var result = _target.Remove(_keys[0], -1);
			Assert.IsFalse(result);
			Assert.AreEqual(_keys.Length, _target.Count);
			result = _target.Remove(_keys[0] + 1, ValueComplementer - _keys[0]);
			Assert.IsFalse(result);
			Assert.AreEqual(_keys.Length, _target.Count);
		}
	}
}