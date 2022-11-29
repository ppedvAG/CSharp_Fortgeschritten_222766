namespace Multithreading;

internal class _07_Mutex
{
	static void Main(string[] args)
	{
		Mutex m;
		if (Mutex.TryOpenExisting("07", out m)) //Hier ist meine Applikation bereits gestartet
		{
			Console.WriteLine("Applikation ist bereits gestartet");
			Environment.Exit(0);
		}
		else
		{
			m = new Mutex(true, "07");
		}

		Thread.Sleep(10000);

		//Am Ende der Applikation Mutex wieder freigeben
		m.ReleaseMutex();
	}
}
