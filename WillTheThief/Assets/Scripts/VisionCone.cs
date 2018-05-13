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
        triangles = tris.ToArray();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(GetComponent<MeshFilter>().mesh.vertices.GetLength(0) > 0)
        //transform.position = GetComponent<MeshFilter>().mesh.vertices[0];
        makeVerts();
    }

    public void updateTriangles(Vector3[] impPoints)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
       // mesh.Clear();

        mesh.vertices = impPoints;

        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void makeVerts()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.black);

        var layerMask = 1 << 9;
        layerMask = ~layerMask;

        List<Vector3> verticies = new List<Vector3>();
        verticies.Add(new Vector3(0.0f, 0.0f, 0.0f));

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

            verticies[i + 1] = Quaternion.AngleAxis(90, transform.up) * verticies[i+1];
        }


        updateTriangles(verticies.ToArray());
    }
}
