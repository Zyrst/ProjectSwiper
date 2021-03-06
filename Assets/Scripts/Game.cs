﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour {

    /// <summary>
    /// level: player level
    /// arenaLevel: current enemy level
    /// maxArenaLevel: the current highest unlocked level
    /// </summary>
    public int _level = 1;
    public int _arenaLevel = 1;
    // ökas i SpawnNewWave() i Combat
    public int _maxArenaLevel = 1;

    public enum CombatEvent : int { PlayerDied = 0, ClearWave, goToNextPlanet, goToPrevPlanet, 
        UnlockNextPlanetButton, LockNextPlanetButton, UnlockPrevPlanetButton, LockPrevPlanetButton };

    public enum GameMode : int { Quest = 0, Farm, Tutorial };
    public GameMode _gameMode = GameMode.Farm;

    public long _gameCurrency = 1;

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
        GameObject.Instantiate(References.Instance._player);
        Instantiate(References.Instance._mainMenu);
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
		 //Will reset stats but not save them
        if(Input.GetKeyDown(KeyCode.R))
        {
            References.Instance._currentPlayer.ResetStats();
        }

        References.Instance._stats.timeSpentPlayingSeconds += Time.deltaTime;
        if (References.Instance._stats.timeSpentPlayingSeconds >= 86400)
        {
            References.Instance._stats.timeSpentPlayingDays++;
            References.Instance._stats.timeSpentPlayingSeconds -= 86400;
        }
	}

    void LateUpdate()
    {
        MouseController.Instance.LateUpdate();
    }

    public void HandleCombatEvent(CombatEvent ce_)
    {
        switch (_gameMode)
        {
            case GameMode.Quest:
                HandleQuestCombatEvent(ce_);
                break;
            case GameMode.Farm:
                HandleFarmCombatEvent(ce_);
                break;
            case GameMode.Tutorial:
                HandleTutorialCombatEvent(ce_);
                break;
            default:
                break;
        }
    }

    private void HandleQuestCombatEvent(CombatEvent ce_)
    {
        switch (ce_)
        {
            case CombatEvent.PlayerDied:

                // trigger defeat screen
                GameObject.Instantiate(References.Instance._defeatedHUD);

                //Player p = References.Instance._currentPlayer.GetComponent<Player>();
                ////p.Heal(p._maxHealth);
                //p._health = p._maxHealth;
                //p._isDead = false;

                //KillAllEnemies();
                //References.Instance._currentCombat.StartCombat();

                break;
            case CombatEvent.ClearWave:
                Combat c = References.Instance._currentCombat;
                c.TriggerNewWave();
                break;
            case CombatEvent.goToPrevPlanet:
                _arenaLevel--;
                References.Instance._currentCombat.ChangePlanet();
                break;
            case CombatEvent.goToNextPlanet:
                _arenaLevel++;
                References.Instance._currentCombat.ChangePlanet();
                break;
            case CombatEvent.UnlockNextPlanetButton:
                {
                    GameObject go = References.Instance._currentHUD.GetComponentInChildren<PlanetSelectGUI>().gameObject;
                    go.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "NextButton").interactable = true;
                }
                break;
            case CombatEvent.LockNextPlanetButton:
                {
                    GameObject go = References.Instance._currentHUD.GetComponentInChildren<PlanetSelectGUI>().gameObject;
                    go.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "NextButton").interactable = false;
                }
                break;
            case CombatEvent.UnlockPrevPlanetButton:
                {
                    GameObject go = References.Instance._currentHUD.GetComponentInChildren<PlanetSelectGUI>().gameObject;
                    go.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "PrevButton").interactable = true;
                }
                break;
            case CombatEvent.LockPrevPlanetButton:
                {
                    GameObject go = References.Instance._currentHUD.GetComponentInChildren<PlanetSelectGUI>().gameObject;
                    go.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "PrevButton").interactable = false;
                }
                break;
            default:
                break;
        }
    }
    private void HandleFarmCombatEvent(CombatEvent ce_)
    {
        switch (ce_)
        {
            case CombatEvent.PlayerDied:
                {
                    Player p = References.Instance._currentPlayer;
                    p._health = p._maxHealth;
                    p._isDead = false;
                }
                break;
            case CombatEvent.ClearWave:
                {
                    Combat c = References.Instance._combat;
                    c.TriggerNewWave();

                    Player p = References.Instance._currentPlayer;
                    p.Heal(p._maxHealth);
                }
                break;
            default:
                break;
        }
    }

    private void HandleTutorialCombatEvent(CombatEvent ce_)
    {
        switch (ce_)
        {
            case CombatEvent.PlayerDied:
                break;
            case CombatEvent.ClearWave:
                break;
            default:
                break;
        }
    }

    void OnApplicationExit()
    {
        Debug.Log("Exiting game");
        SaveManager.Save();
    }

    public void KillAllEnemies()
    {
        try
        {
            for (int i = 0; i < References.Instance._currentCombat._enemySpawners.Count; i++)
            {
                References.Instance._currentCombat._enemySpawners[i].KillEnemy();
            }
        }
        catch (System.NullReferenceException)
        {
        }
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
