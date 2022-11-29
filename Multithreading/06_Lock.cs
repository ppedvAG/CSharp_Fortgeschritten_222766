namespace Multithreading;

internal class _06_Lock
{
	static int Counter = 0;

	static readonly object _lock = new object();

	static void Main(string[] args)
	{
		for (int i = 0; i < 1000; i++)
			new Thread(ZahlPlusPlus).Start();
	}

	static void ZahlPlusPlus(object o)
	{
		for (int i = 0; i < 100; i++)
		{
			lock (_lock) //Counter sperren damit nicht mehrere Threads gleichzeitig draufgreifen können
			{
				Counter++;
				Console.WriteLine(Counter); //Kein Lock/Monitor sollte Crash verursachen
			} //Lock wird geöffnet

			Monitor.Enter(_lock); //Monitor und Lock haben 1:1 den gleichen Code
			Counter++;
			Console.WriteLine(Counter);
			Monitor.Exit(_lock);
		}
	}
}
