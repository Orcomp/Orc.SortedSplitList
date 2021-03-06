﻿// -------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTestFactory.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.PerformanceTest
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using C5;
	using DotNet;
	using NUnitBenchmarker;
	using NUnitBenchmarker.Configuration;

	public class PerformanceTestFactory
	{
		#region Fields
		private readonly Random _random = new Random(0);
		private readonly long _offset = new DateTime(2000, 1, 1).Ticks;
		#endregion

		#region Properties
		private IEnumerable<Type> ImplementationTypes
		{
			get
			{
				IList<int> x;
				return new[]
				{
					typeof (SplitListSortedDictionary<DateTime, long>),
					typeof (SimpleSortedListSortedDictionary<DateTime, long>),
					typeof (SortedListSortedDictionary<DateTime, long>),
					typeof (SortedArraySortedDictionary<DateTime, long>)
				};
			}
		}

		private static IEnumerable<int> Sizes
		{
			get { return new[] {5000, 10000, 50000, 100000}; }
		}
		#endregion

		#region Methods
		private IEnumerable<TestConfiguration> AddSortedTestCases()
		{
			return from implementationType in ImplementationTypes
			       from size in Sizes
			       let prepare = new Action<IPerformanceTestCaseConfiguration>(c =>
			       {
				       var config = (TestConfiguration) c;
				       PrepareAddSorted(size, implementationType, config);
			       })
			       let run = new Action<IPerformanceTestCaseConfiguration>(c =>
			       {
				       var config = (TestConfiguration) c;
				       config.Target = CreateTarget<DateTime, long>(implementationType);
				       for (var i = 0; i < size; i++)
				       {
					       config.Target.Add(config.RandomDateTimes[i], config.RandomLongs[i]);
				       }
			       })
			       select new TestConfiguration
			       {
				       TestName = "AddSorted",
				       TargetImplementationType = implementationType,
				       Identifier = string.Format("{0}", implementationType.GetFriendlyName()),
				       Size = size,
				       Prepare = prepare,
				       Run = run,
				       IsReusable = true,
				       Divider = size
			       };
		}

        private IEnumerable<TestConfiguration> AddRandomTestCases()
        {
            return from implementationType in ImplementationTypes
                   from size in Sizes
                   let prepare = new Action<IPerformanceTestCaseConfiguration>(c =>
                   {
                       var config = (TestConfiguration)c;
                       PrepareAddRandom(size, implementationType, config);
                   })
                   let run = new Action<IPerformanceTestCaseConfiguration>(c =>
                   {
                       var config = (TestConfiguration)c;
                       config.Target = CreateTarget<DateTime, long>(implementationType);
                       for (var i = 0; i < size; i++)
                       {
                           config.Target.Add(config.RandomDateTimes[i], config.RandomLongs[i]);
                       }
                   })
                   select new TestConfiguration
                   {
                       TestName = "AddRandom",
                       TargetImplementationType = implementationType,
                       Identifier = string.Format("{0}", implementationType.GetFriendlyName()),
                       Size = size,
                       Prepare = prepare,
                       Run = run,
                       IsReusable = true,
                       Divider = size
                   };
        }

		private IEnumerable<TestConfiguration> RemoveTestCases()
		{
			return from implementationType in ImplementationTypes
			       from size in Sizes
			       let prepare = new Action<IPerformanceTestCaseConfiguration>(c =>
			       {
				       var config = (TestConfiguration) c;
				       PrepareRemove(size, implementationType, config);
			       })
			       let run = new Action<IPerformanceTestCaseConfiguration>(c =>
			       {
				       var config = (TestConfiguration) c;
				       for (var i = 0; i < size; i++)
				       {
					       config.Target.Remove(config.RandomDateTimes[i], config.RandomLongs[i]);
				       }
			       })
			       select new TestConfiguration
			       {
				       TestName = "Remove",
				       TargetImplementationType = implementationType,
				       Identifier = string.Format("{0}", implementationType.GetFriendlyName()),
				       Size = size,
				       Prepare = prepare,
				       Run = run,
				       IsReusable = false,
				       Divider = size
			       };
		}

		private IEnumerable<TestConfiguration> SearchTestCases()
		{
			return from implementationType in ImplementationTypes
			       from size in Sizes
			       let prepare = new Action<IPerformanceTestCaseConfiguration>(c =>
			       {
				       var config = (TestConfiguration) c;
				       PrepareSearch(size, implementationType, config);
			       })
			       let run = new Action<IPerformanceTestCaseConfiguration>(c =>
			       {
				       var config = (TestConfiguration) c;
				       for (var i = 0; i < size; i++)
				       {
					       config.Target.BinarySearch(config.RandomDateTimes[i]);
				       }
			       })
			       select new TestConfiguration
			       {
				       TestName = "Binary Search",
				       TargetImplementationType = implementationType,
				       Identifier = string.Format("{0}", implementationType.GetFriendlyName()),
				       Size = size,
				       Prepare = prepare,
				       Run = run,
				       IsReusable = true,
				       Divider = size
			       };
		}

        private IEnumerable<TestConfiguration> EnumerateTestCases()
        {
            return from implementationType in ImplementationTypes
                   from size in Sizes
                   let prepare = new Action<IPerformanceTestCaseConfiguration>(c =>
                   {
                       var config = (TestConfiguration)c;
                       PrepareSearch(size, implementationType, config);
                   })
                   let run = new Action<IPerformanceTestCaseConfiguration>(c =>
                   {
                       var config = (TestConfiguration)c;
                       config.Target.Enumerate();
                   })
                   select new TestConfiguration
                   {
                       TestName = "Enumerate",
                       TargetImplementationType = implementationType,
                       Identifier = string.Format("{0}", implementationType.GetFriendlyName()),
                       Size = size,
                       Prepare = prepare,
                       Run = run,
                       IsReusable = true,
                       Divider = size
                   };
        }

		private void PrepareAddRandom(int size, Type type, TestConfiguration config)
		{
			config.RandomLongs = new long[size];
			config.RandomDateTimes = new DateTime[size];
			var permutation = Randomize(GetZeroToN(size)).ToArray();

			for (var i = 0; i < size; i++)
			{
				config.RandomLongs[i] = permutation[i];
				config.RandomDateTimes[i] = new DateTime(_offset + permutation[i]);
			}
		}

        private void PrepareAddSorted(int size, Type type, TestConfiguration config)
        {
            config.RandomLongs = new long[size];
            config.RandomDateTimes = new DateTime[size];

            for (var i = 0; i < size; i++)
            {
                config.RandomLongs[i] = i;
                config.RandomDateTimes[i] = new DateTime(_offset + i);
            }
        }

		private void PrepareRemove(int size, Type type, TestConfiguration config)
		{
			// Do not generate in random order to speed up Add operation (test preparation)
			PrepareSearch(size, type, config);

			// Regenerate a random order for removal:
			config.RandomLongs = new long[size];
			config.RandomDateTimes = new DateTime[size];
			var permutation = Randomize(GetZeroToN(size)).ToArray();

			for (var i = 0; i < size; i++)
			{
				config.RandomLongs[i] = permutation[i];
				config.RandomDateTimes[i] = new DateTime(_offset + permutation[i]);
			}
		}

		private void PrepareSearch(int size, Type type, TestConfiguration config)
		{
			// Do not generate in random order to speed up test preparation
			config.RandomLongs = new long[size];
			config.RandomDateTimes = new DateTime[size];
			config.Target = CreateTarget<DateTime, long>(type);
			for (var i = 0; i < size; i++)
			{
				config.RandomLongs[i] = i;
				config.RandomDateTimes[i] = new DateTime(_offset + i);
				config.Target.Add(new DateTime(_offset + i), i);
			}
		}

		private IEnumerable<int> GetZeroToN(int n)
		{
			for (var i = 0; i < n; i++)
			{
				yield return i;
			}
		}

		private IEnumerable<T> Randomize<T>(IEnumerable<T> longs)
		{
			return (from kvp in longs.Select(value => new KeyValuePair<int, T>(_random.Next(), value)).ToList()
			        orderby kvp.Key
			        select kvp.Value).ToArray();
		}

		public ISortedDictionary<TSorter, TValue> CreateTarget<TSorter, TValue>(Type type)
		{
			return (ISortedDictionary<TSorter, TValue>) type
				.GetConstructors().First(ci => !ci.GetParameters().Any()).Invoke(new object[0]);
		}
		#endregion
	}
}