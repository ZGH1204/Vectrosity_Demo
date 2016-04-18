using UnityEngine;
using System.Collections;
using Vectrosity;

public class DrawPoints_ : MonoBehaviour {

    public float dotSize = 2.0f;
    public int numberOfDots = 100;
    public int numberOfRings = 8;
    public Color dotColor = Color.cyan;

    void Start () {

        int totalDots = numberOfDots * numberOfRings;
        Vector2[] dotPoints = new Vector2[totalDots];
        Color[] dotColors = new Color[totalDots];

        float reduceAmount = 1.0f - .75f / totalDots;
        for (int i = 0; i < dotColors.Length; i++)
        {
            dotColors[i] = dotColor;
            dotColor *= reduceAmount;
        }

        VectorLine dots = new VectorPoints ("Dots", dotPoints, null, dotSize);
        dots.SetColors (dotColors);
        for (var i = 0; i < numberOfRings; i++)
        {
            dots.MakeCircle (new Vector2 (Screen.width / 2, Screen.height / 2), Screen.height / (i + 2), numberOfDots, numberOfDots * i);
        }
        dots.Draw ();

    }
	
	 
}
