using System.Collections;
using UnityEngine;
using Vectrosity;

public class SelectionBox_ : MonoBehaviour
{
    private VectorLine selectionLine;
    private Vector2 originalPos;
    private Color[] lineColors;

    private void Start ()
    {
        lineColors = new Color[4];
        selectionLine = new VectorLine ("Selection", new Vector2[5], null, 3.0f, LineType.Continuous);
        selectionLine.capLength = 1.5f;
    }

    // Update is called once per frame
    private void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            StopCoroutine (CycleColor());
            selectionLine.SetColor (Color.white);
            originalPos = Input.mousePosition;
        }
        if (Input.GetMouseButton (0))
        {
            selectionLine.MakeRect (originalPos, Input.mousePosition);
            selectionLine.Draw ();
        }
        if (Input.GetMouseButtonUp (0))
        {
            StartCoroutine (CycleColor());
        }
    }

    IEnumerator CycleColor ()
    {
        while (true)
        {
            for (var i = 0; i < 4; i++)
            {
                lineColors[i] = Color.Lerp (Color.yellow, Color.red, Mathf.PingPong ((Time.time + i * 0.25f) * 3.0f, 1.0f));
            }
            selectionLine.SetColors (lineColors);
            yield return new WaitForSeconds (0.05f);
        }
        yield return 0;
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (10, 10, 300, 25), "Click & drag to make a selection box");
    }
}