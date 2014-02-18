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
	
	[XmlArray("effects")]
	[XmlArrayItem("Effect")]
	public List<Effect> effects = new List<Effect>();
	
	[XmlArray("costs")]
	[XmlArrayItem("Cost")]
	public List<Cost> costs = new List<Cost>();

	public bool sellable;

	// probability?

	public void printInfo()
	{
		Debug.Log ("title: " + title);
		Debug.Log ("text: " + text);
		Debug.Log ("reference_url: " + reference_url);
		Debug.Log ("img: " + img + "\tis img equal to emptystring " + (img == ""));
		Debug.Log ("category: " + category);
		Debug.Log ("subcategory: " + subcategory);
		Debug.Log ("model_name: " + model_name);
		Debug.Log ("region: " + region);
		Debug.Log ("effects: " + effects);

		foreach (Effect e in effects)
		{
			Debug.Log ("\t\tEFFECT: type: " + e.type + " duration: " + e.duration + " area: " + e.area + " amount: " + e.amount);
		}

		Debug.Log ("costs: " + costs);

		foreach (Cost c in costs)
		{
			Debug.Log ("\t\tCOST: type: " + c.type + " duration: " + c.duration + " amount: " + c.amount);
			foreach (Factor f in c.factors)
			{
				Debug.Log("\t\t\tfactor type: " + f.type);
			}
		}
		Debug.Log ("sellable: " + sellable);
	}
}

public class Effect 
{
	[XmlAttribute("type")]
	public string type;
	[XmlAttribute("duration")]
	public int duration;
	[XmlAttribute("area")]
	public string area;
	[XmlAttribute("amount")]
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
	
	[XmlArray("factors")]
	[XmlArrayItem("Factor")]
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