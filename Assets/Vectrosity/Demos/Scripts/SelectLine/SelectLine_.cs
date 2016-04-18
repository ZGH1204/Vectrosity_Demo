using UnityEngine;
using Vectrosity;

public class SelectLine_ : MonoBehaviour
{
    public float lineThickness = 10.0f;
    public int extraThickness = 2;
    private VectorLine line;
    private bool wasSelected = false;
    private int index = 0;

    private void Start ()
    {
        line = new VectorLine ("SelectLine", new Vector2[10], null, lineThickness, LineType.Continuous, Joins.Fill);
        SetPoints ();
    }

    void SetPoints ()
    {
        for (var i = 0; i < line.points2.Count; i++)
        {
            line.points2[i] = new Vector2 (Random.Range (0, Screen.width), Random.Range (0, Screen.height - 20));
        }
        line.Draw ();
    }

    // Update is called once per frame
    private void Update ()
    {
        if (line.Selected (Input.mousePosition, extraThickness,out index))
        {
            if (!wasSelected)
            {    
                line.SetColor (Color.green);
                wasSelected = true;
            }
            if (Input.GetMouseButtonDown (0))
            {
                SetPoints ();
            }
        }
        else
        {
            if (wasSelected)
            {
                wasSelected = false;
                line.SetColor (Color.white);
            }
        }
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (10, 10, 800, 30), "Click the line to make a new line");
    }
}