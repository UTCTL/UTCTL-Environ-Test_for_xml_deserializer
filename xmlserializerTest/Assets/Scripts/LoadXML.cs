using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Container = ActionNodeContainer;
using System.IO; 


public class LoadXML : MonoBehaviour {

	// deserialize the xml into a list of action nodes at the start of the game
	void Start()
	{
		ActionNodeContainer nodeCollection = Container.DeserializeXml(Path.Combine(Application.dataPath, "action_node_collection.xml"));
		Debug.Log ("nodeCollection succesfully created");
		nodeCollection.SetCount ();
		Debug.Log ("SetCount successfullly called");
		Debug.Log ("Number of elements in nodeCollection: " + nodeCollection.Count);

		ActionNode testNode = nodeCollection.actionNodes [0]; // get the first node from the list of action nodes
		Debug.Log ("Isolated the first node");
		testNode.printInfo ();

	}

	// for random value use Random.value --> returns random num between 0 (incl) and 1 (incl)
}
