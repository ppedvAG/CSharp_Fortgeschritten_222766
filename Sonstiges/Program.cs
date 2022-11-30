using System.Collections;
using System.Text;

namespace Sonstiges;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		Console.WriteLine(w1 == w2);

		Zug z = new();
		z++;
		z++;
		z++;
		z++;

		foreach (Wagon w in z)
		{

		}

		Wagon w10 = z[2];
		w10 = z["Rot"];
		w10 = z[10, "Rot"];

		var x = z.wagons.Select(e => new { x = 10, Anz = e.AnzSitze, HC = e.GetHashCode() });
		Console.WriteLine(x.First().HC);

		StringBuilder sb = new();
		sb.Append("Test"); //wie string +
		sb.ToString(); //fertigen string nehmen

		System.Timers.Timer timer = new();
		timer.Elapsed += (sender, e) => Console.WriteLine("Intervall vergangen");
		timer.Interval = 1000;
		timer.Start();
		Console.ReadKey();
	}
}

public class Zug : IEnumerable
{
	public List<Wagon> wagons = new();

	public IEnumerator GetEnumerator()
	{
		return wagons.GetEnumerator();
	}

	public static Zug operator ++(Zug z1)
	{
		z1.wagons.Add(new());
		return z1;
	}

	public Wagon this[int i]
	{
		get => wagons[i];
		private set => wagons[i] = value;
	}

	public Wagon this[string farbe]
	{
		get => wagons.First(e => e.Farbe == farbe);
	}

	public Wagon this[int anz, string farbe]
	{
		get => wagons.First(e => e.AnzSitze == anz && e.Farbe == farbe);
	}
}

public class Wagon
{
	public int AnzSitze;

	public string Farbe;

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return w1.AnzSitze == w2.AnzSitze && w1.Farbe == w2.Farbe;
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return !(w1 == w2);
	}
}