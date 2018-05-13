using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour {

    int[] triangles;

    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        List<int> tris = new List<int>();
        for (int i = 1; i < 59; i++)
        {
            tris.Add(0);
            tris.Add(i);
            tris.Add(i + 1);
        }
        tris.Add(0);
        tris.Add(1);
        tris.Add(60);
        tris.Add(0);
        tris.Add(60);
        tris.Add(59);
        triangles = tris.ToArray();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(GetComponent<MeshFilter>().mesh.vertices.GetLength(0) > 0)
        //transform.position = GetComponent<MeshFilter>().mesh.vertices[0];
        makeVerts();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("You died");
        } else
        {
            //
        }
    }

    public void updateTriangles(Vector3[] impPoints)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
       // mesh.Clear();

        mesh.vertices = impPoints;

        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
    }

    private void makeVerts()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.black);

        var layerMask = 1 << 9;
        layerMask = ~layerMask;

        List<Vector3> verticies = new List<Vector3>();
        verticies.Add(new Vector3(0.0f, 0.0f, 0.0f));

        float antiaxis = Vector3.Angle(new Vector3(1.0f,0.0f,0.0f), new Vector3(transform.forward.x, 0.0f, transform.forward.z));
        if ((transform.forward.x + transform.forward.z < 0)) antiaxis = -antiaxis;
        antiaxis = (antiaxis + 270) % 360;


        for (int i = 0; i <= 60; i++)
        {
            Vector3 rotation;
            rotation = Quaternion.AngleAxis(i - 30, transform.up) * transform.forward;
            //rotation = Quaternion.AngleAxis(i - 30, transform.up) * new Vector3(1.0f,0.0f,0.0f);
            RaycastHit temp;

            if (Physics.SphereCast(transform.position, 0.1f, rotation, out temp, 12.0f, layerMask, QueryTriggerInteraction.Ignore))
            {
                Vector3 tmppt = temp.point - transform.position;
                //tmppt.x = Mathf.Abs(tmppt.x);
                verticies.Add(tmppt);
                //verticies.Add(temp.point - transform.position);
            }
            else
            {
                //verticies.Add(12.0f *(Quaternion.AngleAxis(i - 30, transform.up) * new Vector3(1.0f,0.0f,0.0f)));
                verticies.Add(12.0f * rotation);
            }

            verticies[i + 1] = Quaternion.AngleAxis(antiaxis, transform.up) * verticies[i+1];
           // verticies[i + 1] = Quaternion.AngleAxis(-90, transform.up) * verticies[i + 1];
        }

        verticies.Add(new Vector3(0, 0.5f, 0));

        updateTriangles(verticies.ToArray());
    }
}
