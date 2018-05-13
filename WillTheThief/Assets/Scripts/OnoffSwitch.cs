using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnoffSwitch : MonoBehaviour {

    public RCCar rckar;
    public bool pressed;

	// Use this for initialization
	void Start () {
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
        pressed = false;

        Vector3 loc = rckar.getPosition();
        Vector3 myLoc = transform.position;
        if ((Mathf.Abs(loc.x - myLoc.x) + Mathf.Abs(loc.y - myLoc.y) + Mathf.Abs(loc.z - myLoc.z)) <= 1.5f)
        {
            pressed = true;
        }
	}
}
