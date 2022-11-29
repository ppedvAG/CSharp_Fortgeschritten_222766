namespace Multithreading;

internal class _02_ThreadMitParameter
{
	static void Main(string[] args)
	{
		ParameterizedThreadStart pt = new ParameterizedThreadStart(Run); //Funktionszeiger hier diesmal
		Thread t = new Thread(pt); //pt übergeben
		t.Start(200); //Parameter übergeben

		for (int i = 0; i < 100; i++)
			Console.WriteLine($"Main Thread: {i}");
	}

	static void Run(object o) //nur object möglich und Methode muss void
	{
		for (int i = 0; i < (int) o; i++)
			Console.WriteLine($"Side Thread: {i}");
	}
}
