using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCCar : MonoBehaviour {

    public bool control;

	// Use this for initialization
	void Start () {
        control = false;
    }
	
	// Update is called once per frame
	void Update () {

    }


    void FixedUpdate()
    {

        if (control)
        {
            movement();
        }
    }

    public Vector3 getPosition()
    {
        return GetComponent<Rigidbody>().position;
    }

    void movement()
    {
        float rspeed = 25.0f;
        float speed = 5.0f;
        float x = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * x * rspeed);
        float z = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * z * speed);

        /*
        GetComponent<Rigidbody>().position += z * transform.forward * Time.deltaTime * speed;
        GetComponent<Rigidbody>().position += x * transform.right * Time.deltaTime * speed;



        float speed = 2.5f;
        float step = speed * Time.deltaTime;
        Vector3 targetDir = destination - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (newDir == oldDir)
        {
            mode = 0;
        }

        oldDir = newDir;*/

    }
}
