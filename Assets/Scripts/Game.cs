﻿using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _combat;
    public GameObject _player;

    public GameObject[] _combatArenas;
    public GameObject[] _enemies;

    public int _level = 1;

    public enum GameMode : int { Quest = 0, Farm, Tutorial };
    public GameMode _gameMode = GameMode.Farm;

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
        _combat = GameObject.Instantiate(_combat);
        _combat.GetComponent<Combat>().AddEnemy(_enemies[0]);
        _combat.GetComponent<Combat>().StartArena(_combatArenas[0]);

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
    }
}
