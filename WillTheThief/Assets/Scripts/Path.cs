using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathNode
{
    private Vector3 pos;

    PathNode()
    {
        pos = new Vector3(0, 0, 0);
    }

    PathNode(Vector3 loc)
    {
        pos = new Vector3(loc.x, loc.y, loc.z);
    }

    public Vector3 getPos()
    {
        return pos;
    }

    public static float distanceBetween(PathNode a, PathNode b)
    {
        return (abs(a.getPos().x - b.getPos().x) + abs(a.getPos().y - b.getPos().y) + abs(a.getPos().z - b.getPos().z));
    }
}


public class Path {

    private List<PathNode> nodes;
    
	Path () {
        nodes = new List<PathNode>();
	}

    public void addNode(PathNode toAdd)
    {
        nodes.Add(toAdd);
    }

    public Vector3 nextNode(Vector3 currentLoc)
    {

        //find current loc
        int pos = posInArray(currentLoc);

        if ((pos + 1) % nodes.Count == 0) pos = 0; else pos = pos + 1;

        return nodeArray[pos].getPos();
    }

    public Vector3 nextNode(int currentLoc)
    {
        int pos = currentLoc;
        if ((pos + 1) % nodes.Count == 0) pos = 0; else pos = pos + 1;

        return nodes.ToArray()[pos].getPos();
    }

    public int posInArray(Vector3 currentLoc)
    {
        PathNode temp = new PathNode(currentLoc);
        int pos = -1;
        float gap = 1000000;
        PathNode[] nodeArray = nodes.ToArray();
        for (int i = 0; i < nodes.Count; i++)
        {
            float tgap = PathNode.distanceBetween(temp, nodeArray[i]);
            if (tgap < gap)
            {
                gap = tgap;
                pos = i;
            }
        }

        return pos;
    }

}
