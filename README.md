# SortedSplitList 

## Introduction
This solution contains performance tests for various sorted data structures.
The goal of this library is to measure and compare performance of these implementations
The name comes from the original name of the first data structure under test.

Some implementations may reside (copied) here with source while others just referred as NuGet package or are part of the standard .NET Framework

## Method

Currently the main focus is on the Add/Remove/Search/'Indexed Access' operations.
As the implementations under tests does not implement any common interface a simplistic test interface is defined to make testing possible.
Access to the original functionality happens via a lightweight wrappers.

For performance testing and visualizing results this project uses NunitBenchmarker (https://github.com/Orcomp/NUnitBenchmarker). Start with PerformanceTest classes, run the tests just as you would run any ordinary unit test.


## Implementations under test

- **SortedSplitList** - This code was taken from article: "SortedSplitList - An Indexing Algorithm in C#" by Aurelien Boudoux. See code for more details
- **SortedList** - Taken from Orcomp other internal project 'Stockpile' 
- **SortedList** - .NET Framework 
- **C5 SortedArray** - C5's sorted array


## Planned

- More operations to test not just Add/Remove/Search/'Indexed Access'. Candiates are: Enumerate, ???
- More implementations to test

