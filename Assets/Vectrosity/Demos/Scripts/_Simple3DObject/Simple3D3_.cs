using UnityEngine;
using System.Collections;
using Vectrosity;

public class Simple3D3_ : MonoBehaviour {

    public Material lineMaterial;
    

    void Start () {

        Vector3 point1 = new Vector3 (-0.5f, 0.5f, -0.5f);
        Vector3 point2 = new Vector3 (-0.5f, 0.5f, 0.5f);
        Vector3 point3 = new Vector3 (0.5f, 0.5f, 0.5f);
        Vector3 point4 = new Vector3 (0.5f, 0.5f, -0.5f);
        Vector3 point5 = new Vector3 (-0.5f, -0.5f, -0.5f);
        Vector3 point6 = new Vector3 (-0.5f, -0.5f, 0.5f);
        Vector3 point7 = new Vector3 (0.5f, -0.5f, 0.5f);
        Vector3 point8 = new Vector3 (0.5f, -0.5f, -0.5f);

        Vector3[] cubePoints = {
           point6,
           point7,
           point2,
           point6,
           point7,
           point3,
           point3,
           point2,
           point1,
           point2,
           point3,
           point4,
           point4,
           point1,
           point5,
           point1,
           point4,
           point8,
           point8,
           point5,
           point6,
           point5,
           point8,
           point7
        };

        var line = new VectorLine ("Cube", cubePoints, lineMaterial, 2.0f);

        // "false" is added at the end, so that the cube mesh is not replaced by an invisible bounds mesh
        VectorManager.useDraw3D = true;

        /*
        false:
            The optional makeBounds by default creates an invisible bounds mesh for the gameObject’s mesh filter, so
            that OnBecameInvisible and OnBecameInvisible will still work, which allows optimizations for
            Visibility.Dynamic and Visibility.Static. If set to false, then the gameObject’s mesh is not replaced by a
            bounds mesh. One bounds mesh is created for each VectorLine name, so VectorLines that share a name will
            also share a bounds mesh.
        */
        VectorManager.ObjectSetup (gameObject, line, Visibility.Dynamic, Brightness.None, false);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
