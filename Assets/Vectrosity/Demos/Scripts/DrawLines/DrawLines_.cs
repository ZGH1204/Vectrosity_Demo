using UnityEngine;
using System.Collections;
using Vectrosity;
using System.Collections.Generic;

public class DrawLines_ : MonoBehaviour {

    public Material lineMaterial;
    public float rotateSpeed = 90.0f;
    public float maxPoints = 500f;

    private VectorLine line;
    
    private List<Color> lineColors;

    /// <summary>
    /// 是否连续
    /// </summary>
    private bool continuous = true;

    private bool fillJoins = false;
    private bool weldJoins = false;
    private bool oldFillJoins = false;
    private bool oldWeldJoins = false;
    private bool thickLine = false;
    private bool canClick = true;

    void Start () {
        ResetLine ();
    }

    void ResetLine ()
    {
        //删除线
        VectorLine.Destroy (ref line);

        if (!continuous)
        {
            fillJoins = false;
        }
        var lineType = (continuous ? LineType.Continuous : LineType.Discrete);
        var joins = (fillJoins ? Joins.Fill : Joins.None);
        var lineWidth = (thickLine ? 24 : 2);
        var arrayLength = continuous ? 1 : 0;
        lineColors = new List< Color > ();

        line = new VectorLine ("Line", new Vector2[arrayLength], lineMaterial, lineWidth, lineType, joins);
        line.drawTransform = transform;
        
    }
	

	void Update () {

        var mousePos = transform.InverseTransformPoint (Input.mousePosition);

        if (Input.GetMouseButtonDown (0) && canClick )
        {
            line.points2.Add (mousePos);
            
            if (continuous)
            {
                lineColors.Add (Color.white);
            }
            else {
                if (line.points2.Count % 2 == 0)
                {
                    lineColors.Add (Color.white);
                }
                if (line.points2.Count == 1)
                {
                    line.points2.Add (Vector2.zero);
                    lineColors.Add (Color.white);
                }
            }
        }
          
        if (continuous || (!continuous && line.points2.Count >= 2))
        {
            line.points2[line.points2.Count - 1] = mousePos;
            line.Draw ();
        } 

        transform.RotateAround (new Vector2 (Screen.width / 2, Screen.height / 2), Vector3.forward, Time.deltaTime * rotateSpeed * Input.GetAxis ("Horizontal"));
    }


    void OnGUI ()
    {
        var rect = new Rect (20, 20, 265, 280);
        canClick = (rect.Contains (Event.current.mousePosition) ? false : true);

        GUILayout.BeginArea (rect);

        GUI.contentColor = Color.black;
        GUILayout.Label ("Click to add points to the line\nRotate with the right/left arrow keys");
        GUILayout.Space (5);
        GUILayout.Label ("This option takes effect when line is reset:");

        continuous = GUILayout.Toggle (continuous, "Continuous line");

        GUILayout.Space (5);
        GUI.contentColor = Color.white;
        if (GUILayout.Button ("Reset line", GUILayout.Width (150)))
        {
            ResetLine ();
        }
        GUILayout.Space (15);

        GUI.contentColor = Color.black;
        thickLine = GUILayout.Toggle (thickLine, "Thick line");
        line.lineWidth = (thickLine ? 24 : 2);

        fillJoins = GUILayout.Toggle (fillJoins, "Fill joins (only works with continuous line)");
        if (!line.continuous)
        {
            fillJoins = false;
        }

        weldJoins = GUILayout.Toggle (weldJoins, "Weld joins");
        if (oldFillJoins != fillJoins)
        {
            if (fillJoins)
            {
                weldJoins = false;
            }
            oldFillJoins = fillJoins;
        }
        else if (oldWeldJoins != weldJoins)
        {
            if (weldJoins)
            {
                fillJoins = false;
            }
            oldWeldJoins = weldJoins;
        }
        if (fillJoins)
        {
            line.joins = Joins.Fill;
        }
        else if (weldJoins)
        {
            line.joins = Joins.Weld;
        }
        else
        {
            line.joins = Joins.None;
        }
        GUILayout.Space (10);
        GUI.contentColor = Color.white;

        if (GUILayout.Button ("Randomize Color", GUILayout.Width (150)))
        {
            RandomizeColor ();
        }
        if (GUILayout.Button ("Randomize All Colors", GUILayout.Width (150)))
        {
            RandomizeAllColors ();
        }
       
        GUILayout.EndArea ();
    }

    void RandomizeColor ()
    {
        line.color = new Color (Random.value, Random.value, Random.value);
    }

    void RandomizeAllColors ()
    {
        for (var i = 0; i < lineColors.Count; i++)
        {
            lineColors[i] = new Color (Random.value, Random.value, Random.value);
        }
        line.SetColors (lineColors);
    }
}
