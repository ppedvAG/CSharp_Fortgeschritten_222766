namespace Sprachfeatures
{
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
}