using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _combat;
    public GameObject _player;

    public int _level = 1;

    private static Game _instance = null;

    public static Game Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("GAME").GetComponent<Game>();
            return _instance;
        }
    }
	// Use this for initialization
	void Start () {
        GameObject.Instantiate(_combat);
        GameObject.Instantiate(_player);
        SaveManager.Load();
	}
	
	// Update is called once per frame
	void Update () {
        MouseController.Instance.Update();

        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveManager.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveManager.Load();
        }
	}

    void LateUpdate()
    {
        MouseController.Instance.LateUpdate();

        // TODO: Suck a dong
    }
}
