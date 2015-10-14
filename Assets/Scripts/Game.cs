using UnityEngine;
using System.Collections;
using GameAnalyticsSDK;

public class Game : MonoBehaviour {

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
        References.Instance._combat = GameObject.Instantiate(References.Instance._combat);
        References.Instance._combat.GetComponent<Combat>().AddEnemy(References.Instance._enemies[0]);
        References.Instance._combat.GetComponent<Combat>().StartArena(References.Instance._combatArenas[0]);

        GameObject.Instantiate(References.Instance._player);

        Instantiate(References.Instance._HUD);
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
