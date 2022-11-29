using System.Diagnostics;

namespace Multitasking;

internal class ParallelForDemo
{
	static void Main(string[] args)
	{
		int[] durchgänge = { 1000, 10000, 50000, 100000, 250000, 500000, 1000000, 5000000, 10000000, 100000000 };

		foreach (int i in durchgänge)
		{
			Stopwatch sw = Stopwatch.StartNew();
			RegularFor(i);
			sw.Stop();
			Console.WriteLine($"For Durchgänge {i}: {sw.ElapsedMilliseconds}");

			Stopwatch sw2 = Stopwatch.StartNew();
			ParallelFor(i);
			sw2.Stop();
			Console.WriteLine($"Parallel For Durchgänge {i}: {sw2.ElapsedMilliseconds}");
		}

		/*
			For Durchgänge 1000: 0
			Parallel For Durchgänge 1000: 24
			For Durchgänge 10000: 1
			Parallel For Durchgänge 10000: 22
			For Durchgänge 50000: 6
			Parallel For Durchgänge 50000: 7
			For Durchgänge 100000: 13
			Parallel For Durchgänge 100000: 4
			For Durchgänge 250000: 40
			Parallel For Durchgänge 250000: 16
			For Durchgänge 500000: 86
			Parallel For Durchgänge 500000: 26
			For Durchgänge 1000000: 166
			Parallel For Durchgänge 1000000: 39
			For Durchgänge 5000000: 1840
			Parallel For Durchgänge 5000000: 543
			For Durchgänge 10000000: 2374
			Parallel For Durchgänge 10000000: 636
			For Durchgänge 100000000: 16718
			Parallel For Durchgänge 100000000: 7549
		 */
	}

	static void RegularFor(int iterations)
	{
		double[] erg = new double[iterations];
		for (int i = 0; i < iterations; i++)
			erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
	}

	static void ParallelFor(int iterations)
	{
		double[] erg = new double[iterations];
		//int i = 0; i < iterations; i++
		Parallel.For(0, iterations, i => erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100));
	}
}
