using UnityEngine;
using System.Collections;
using Vectrosity;

public class DrawGrid_ : MonoBehaviour {

    public Vector2 oriPoint = new Vector2 (100.5f, 100.5f);

    private int gridPixels = 50;
    private VectorLine gridLine;
     
    private Vector2[] points;

    void Start () {
        points = new Vector2[] { };
        gridLine = new VectorLine ("Grid", points, null, 1.0f);

        gridLine.rectTransform.anchoredPosition = oriPoint;
        MakeGrid ();
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (10, 10, 30, 20), gridPixels.ToString ());
        gridPixels = (int)GUI.HorizontalSlider (new Rect (40f, 15f, 590f, 20f), gridPixels, 5f, 200f);
        if (GUI.changed)
        {
            MakeGrid ();
        }
    }

    void MakeGrid ()
    {
        var numberOfGridPoints = ((Screen.width / gridPixels + 1) + (Screen.height / gridPixels + 1)) * 2;
        gridLine.Resize (numberOfGridPoints);

        var index = 0;
        for (var x = 0; x < Screen.width; x += gridPixels)
        {
            gridLine.points2[index++] =new Vector2 (x, 0);
            gridLine.points2[index++] =new Vector2 (x, Screen.height - 1);
        }
        for (var y = 0; y < Screen.height; y += gridPixels)
        {
            gridLine.points2[index++] =new Vector2 (0, y);
            gridLine.points2[index++] =new Vector2 (Screen.width - 1, y);
        }

        gridLine.Draw ();
    }
    void Update () {
	
	}
}
