using UnityEngine;
using System.Collections;
using Vectrosity;

public class TextDemo_ : MonoBehaviour {

    public string text = "Vectrosity!";
    public int textSize = 40;
    private VectorLine textLine;

    public bool Rotate = false;

    void Start () {
        textLine = new VectorLine ("Text", new Vector2[2], null, 2.0f);
        textLine.color = Color.yellow;
        textLine.drawTransform = transform;
        textLine.MakeText (text, new Vector2 (Screen.width / 2 - text.Length * textSize / 2, Screen.height / 2 + textSize / 2), textSize);
        textLine.Draw ();
    }
	
	// Update is called once per frame
	void Update () {

        if (Rotate)
        {
            transform.RotateAround (new Vector2 (Screen.width / 2, Screen.height / 2), Vector3.forward, Time.deltaTime * 45.0f);
            transform.localScale = new Vector3 (1 + Mathf.Sin (Time.time * 3) * 0.3f, 1 + Mathf.Cos (Time.time * 3) * 0.3f, 1f);
            textLine.Draw ();
        }
    }
}
