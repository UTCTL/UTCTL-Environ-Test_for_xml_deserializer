using System.Xml;
using System.Xml.Serialization;
// for Container class

public class ActionNode
{
	// Store all the xml tag info here

	// xml tags as variables
	public string title; 
	public string text;
	public string reference_url;
	public string img;
	public int category;
	public int subcategory; 
	public string model_name;

	// regions affected?
	[XmlAttribute("id")]
	public int region;

	// how to deserialize multiple effects?
	[XmlElement("effect")]
	public Effect effect;

	// how to include multiple different costs?
	[XmlElement("cost")]
	public Cost cost;

	public bool sellable;


}

public class Effect 
{
	[XmlAttribute]
	public string type;
	[XmlAttribute]
	public int duration;
	[XmlAttribute]
	public string area;
	[XmlAttribute]
	public string amount; 	// has to be string because entered as "+10", maybe change to just "10" and then for negative "-10" for int type?
}

public class Cost 
{
	[XmlAttribute]
	public string type;
	[XmlAttribute]
	public int duration;
	[XmlAttribute]
	public int amount;

	// how to include multiple factors?
	[XmlElement("factor")]
	public Factor factor;
}

public class Factor
{
	[XmlAttribute]
	public string type;
	[XmlAttribute]
	public int duration;
	[XmlAttribute]
	public int amount;
}