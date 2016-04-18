using UnityEngine;
using System.Collections;
using Vectrosity;

public class Simple3D2_ : MonoBehaviour {

    public TextAsset vectorCube;
    public Material lineMaterial;

    void Start () {
        var cubePoints = VectorLine.BytesToVector3Array (vectorCube.bytes);
        var line = new VectorLine ("Cube", cubePoints, lineMaterial, 1.0f);
        VectorManager.ObjectSetup (gameObject, line, Visibility.Dynamic, Brightness.None);


    }

    // Update is called once per frame
    void Update () {
	
	}
}

//var vectorCube : TextAsset;
//var lineMaterial : Material;

//function Start ()
//{
//    // Make a Vector3 array from the data stored in the vectorCube text asset
//    // Try using different assets from the Vectors folder for different shapes (the collider will still be a cube though!)
//    var cubePoints = VectorLine.BytesToVector3Array (vectorCube.bytes);

//    // Make a line using the above points and material, with a width of 2 pixels
//    var line = new VectorLine ("Cube", cubePoints, lineMaterial, 2.0);

//    // Make this transform have the vector line object that's defined above
//    // This object is a rigidbody, so the vector object will do exactly what this object does
//    VectorManager.ObjectSetup (gameObject, line, Visibility.Dynamic, Brightness.None);
//}