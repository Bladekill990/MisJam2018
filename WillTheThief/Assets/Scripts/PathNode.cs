using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public Vector3 getPos()
    {
        return transform.position;
    }

    public static float distanceBetween(PathNode a, Vector3 b)
    {
        return (Mathf.Abs(a.getPos().x - b.x) + Mathf.Abs(a.getPos().y - b.y) + Mathf.Abs(a.getPos().z - b.z));
    }
}
