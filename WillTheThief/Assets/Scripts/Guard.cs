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

    public VisionCone vc;

    private bool rotCone;

    // Use this for initialization
    void Start () {
        currDestPos = patrolRoute.numOfNodes() - 1;
        destination = patrolRoute.nextNode(currDestPos);
        currDestPos = (currDestPos + 1) % patrolRoute.numOfNodes();
        distToNode = 0;
        mode = 0;
        timer = 0;
        oldDir = destination - transform.position;
        
        transform.LookAt(destination);

        vc.transform.up = transform.up;
        vc.transform.right = transform.right;
        vc.transform.forward = transform.forward;
        vc.transform.position = transform.position + new Vector3(0, 0.1f, 0);
        vc.transform.rotation = transform.rotation;
        vc.transform.eulerAngles = transform.eulerAngles;
        inCone();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (mode == 0) //move to destination
        {
            float speed = 4.0f;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            vc.transform.position = transform.position + new Vector3(0,0.01f,0);
        }
        else if (mode == 1) //turning
        {
            float speed = 2.5f;
            float step = speed * Time.deltaTime;
            Vector3 targetDir = destination - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);


            transform.rotation = Quaternion.LookRotation(newDir);
            vc.transform.rotation = transform.rotation;

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

        
        //vc.transform.rotation = transform.rotation;
        //vc.transform.forward = transform.forward;
        
        inCone();
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
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




    void inCone()
    {
        /*
        Debug.DrawRay(transform.position, transform.forward, Color.blue);

        var layerMask = 1 << 9;
        layerMask = ~layerMask;

        List<Vector3> verticies = new List<Vector3>();
        verticies.Add(new Vector3(0.0f,0.0f,0.0f));

        for (int i = 0; i<= 60; i++)
        {
            Vector3 rotation;
            rotation = Quaternion.AngleAxis(i-30, transform.up) * transform.forward;
            RaycastHit temp;

            if (Physics.SphereCast(transform.position, 0.1f, rotation, out temp, 12.0f, layerMask, QueryTriggerInteraction.Ignore))
                verticies.Add(temp.point - transform.position);
            else
                verticies.Add(12.0f * rotation);

            rotation = Quaternion.AngleAxis(i+30, transform.up) * transform.forward;
        }
        */

        //vc.updateTriangles(verticies.ToArray());
      
        
    }
}
