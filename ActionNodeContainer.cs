using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("action_nodes")]		// leave _ naming convention or switch to camelcase? 
public class ActionNodeContainer
{
	// [XmlArray("action_nodes")]
	[XmlElement("action_node")]
	public List<ActionNode> actionNodes = new List<ActionNode>();
}