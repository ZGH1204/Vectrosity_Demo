using UnityEngine;
using Vectrosity;

public class AnimatePartialLine_ : MonoBehaviour
{
    public Material lineMaterial;
    public int segments = 60;
    public int visibleLineSegments = 20;
    public float speed = 60.0f;
    private float startIndex;
    private float endIndex;
    private VectorLine line;

    private void Start ()
    { 
        startIndex -= visibleLineSegments;
        endIndex = 0;

        Vector2[] linePoints = new Vector2[segments + 1];
        line = new VectorLine ("Spline", linePoints, lineMaterial, 30.0f, LineType.Continuous, Joins.Weld);

        float sw = Screen.width / 5;
        float sh = Screen.height / 3;
        Vector2[] splinePoints = new Vector2[] { new Vector2 (sw, sh), new Vector2 (sw * 2, sh * 2), new Vector2 (sw * 3, sh * 2), new Vector2 (sw * 4, sh) };
        line.MakeSpline (splinePoints);
        line.Draw ();
        Debug.Log (line.points2.Count);
    }

    // Update is called once per frame
    private void Update ()
    { 
        startIndex += Time.deltaTime * speed;
        endIndex += Time.deltaTime * speed;

        if (startIndex >= segments + 1)
        {
            startIndex -= visibleLineSegments;
            endIndex = 0;
        }
        else if (startIndex < -visibleLineSegments)
        {
            startIndex = segments;
            endIndex = segments + visibleLineSegments;
        }
        line.drawStart = (int)startIndex;
        line.drawEnd = (int)endIndex;
        line.Draw ();
    }
}