using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {
    
    /* Use this for resources
     * Textures, sprites etc. Keep it out of Game.cs
     */

    public GameObject _gameCurrency;
    public GameObject _player; 

    private static Resources _instance = null;

    public static Resources Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("RESOURCES").GetComponent<Resources>();
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
