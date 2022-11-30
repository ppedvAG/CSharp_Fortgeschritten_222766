using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		//Stopwatch sw = Stopwatch.StartNew();
		//Toast();
		//Geschirr();
		//Kaffee();
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //Sequentiell, 7s

		//Stopwatch sw = Stopwatch.StartNew();
		//Task.Run(Toast);
		//Task.Run(Geschirr);
		//Task.Run(Kaffee);
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //16ms, Main Thread läuft weiter

		//Stopwatch sw = Stopwatch.StartNew();
		//ToastTaskAsync(); //Methoden werden als Tasks ausgeführt weil sie als async gekennzeichnet sind
		//GeschirrTaskAsync();
		//KaffeeTaskAsync();
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //12ms, Main Thread läuft weiter

		//Wenn ich eine void Methode awaiten möchte muss ich diese mit Task als Rückgabewert kennzeichnen -> braucht kein return

		Stopwatch stopwatch = Stopwatch.StartNew();
		Task<Toast> toast = ToastAsync(); //Task starten
		Task<Tasse> tasse = TasseAsync(); //Task starten
		Tasse t = await tasse; //Warte bis die Tasse fertig ist
		Task<Kaffee> kaffee = KaffeeAsync(t); //KaffeeAsync(await tasse);
		Toast t2 = await toast; //Warte bis Toast fertig ist
		Kaffee k = await kaffee; //Warte bis Kaffee fertig ist
		stopwatch.Stop();
		Console.WriteLine(stopwatch.ElapsedMilliseconds); //4s
	}

	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Geschirr()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee zubereitet");
	}

	static async void ToastTaskAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
	}

	static async void GeschirrTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static async void KaffeeTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee zubereitet");
	}

	static async Task<Toast> ToastAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> TasseAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse hergerrichtet");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
		return new Kaffee();
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }