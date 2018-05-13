﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour {

    public OnoffSwitch swch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(swch.pressed)
        {
            GetComponent<Renderer>().enabled = false;
        } else
        {
            GetComponent<Renderer>().enabled = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Renderer>().enabled)
        {
            if (other.gameObject.tag == "Player")
            {
                print("You zap died");
            }
        }
    }
}
