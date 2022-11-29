using static System.Environment;
using static System.Text.Json.JsonElement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisierung;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//StreamWriterReader();

		//SystemJson();

		//NewtonsoftJson();

		//Xml();

		//Binary();
	}

	public static void StreamWriterReader()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		using (StreamWriter sw = new StreamWriter(filePath) { AutoFlush = true }) //Stream öffnen zu Pfad, AutoFlush: Nach jedem WriteLine in das File schreiben
		{
			sw.WriteLine("Test1"); //Stream füllen
			sw.WriteLine("Test2"); //Stream füllen
			sw.WriteLine("Test3"); //Stream füllen
			sw.Flush(); //Streaminhalt in das File schreiben
		}

		using StreamReader sr = new StreamReader(filePath);

		List<string> allLines = new();
		string currentLine = sr.ReadLine();
		allLines.Add(currentLine);
		while (!sr.EndOfStream) //File Zeile für Zeile einlesen
		{
			currentLine = sr.ReadLine();
			allLines.Add(currentLine);
		}

		sr.BaseStream.Position = 0; //Stream auf Position 0 zurücksetzen

		string str = sr.ReadToEnd(); //Alles einlesen
		List<string> lines = str.Split(Environment.NewLine).ToList(); //Aus gesamtem string eine Liste von Zeilen machen
	}

	public static void SystemJson()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//JsonSerializerOptions options = new(); //Optionen angeben beim Speichern/Lesen von Json
		//options.WriteIndented = true; //Json schön schreiben

		//string json = JsonSerializer.Serialize(fahrzeuge, options); //JsonSerializer: Klasse zum Umwandeln von Objekten <-> Json
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] readFzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson, options); //Deserialisierung kann in einen beliebigen Listentypen passieren

		//JsonDocument doc = JsonDocument.Parse(json); //Dokument anlegen um es einzeln durchzugehen/anzuschauen
		//ArrayEnumerator ae = doc.RootElement.EnumerateArray(); //JsonDocument iterierbar machen
		//foreach (JsonElement je in ae) //Jedes Fahrzeug ist ein Json Element
		//{
		//	int maxV = je.GetProperty("MaxV").GetInt32(); //Maximalgeschwindigkeit aus jedem Json entnehmen
		//	Console.WriteLine(maxV);

		//	Fahrzeug f = je.Deserialize<Fahrzeug>(); //Deserialize Methode auf dem JsonElement um es zu einem bestimmten Typ umzuwandeln
		//}


		//string readJson = File.ReadAllText(filePath);
		//JsonDocument doc = JsonDocument.Parse(readJson);
		//foreach (JsonElement e in doc.RootElement.EnumerateArray())
		//{
		//	Console.WriteLine(e.GetProperty("city").GetProperty("country").GetString());
		//}
	}

	public static void NewtonsoftJson()
	{
		//string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		//string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		//string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		//List<Fahrzeug> fahrzeuge = new()
		//{
		//	new Fahrzeug(0, 251, FahrzeugMarke.BMW),
		//	new Fahrzeug(1, 274, FahrzeugMarke.BMW),
		//	new Fahrzeug(2, 146, FahrzeugMarke.BMW),
		//	new Fahrzeug(3, 208, FahrzeugMarke.Audi),
		//	new Fahrzeug(4, 189, FahrzeugMarke.Audi),
		//	new Fahrzeug(5, 133, FahrzeugMarke.VW),
		//	new Fahrzeug(6, 253, FahrzeugMarke.VW),
		//	new Fahrzeug(7, 304, FahrzeugMarke.BMW),
		//	new Fahrzeug(8, 151, FahrzeugMarke.VW),
		//	new Fahrzeug(9, 250, FahrzeugMarke.VW),
		//	new Fahrzeug(10, 217, FahrzeugMarke.Audi),
		//	new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		//};

		//JsonSerializerSettings settings = new();
		//settings.Formatting = Formatting.Indented;
		//settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

		//string json = JsonConvert.SerializeObject(fahrzeuge, settings); //JsonSerializer: Klasse zum Umwandeln von Objekten <-> Json
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson, settings); //Deserialisierung kann in einen beliebigen Listentypen passieren

		//JToken jt = JToken.Parse(readJson); //JToken statt JsonDocument
		//foreach (JToken element in jt) //JToken durchgehen
		//{
		//	int maxV = element["MaxV"].Value<int>(); //Selbiges wie je.GetProperty("MaxV").GetInt32();
		//	Console.WriteLine(maxV);

		//	Fahrzeug f = JsonConvert.DeserializeObject<Fahrzeug>(element.ToString()); //Äquivalent zu je.Deserialize<Fahrzeug>();
		//}
	}

	public static void Xml()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType()); //XmlSerializer: braucht ein Objekt und einen Typen zum serialisieren
		using (FileStream fs = new(filePath, FileMode.Create)) //Xml Serialisierung braucht immer direkt ein File
			xml.Serialize(fs, fahrzeuge);

		using (FileStream fs = new(filePath, FileMode.Open))
		{
			List<Fahrzeug> readFzg = xml.Deserialize(fs) as List<Fahrzeug>; //Beim Lesen gibt es keine Methode mit Generic sondern hier muss gecastet werden
		}

		XmlDocument doc = new XmlDocument();
		string readXml = File.ReadAllText(filePath);
		doc.LoadXml(readXml);
		foreach (XmlNode xmlNode in doc.ChildNodes[1].OfType<XmlNode>())
		{
			Console.WriteLine(xmlNode.ChildNodes.OfType<XmlNode>().First(e => e.Name == "MaxV").InnerText);
		}
	}

	public static void Binary()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		BinaryFormatter formatter = new BinaryFormatter();
		using (FileStream fs = new(filePath, FileMode.Create))
			formatter.Serialize(fs, fahrzeuge);

		using (FileStream fs = new(filePath, FileMode.Open))
		{
			List<Fahrzeug> readFzg = formatter.Deserialize(fs) as List<Fahrzeug>;
		}
	}
}

[Serializable]
public class Fahrzeug
{
	//[JsonIgnore] //Ignoriere dieses Feld beim Json Serialisieren (bei beiden Frameworks)
	[JsonProperty("Identifier")] //Feld beim Serialisieren einen anderen Namen geben (Newtonsoft)
	//[JsonPropertyName("Identifier")]  //Feld beim Serialisieren einen anderen Namen geben (System.Text)
	public int ID { get; set; }

	[field: NonSerialized] //BinaryIgnore
	public int MaxV { get; set; }

	[XmlIgnore]
	[XmlElement("Marke")]
	[XmlAttribute] //Feld als Attribut statt als eigenes Xml Element speichern
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int ID, int MaxV, FahrzeugMarke Marke)
	{
		this.ID = ID;
		this.MaxV = MaxV;
		this.Marke = Marke;
	}

	public Fahrzeug()
	{
		//Für Xml Serialisierung
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }