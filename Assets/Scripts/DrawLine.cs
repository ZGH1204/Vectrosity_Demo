using UnityEngine;
using System.Collections;
using Vectrosity;

public class DrawLine : MonoBehaviour {


    public Transform trans1;
    public Transform trans2;

    void Start () {

        ///
        VectorLine.SetLine (Color.green, new Vector2 (0, 0), new Vector2 (100, 100));

        ///
        VectorLine.SetLine (Color.red, trans1.position, trans2.position);

        ///
        Vector2[] linePoints = { new Vector2(0, Random.Range(0, Screen.height)),
                                 new Vector2(Screen.width, Random.Range(0, Screen.height)),
                                 new Vector2(Screen.width, Random.Range(0, Screen.height))
        };
        VectorLine line = new VectorLine ("line001", linePoints, null, 1.0f);
        line.Draw ();

        


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
