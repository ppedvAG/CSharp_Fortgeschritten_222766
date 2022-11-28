namespace Sprachfeatures
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
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