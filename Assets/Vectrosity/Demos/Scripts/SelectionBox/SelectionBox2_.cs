using UnityEngine;
using Vectrosity;

public class SelectionBox2_ : MonoBehaviour
{
    public Material lineMaterial;
    public float textureScale = 4.0f;
    private VectorLine selectionLine;
    private Vector2 originalPos;

    private void Start ()
    {
        selectionLine = new VectorLine ("Selection", new Vector2[5], lineMaterial, 4.0f, LineType.Continuous, Joins.Fill);
        selectionLine.textureScale = textureScale;
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (10, 10, 300, 25), "Click & drag to make a selection box");
    }

    // Update is called once per frame
    private void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            originalPos = Input.mousePosition;
        }
        if (Input.GetMouseButton (0))
        {
            selectionLine.MakeRect (originalPos, Input.mousePosition);
            selectionLine.Draw ();
        }
        selectionLine.textureOffset -= Time.time * 2.0f % 1f;
    }
}