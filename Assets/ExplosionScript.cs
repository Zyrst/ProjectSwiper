using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPosition(Vector3 newPosition)
    {
        transform.position = newPosition - (Camera.main.transform.forward * (Vector3.Distance(Camera.main.transform.position, new Vector3(0, 0, 0)) - 10));
    }

    public void delete()
    {
        Destroy(transform.gameObject);
    }
}
