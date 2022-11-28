using System.Collections;

namespace Sprachfeatures;

internal class Program
{
	static void Main(string[] args)
	{
		string input = "lukas";
		string title = char.ToUpper(input[0]) + input[1..].ToLower();

		string interpolated = $"{input} {2 * 2}"; //Code in string schreiben

		string verbatim = @"\n\t"; //Interpretiert alles genau so wie geschrieben
		Console.WriteLine(verbatim);

		string pfad = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_11_28"; //Besonders nützlich für Pfade

		string x = null;

		List<string> list; //Hat IEnumerable
		Array arr;
		Dictionary<string, int> dict;

		Test t = new Test();
		foreach (var o in t)
		{

		}

		//Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
		Dictionary<string, int> keyValuePairs = new(); //Typ wird von der linken Seite angenommen
		var kvp = new Dictionary<string, int>();
		string s = new("Test"); //Target-Typed New mit Konstruktor

		Person p = new Person(0, "Lukas", 24, null); //Record wie normale Klasse verwenden
		(int id, string vn, int alter) = p; //Record generiert auch Deconstruct Methode

		Stopwatch sw;

		//if ({ p.vorgesetzter.vorgesetzter.vorgesetzter }) Statt {{{}}} einfach mit Punkten arbeiten

		//string abc = $"Das ist {x
		//	} ein string"; erst möglich mit C# 11


	}

	string Test()
	{
		int x = 0;
		switch (x) //Strg + . für direkte Konvertierung
		{
			case 0: return "Null";
			case 1: return "Eins";
			default: return "Andere Zahl";
		}
	}

	string Test2(string x1,string x2)
	{
		return (x1, x2) switch
		{
			("X", "Y") => "Test",
			_ => "" //Ein _ hier ausreichend
		};
	}
}

public class Test : IEnumerable
{
	private readonly List<int> Ints = new();

	private List<int> Ints2 { get; init; } = new(); //Selbiges Verhalten wie oben

	public Test()
	{
		Ints = new();
		Ints2 = new();
	}

	public IEnumerator GetEnumerator()
	{
		//Ints = new(); nicht möglich
		//Ints2 = new(); auch nicht möglich weil init
		return Ints.GetEnumerator();
	}
}

public record Person(int ID, string Vorname, int Alter, Person vorgesetzter) //Record kann auch geöffnet werden -> eigenen Code hinzufügen
{
	public void Test() { }
}