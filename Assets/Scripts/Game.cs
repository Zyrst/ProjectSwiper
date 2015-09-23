using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _combat;
    public GameObject _currentPlayer;
    public GameObject _HUD;

    public GameObject[] _combatArenas;
    public GameObject[] _enemies;

    public int _level = 1;

    public enum GameMode : int { Quest = 0, Farm, Tutorial };
    public GameMode _gameMode = GameMode.Farm;

    public int _gameCurrency = 1;

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
    void Start()
    {
        _combat = GameObject.Instantiate(_combat);
        _combat.GetComponent<Combat>().AddEnemy(_enemies[0]);
        _combat.GetComponent<Combat>().StartArena(_combatArenas[0]);

        GameObject.Instantiate(Resources.Instance._player);
        CurrencyObject.Spawn(new Vector3(20f, 1f, 0f), new Vector3(0f, 0f, 0f));

        Instantiate(_HUD);
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
        if(Input.GetKeyDown(KeyCode.C))
        {
            _gameCurrency += 50;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpgradePlayer.Upgrade();
        }
	}

    void LateUpdate()
    {
        MouseController.Instance.LateUpdate();
    }

    void OnApplicationExit()
    {
        Debug.Log("Exiting game");
       // SaveManager.Save();
    }
    
    void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus == true)
        {
            Debug.Log("Paused game");
            SaveManager.Save();
        }
            
    }
}
