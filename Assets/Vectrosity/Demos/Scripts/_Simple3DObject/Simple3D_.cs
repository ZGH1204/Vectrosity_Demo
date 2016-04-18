using UnityEngine;
using Vectrosity;

public class Simple3D_ : MonoBehaviour
{
    public Material lineMaterial;
    private void Start ()
    {
        Vector3[] cubePoints = {
           new Vector3 (-0.5f, -0.5f, 0.5f),
           new Vector3 (0.5f, -0.5f, 0.5f),
           new Vector3 (-0.5f, 0.5f, 0.5f),
           new Vector3 (-0.5f, -0.5f, 0.5f),
           new Vector3 (0.5f, -0.5f, 0.5f),
           new Vector3 (0.5f, 0.5f, 0.5f),
           new Vector3 (0.5f, 0.5f, 0.5f),
           new Vector3 (-0.5f, 0.5f, 0.5f),
           new Vector3 (-0.5f, 0.5f, -0.5f),
           new Vector3 (-0.5f, 0.5f, 0.5f),
           new Vector3 (0.5f, 0.5f, 0.5f),
           new Vector3 (0.5f, 0.5f, -0.5f),
           new Vector3 (0.5f, 0.5f, -0.5f),
           new Vector3 (-0.5f, 0.5f, -0.5f),
           new Vector3 (-0.5f, -0.5f, -0.5f),
           new Vector3 (-0.5f, 0.5f, -0.5f),
           new Vector3 (0.5f, 0.5f, -0.5f),
           new Vector3 (0.5f, -0.5f, -0.5f),
           new Vector3 (0.5f, -0.5f, -0.5f),
           new Vector3 (-0.5f, -0.5f, -0.5f),
           new Vector3 (-0.5f, -0.5f, 0.5f),
           new Vector3 (-0.5f, -0.5f, -0.5f),
           new Vector3 (0.5f, -0.5f, -0.5f),
           new Vector3 (0.5f, -0.5f, 0.5f)
        };

        var line = new VectorLine ("Cube", cubePoints, lineMaterial, 2.0f);

        // Make this transform have the vector line object that's defined above
        // This object is a rigidbody, so the vector object will do exactly what this object does
        VectorManager.ObjectSetup (gameObject, line, Visibility.Dynamic, Brightness.None);
         
    }

    // Update is called once per frame
    private void Update ()
    {
    }
}