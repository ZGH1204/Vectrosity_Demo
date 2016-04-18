using UnityEngine;
using System.Collections;
using Vectrosity;

public class Test01 : MonoBehaviour {

    private VectorLine gridLine;
    private Vector2[] points;

    void Start () {

        //必须是2的倍数
        points = new Vector2[] { Vector2.zero, new Vector2(100, 10), new Vector2 (10, 200), new Vector2 (100, 100)};
        gridLine = new VectorLine ("Grid", points, null, 1.0f);
        gridLine.color = Color.red;

        gridLine.Draw ();

        //重置所有的点为0
        gridLine.Resize (6);

        gridLine.points2[0] = new Vector2 (100, 10);
        gridLine.points2[1] = new Vector2 (10, 100);

        //gridLine.points2.Add (new Vector2 (100, 10));
        //gridLine.points2.Add (new Vector2 (10, 110));

        //gridLine.points2.Add (new Vector2 (100, 200));
        //gridLine.points2.Add (new Vector2 (200, 100));

        //gridLine.points2.Add (new Vector2 (200, 300));
        //gridLine.points2.Add (new Vector2 (300, 200));

        gridLine.Draw ();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
