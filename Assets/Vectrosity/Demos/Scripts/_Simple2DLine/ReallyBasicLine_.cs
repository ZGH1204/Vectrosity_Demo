using UnityEngine;
using System.Collections;
using Vectrosity;

public class ReallyBasicLine_ : MonoBehaviour {

	// Use this for initialization
	void Start () {
        VectorLine.SetLine (Color.white, new  Vector2 (0, 0), new  Vector2 (Screen.width - 1, Screen.height - 1));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
