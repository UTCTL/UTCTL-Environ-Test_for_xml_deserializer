using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Container = ActionNodeContainer;
using System.IO; 


public class LoadXML : MonoBehaviour {

	void Start()
	{
		ActionNodeContainer nodeCollection = Container.DeserializeXml(Path.Combine(Application.dataPath, "action_node_collection.xml"));
		Debug.Log ("nodeCollection succesfully created");
		nodeCollection.SetCount ();
		Debug.Log ("SetCount successfullly called");
		Debug.Log ("Number of elements in nodeCollection: " + nodeCollection.Count);

		ActionNode testNode = nodeCollection.actionNodes [0];
		Debug.Log ("Isolated the first node");
		testNode.printInfo ();

	}

	// for random value use Random.value --> returns random num between 0 (incl) and 1 (incl)
}
