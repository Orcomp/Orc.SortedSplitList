// -------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTest.cs" company="Orcomp development team">
//   Copyright (c) 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.SortedSplitList.PerformanceTest
{
	using NUnit.Framework;
	using NUnitBenchmarker;

	[TestFixture]
	public class PerformanceTest
	{
		[TestFixtureSetUp]
		public void TestFixture()
		{
			Benchmarker.Init();
		}

		[Test, TestCaseSource(typeof (PerformanceTestFactory), "AddRandomTestCases")]
		public void AddRandom(TestConfiguration config)
		{
			// About count = 1: There is no need to execute the tests multiple times
			// the test itself repeats the Add operation 'size' times. 
			// (the displayed time is for _one_ operation)
			config.Benchmark(config.TestName, config.Size, 1);
		}

        [Test, TestCaseSource(typeof(PerformanceTestFactory), "AddSortedTestCases")]
        public void AddSorted(TestConfiguration config)
        {
            // About count = 1: There is no need to execute the tests multiple times
            // the test itself repeats the Add operation 'size' times. 
            // (the displayed time is for _one_ operation)
            config.Benchmark(config.TestName, config.Size, 1);
        }

		[Test, TestCaseSource(typeof (PerformanceTestFactory), "RemoveTestCases")]
		public void Remove(TestConfiguration config)
		{
			// About count = 1: There is no need to execute the tests multiple times
			// the test itself repeats the Remove operation 'size' times. 
			// (the displayed time is for _one_ operation)
			config.Benchmark(config.TestName, config.Size, 1);
		}

		[Test, TestCaseSource(typeof (PerformanceTestFactory), "SearchTestCases")]
		public void Search(TestConfiguration config)
		{
			// About count = 1: There is no need to execute the tests multiple times
			// the test itself repeats the Search operation 'size' times. 
			// (the displayed time is for _one_ operation)
			config.Benchmark(config.TestName, config.Size, 1);
		}

        [Test, TestCaseSource(typeof(PerformanceTestFactory), "EnumerateTestCases")]
        public void Enumerate(TestConfiguration config)
        {
            // About count = 1: There is no need to execute the tests multiple times
            // the test itself repeats the Search operation 'size' times. 
            // (the displayed time is for _one_ operation)
            config.Benchmark(config.TestName, config.Size, 1);
        }
	}
}