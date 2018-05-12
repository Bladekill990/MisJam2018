using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour {

    public List<PathNode> nodes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 nextNode(Vector3 currentLoc)
    {
        //find current loc
        int pos = posInArray(currentLoc);

        if ((pos + 1) % nodes.Count == 0) pos = 0; else pos = pos + 1;

        return nodes.ToArray()[pos].getPos();
    }

    public Vector3 nextNode(int currentLoc)
    {
        int pos = currentLoc;
        if ((pos + 1) % nodes.Count == 0) pos = 0; else pos = pos + 1;

        return nodes.ToArray()[pos].getPos();
    }

    public int posInArray(Vector3 currentLoc)
    {
        int pos = -1;
        float gap = 1000000;
        PathNode[] nodeArray = nodes.ToArray();
        for (int i = 0; i < nodes.Count; i++)
        {
            float tgap = PathNode.distanceBetween(nodeArray[i], currentLoc);
            if (tgap < gap)
            {
                gap = tgap;
                pos = i;
            }
        }

        return pos;
    }

    public int numOfNodes()
    {
        return nodes.Count;
    }
}
