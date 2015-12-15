using UnityEngine;
using System.Collections;

public class NextPlanetText : MonoBehaviour {
    public float _lifetime = 5f;
    private float _timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;

        if(_timer >= _lifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
