using UnityEngine;
using System.Collections;
using Vectrosity;


public class UniformTexturedLine_ : MonoBehaviour {

    public Material lineMaterial;
    public float lineWidth = 8.0f;
    public float textureScale = 1.0f;
     
    void Start () {
        Vector2[] linePoints = { new Vector2 (0, Random.Range (0, Screen.height / 2)), new Vector2 (Screen.width - 1, Random.Range (0, Screen.height)) };
        VectorLine line = new VectorLine ("Line", linePoints, lineMaterial, lineWidth);
        line.textureScale = textureScale;
        line.Draw ();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
 