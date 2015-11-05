using UnityEngine;
using System.Collections;

public class TurnToCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.LookAt(Camera.main.transform.position);
        Vector3 rot = transform.forward;
        rot.y = 0;
        transform.forward = rot;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
