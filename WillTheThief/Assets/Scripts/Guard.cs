using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public PatrolPath patrolRoute;
    private Vector3 destination;
    private int currDestPos;
    private float distToNode;

    private int mode;
    private int timer;

    private Vector3 oldDir;

	// Use this for initialization
	void Start () {
        currDestPos = patrolRoute.numOfNodes() - 1;
        destination = patrolRoute.nextNode(currDestPos);
        currDestPos = (currDestPos + 1) % patrolRoute.numOfNodes();
        distToNode = 0;
        mode = 0;
        timer = 0;
        oldDir = destination - transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (mode == 0) //move to destination
        {
            float speed = 5.0f;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        } else if (mode == 1) //turning
        {
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

            oldDir = newDir;

        } else if (mode == 2) //paused (mags)
        {
            timer--;
            if (timer <= 0) mode = 1;
        }
    }

    void LateUpdate()
    {
        distToNode = (Mathf.Abs(destination.x - transform.position.x) + Mathf.Abs(destination.y - transform.position.y) + Mathf.Abs(destination.z - transform.position.z));
        if (distToNode <= 1.0f) // really close
        {
            destination = patrolRoute.nextNode(currDestPos);
            currDestPos = (currDestPos + 1) % patrolRoute.numOfNodes();
            mode = 1;
        }
    }
}
