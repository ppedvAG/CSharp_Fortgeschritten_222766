namespace LinqErweiterungsmethoden;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elementen
		//(5, 20) -> Start bei 5, 20 Elemente -> 5-24
		List<int> ints = Enumerable.Range(0, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());

		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(ints.FirstOrDefault()); //null wenn Liste leer

		Console.WriteLine(ints.Last()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(ints.LastOrDefault()); //null wenn Liste leer

		Console.WriteLine(ints.Single(e => e == 2)); //Einziges Element mit Bedingung, Exception wenn leer oder mehr als ein Element
		Console.WriteLine(ints.SingleOrDefault(e => e == 2)); //Einziges Element mit Bedingung, null wenn leer und Exception wenn mehr als ein Element
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs mit Foreach
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnlich Schreibweise (alt)
		List<Fahrzeug> bmws = (from f in fahrzeuge
							   where f.Marke == FahrzeugMarke.BMW
							   select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		//Alle Fahrzeuge mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200);

		//Alle VWs mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200 && e.Marke == FahrzeugMarke.VW);

		//Autos sortieren nach Automarke
		fahrzeuge.OrderBy(e => e.Marke);
		fahrzeuge.OrderByDescending(e => e.MaxV);

		//Nach mehreren Kriterien sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);

		//Alle Marken extrahieren
		fahrzeuge.Select(e => e.Marke).ToList();

		//Marken eindeutig machen
		fahrzeuge.Select(e => e.Marke).Distinct();

		//Fahrzeuge nach Marke filtern
		fahrzeuge.DistinctBy(e => e.Marke);

		//Fahren alle Fahrzeuge schneller als 200km/h?
		fahrzeuge.All(e => e.MaxV > 200);

		//Fährt mindestens eines unserer Fahrzeuge mindestens 200km/h?
		fahrzeuge.Any(e => e.MaxV > 200);

		//Gibt es ein Element in der Liste?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Zähle die Anzahl an VWs
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW);

		//Die kleinste Geschwindigkeit
		fahrzeuge.Min(e => e.MaxV);

		//Das Fahrzeug mit der kleinsten Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV);

		//Teilt die Liste in X große Arrays auf (hier 5er Teile)
		fahrzeuge.Chunk(5);

		//Überspringe die ersten X Elemente und nimm Y Elemente
		fahrzeuge.Skip(3).Take(5);

		//Dreht die Liste um und gibt eine neue Liste
		fahrzeuge.Reverse<Fahrzeug>();

		//IDs zu Fahrzeugen hinzufügen
		fahrzeuge.Zip(Enumerable.Range(0, fahrzeuge.Count));

		//Dictionary erstellen mit ID als Key und Fahrzeug als Value
		fahrzeuge.Zip(Enumerable.Range(0, fahrzeuge.Count)).ToDictionary(e => e.Second, e => e.First);

		//Liste nach einem Selector gruppieren (Audi Gruppe, BMW Gruppe, VW Gruppe)
		fahrzeuge.GroupBy(e => e.Marke);

		//mit ToList() auf eine einzelne Gruppe kann ich die Fahrzeuge aus der Gruppe entnehmen
		fahrzeuge.GroupBy(e => e.Marke).ToList()[0].ToList();

		//Wendet für jedes Element der Liste eine Funktion an, hat einen integrierten Aggregator
		int aggregator = fahrzeuge.Aggregate(0, (agg, fzg) => agg + fzg.MaxV);

		string ausgabe = fahrzeuge.Aggregate(string.Empty, (agg, fzg) =>
			agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.\n");
		Console.WriteLine(ausgabe);

		#region Erweiterungsmethoden
		int x = 83274;
		Console.WriteLine(x.Quersumme());
		Console.WriteLine(283974.Quersumme());

		fahrzeuge.Shuffle();
		#endregion
	}
}

public record Fahrzeug(int MaxV, FahrzeugMarke Marke);

public enum FahrzeugMarke
{
	Audi, BMW, VW
}