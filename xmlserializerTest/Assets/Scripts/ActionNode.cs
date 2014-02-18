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
	[XmlArray("regions")]
	[XmlArrayItem("region")]
	public List<Region> regions = new List<Region>();
	
	[XmlArray("effects")]
	[XmlArrayItem("effect")]
	public List<Effect> effects = new List<Effect>();
	
	[XmlArray("costs")]
	[XmlArrayItem("cost")]
	public List<Cost> costs = new List<Cost>();

	public bool sellable;

	// probability?

	public void printInfo()
	{
		Debug.Log ("-------PRINTING NODE INFO-------\n");
		Debug.Log ("title: " + title + "\n");
		Debug.Log ("text: " + text + "\n");
		Debug.Log ("reference_url: " + reference_url + "\n");
		Debug.Log ("img: " + img + "\tis img equal to emptystring " + (img == "") + "\n");
		Debug.Log ("category: " + category + "\n");
		Debug.Log ("subcategory: " + subcategory + "\n");
		Debug.Log ("model_name: " + model_name + "\n");
		Debug.Log ("region: " + regions + "\n");

		foreach (Region r in regions)
		{
			Debug.Log("\t\tREGION: " + r.id + "\n");
		}

		Debug.Log ("effects: " + effects + "\n");
		foreach (Effect e in effects)
		{
			Debug.Log ("\t\tEFFECT: id: " + e.id + " duration: " + e.duration + " area: " + e.area + " amount: " + e.amount + "\n");
		}

		Debug.Log ("costs: " + costs + "\n");

		foreach (Cost c in costs)
		{
			Debug.Log ("\t\tCOST: id: " + c.id + " duration: " + c.duration + " amount: " + c.amount + "\n");
			foreach (Condition co in c.conditions)
			{
				Debug.Log("\t\t\tcondition id: " + co.id + "\n");
			}
		}
		Debug.Log ("sellable: " + sellable + "\n");
		Debug.Log ("-------END NODE INFO-------" + "\n");
	}
}

public class Region
{
	[XmlAttribute("id")]
	public int id;
}

public class Effect 
{
	[XmlAttribute("id")]
	public int id;
	[XmlAttribute("duration")]
	public int duration;
	[XmlAttribute("area")]
	public string area;
	[XmlAttribute("amount")]
	public int amount;
}

public class Cost 
{
	[XmlAttribute]
	public int id;
	[XmlAttribute]
	public int duration;
	[XmlAttribute]
	public int amount;
	
	[XmlArray("conditions")]
	[XmlArrayItem("condition")]
	public List<Condition> conditions = new List<Condition>();
}

public class Condition
{
	[XmlAttribute]
	public int id;
	[XmlAttribute]
	public int duration;
	[XmlAttribute]
	public int amount;
}