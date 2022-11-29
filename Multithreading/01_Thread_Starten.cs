namespace Multithreading;

internal class _01_Thread_Starten
{
	static void Main(string[] args)
	{
		Thread t = new Thread(Run); //Funktionszeiger
		t.Start(); //Thread starten

		//Ab hier parallel

		t.Join(); //Ab hier wieder sequentiell

		for (int i = 0; i < 100; i++)
			Console.WriteLine($"Main Thread: {i}");
	}

	static void Run()
	{
		for (int i = 0; i < 100; i++)
			Console.WriteLine($"Side Thread: {i}");
	}
}