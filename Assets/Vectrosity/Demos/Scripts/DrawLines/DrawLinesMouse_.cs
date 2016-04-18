using UnityEngine;
using System.Collections;
using Vectrosity;
using System.Collections.Generic;

public class DrawLinesMouse_ : MonoBehaviour {

    public int maxPoints = 5000;
    public float lineWidth = 4.0f;
    public int minPixelMove = 5;
    public Material lineMaterial;
    public bool useEndCap = false;
    public Texture2D capTex;
    public Material capMaterial;

    private VectorLine line;
    private Vector3 previousPosition;
    private int sqrMinPixelMove;
    private bool canDraw = false;

    void Start () {

        if (useEndCap)
        {
            VectorLine.SetEndCap ("cap", EndCap.Mirror, capMaterial, capTex);
            lineMaterial = capMaterial;
        }

        line = new VectorLine ("DrawnLine", new List<Vector2> (), lineMaterial, lineWidth, LineType.Continuous, Joins.Weld);
        line.endPointsUpdate = 1;   // Optimization for updating only the last point of the line, and the rest is not re-computed
        if (useEndCap)
        {
            line.endCap = "cap";
        }
        
        sqrMinPixelMove = minPixelMove * minPixelMove;

    }
	
 
	void Update () {

        var mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown (0))
        {
            line.points2.Clear ();
            line.Draw ();
            previousPosition = mousePos;
            line.points2.Add (mousePos);
            canDraw = true;
        }
        else if (Input.GetMouseButton (0) && (mousePos - previousPosition).sqrMagnitude > sqrMinPixelMove && canDraw)
        {
            previousPosition = mousePos;
            line.points2.Add (mousePos);
            if (line.points2.Count >= maxPoints)
            {
                canDraw = false;
            }
            line.Draw ();
        }
    }
}
