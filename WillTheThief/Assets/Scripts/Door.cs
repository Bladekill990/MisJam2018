using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool locked;
    private int channeling;

	// Use this for initialization
	void Start () {
        channeling = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (channeling > 0)
        {
            channeling--;
            if (channeling == 0) {
                locked = !locked;
                open();
            }
        }
	}

    public Vector3 getPosition()
    {
        return GetComponent<Transform>().position;
    }

    public void open()
    {
        if (!locked)
        {
            Destroy(GetComponent<Collider>());
            GetComponent<Renderer>().enabled = false;
        } else
        {
            channeling = 60;
        }
    }

    public void cancelChannel()
    {
        channeling = 0;
    }
    public bool amChannel()
    {
        if(channeling > 0) return true;
        return false;
    }
}
