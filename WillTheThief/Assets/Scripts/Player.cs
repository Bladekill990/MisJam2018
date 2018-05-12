using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }


    void FixedUpdate()
    {
        movement();
    }

    public Vector3 getPosition()
    {
        return GetComponent<Rigidbody>().position;
    }

    void movement()
    {
        float speed = 5.0f;
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody>().position += z * transform.forward * Time.deltaTime * speed;
        GetComponent<Rigidbody>().position += x * transform.right * Time.deltaTime * speed;
    }


}
