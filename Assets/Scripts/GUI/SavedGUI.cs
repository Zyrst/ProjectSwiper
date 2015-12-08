using UnityEngine;
using System.Collections;

public class SavedGUI : MonoBehaviour {
    public float _lifeTime = 3f;
    public float _timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if(_timer >= _lifeTime)
        {
            Destroy(this.gameObject);
        }
	}
}
