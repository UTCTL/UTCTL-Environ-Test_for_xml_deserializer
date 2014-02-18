using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System;
using UnityEngine;

[XmlRoot("action_nodes")]		// leave _ naming convention or switch to camelcase? 
public class ActionNodeContainer
{
	public int Count;
	public int SetCount()
	{
		Count = actionNodes.Count;
		return Count;
	}
	
	[XmlElement("action_node")]
	public List<ActionNode> actionNodes = new List<ActionNode>();
	//SetCount();

	//Debug.Log("List of action nodes created");
	
	public static ActionNodeContainer DeserializeXml(string path)
	{
		Debug.Log ("DeserializeXml called");
		XmlSerializer serializer = new XmlSerializer(typeof(ActionNodeContainer));
		FileStream fstream = new FileStream(path, FileMode.Open);

		using (fstream)
		{
			return serializer.Deserialize(fstream) as ActionNodeContainer;
		}
	}
}