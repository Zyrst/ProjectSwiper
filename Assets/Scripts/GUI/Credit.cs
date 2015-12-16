using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void Exit()
    {
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        Destroy(this.gameObject);
    }
}
