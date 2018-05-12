using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool locked;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 getPosition()
    {
        return GetComponent<Transform>().position;
    }

    public void open()
    {
        Destroy(GetComponent<Collider>());
        GetComponent<Renderer>().enabled = false;
    }
}
