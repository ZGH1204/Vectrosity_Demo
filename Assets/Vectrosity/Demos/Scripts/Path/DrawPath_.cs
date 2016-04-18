using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class DrawPath_ : MonoBehaviour
{
    public Material lineMaterial;
    public int maxPoints = 500;
    public bool continuousUpdate = true;
    public GameObject ballPrefab;
    public float force = 16.0f;

    private VectorLine pathLine;
    private int pathIndex = 0;
    private GameObject ball;

	private void Start ()
    {
        pathLine = new VectorLine ("Path", new List<Vector3>(), lineMaterial, 12.0f, LineType.Continuous);
        pathLine.textureScale = 1.0f;

        MakeBall ();
        StartCoroutine (SamplePoints (ball.transform));
    }

    void MakeBall ()
    {
        if (ball)
        {
            Destroy (ball);
        }
        ball = Instantiate (ballPrefab, new Vector3 (-2.25f, -4.4f, -1.9f), Quaternion.Euler (300.0f, 70.0f, 310.0f)) as GameObject;
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce (ball.transform.forward * force, ForceMode.Impulse);
    }

    IEnumerator SamplePoints ( Transform thisTransform )
    { 
        var running = true;
        while (running)
        {
            pathLine.points3.Add (thisTransform.position);
            if (++pathIndex == maxPoints)
            {
                running = false;
            }
            yield return new WaitForSeconds (0.05f);

            if (continuousUpdate)
            {
                pathLine.Draw ();
            }
        }
        yield return 0;
    }

    void OnGUI ()
    {
        if (GUI.Button (new Rect (10, 10, 100, 30), "Reset"))
        {
            Reset ();
        }
        if (!continuousUpdate && GUI.Button (new Rect (10, 45, 100, 30), "Draw Path"))
        {
            pathLine.Draw ();
        }
    }

    void Reset ()
    {
        StopAllCoroutines ();
        MakeBall ();
        pathLine.points3.Clear ();
        pathLine.Draw (); 
        pathIndex = 0;
        StartCoroutine (SamplePoints (ball.transform));
    }
}