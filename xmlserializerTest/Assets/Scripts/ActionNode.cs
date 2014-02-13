using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode
{
	// Store all the xml tag info here

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

	[XmlElement("effects")]
	public List<Effect> effects = new List<Effect>();

	[XmlElement("costs")]
	public List<Cost> costs = new List<Cost>();

	public bool sellable;

	// probability?
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

	[XmlElement("factors")]
	public List<Factor> factors = new List<Factor>();
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