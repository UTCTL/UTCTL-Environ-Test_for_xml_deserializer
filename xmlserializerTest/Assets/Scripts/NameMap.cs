using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System;
using UnityEngine;

public class NameMap
{	
	public Dictionary<int, string> region_map = new Dictionary<int, string>();
	public Dictionary<int, string> category_map = new Dictionary<int, string>();
	// Maps category ids to a dictionary of subcategories
	public Dictionary<int, Dictionary<int, string>> subcategory_map = new Dictionary<int, Dictionary<int, string>>();
	public Dictionary<int, string> effect_map = new Dictionary<int, string>();
	public Dictionary<int, string> cost_map = new Dictionary<int, string>();
	public Dictionary<int, string> condition_map = new Dictionary<int, string>();
	public Dictionary<int, string> area_map = new Dictionary<int, string>();
	
	//Debug.Log("List of action nodes created");
	public static Dictionary<int, string> getDict(string doc, string parent, string child)
	{
		Dictionary<int, string> ret = XElement.Parse(doc)
		.Elements(parent)
			.Elements(child)
				.ToDictionary(
					el => (int)el.Attribute("id"),
					el => (string)el.Attribute("name")
					);

		// Debugging only
		// TODO(vshan): remove
		foreach (var mem in ret) 
		{
			Debug.Log(child + " " + mem.Key + " added with value " + mem.Value);
		}
		return ret;
	}
	
	public static NameMap DeserializeXml(string path)
	{

		NameMap map = new NameMap();
		string doc = XDocument.Load(path).ToString();
		map.region_map = getDict (doc, "regions", "region");
		map.category_map = getDict (doc, "categories", "category");

		IEnumerable<XElement> categories = XElement.Parse (doc)
			.Elements ("categories")
				.Elements ("category");

		foreach (XElement e in categories) 
		{
			Dictionary<int, string> subcategories = e.Elements ("subcategories")
				.Elements ("subcategory")
				.ToDictionary(
					el => (int)el.Attribute ("id"),
					el => (string)el.Attribute ("name")
					);
			map.subcategory_map.Add ((int)e.Attribute("id"), subcategories);
		}

		// Debugging only
		// TODO(vshan): remove
		foreach (var mem in map.subcategory_map) 
		{
			Debug.Log("category " + mem.Key + " added with value ");
			foreach (var mem2 in mem.Value) {
				Debug.Log("\tsubcategory " + mem2.Key + " added with value " + mem2.Value);
			}
		}

		map.condition_map = getDict (doc, "conditions", "condition");
		map.area_map = getDict (doc, "areas", "area");
		map.effect_map = getDict (doc, "effects", "effect");
		map.cost_map = getDict (doc, "costs", "cost");


		return map;
	}
}