using UnityEngine;
using System.Collections;

public class StunEffect : MonoBehaviour {
    public float _lifeTime;
    public float _timer = 0;
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

    public void SetPosition(Vector3 pos, float life)
    {
        _lifeTime = life;
       transform.position = pos - (Camera.main.transform.forward * (Vector3.Distance(Camera.main.transform.position, new Vector3(0, 0, 0)) - 10));
    }
}
