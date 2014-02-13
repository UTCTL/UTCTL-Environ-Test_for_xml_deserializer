using UnityEngine;
using System.Collections;
using Container = ActionNodeContainer;
using System.IO; 

public class LoadXML : MonoBehaviour {

	void Start()
	{
		//ActionNodeContainer container = new ActionNodeContainer();
		ActionNodeContainer nodeCollection = Container.DeserializeXml(Path.Combine(Application.dataPath, "action_node_collection.xml"));
	}

}
