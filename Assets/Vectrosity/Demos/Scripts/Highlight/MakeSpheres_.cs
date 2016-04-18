using UnityEngine;
using System.Collections;

public class MakeSpheres_ : MonoBehaviour {

    public GameObject spherePrefab;
    public int numberOfSpheres = 12;
    public float area = 4.5f;

    void Start () {
        for (var i = 0; i < numberOfSpheres; i++)
        {
            Instantiate (spherePrefab, new Vector3 (Random.Range (-area, area), Random.Range (-area, area), Random.Range (-area, area)), Random.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
