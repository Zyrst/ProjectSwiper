using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _combat;

	// Use this for initialization
	void Start () {
        GameObject.Instantiate(_combat);
	}
	
	// Update is called once per frame
	void Update () {
        MouseController.Instance.Update();
	}

    void LateUpdate()
    {
        MouseController.Instance.LateUpdate();
    }
}
