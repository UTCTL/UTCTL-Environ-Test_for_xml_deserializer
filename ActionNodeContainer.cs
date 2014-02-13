using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("action_node_collection")]		// leave _ naming convention or switch to camelcase? 
public class ActionNodeContainer
{
	[XmlArray("action_nodes")]
	[XmlArrayItem("ActionNode")]
	public List<ActionNode> actionNodes = new List<ActionNode>();
}