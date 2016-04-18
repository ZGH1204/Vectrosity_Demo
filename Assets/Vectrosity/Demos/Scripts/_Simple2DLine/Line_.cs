using UnityEngine;
using System.Collections;
using Vectrosity;

public class Line_ : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Vector2[] linePoints = { new Vector2 (0, Random.Range (0, Screen.height)),             // ...one on the left side of the screen somewhere
                      new Vector2 (Screen.width - 1, Random.Range (0, Screen.height)) }; // ...and one on the right

        // Make a VectorLine object using the above points and the default material, with a width of 2 pixels
        VectorLine line = new VectorLine ("Line", linePoints, null, 2.0f);

        // Draw the line
        line.Draw ();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
