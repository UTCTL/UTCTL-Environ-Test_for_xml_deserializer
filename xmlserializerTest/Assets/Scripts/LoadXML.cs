using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Container = ActionNodeContainer;
using System.IO; 


public class LoadXML : MonoBehaviour {

	void Start()
	{
		//ActionNodeContainer container = new ActionNodeContainer();
		ActionNodeContainer nodeCollection = Container.DeserializeXml(Path.Combine(Application.dataPath, "action_node_collection.xml"));
		Debug.Log ("nodeCollection succesfully created");
		nodeCollection.SetCount ();
		Debug.Log ("SetCount successfullly called");
		Debug.Log ("Number of elements in nodeCollection: " + nodeCollection.Count);

		ActionNode testNode = nodeCollection.actionNodes [0];
		Debug.Log ("Isolated the first node");
		testNode.printInfo ();

	}

}
