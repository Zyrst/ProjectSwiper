﻿using UnityEngine;
using System.Collections;

public class UpgradePlayer : MonoBehaviour {
    public static float _modifider = 0.1f;
    public static float _baseDmg = 5f;
    public static float _modifierDmg = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void Upgrade()
    {
        if(Game.Instance._gameCurrency >= 100)
        {
            Game.Instance._level += 1;
            int level = Game.Instance._level;
            float dmg = _baseDmg + level * (level / _modifierDmg);
            References.Instance._currentPlayer.GetComponent<Player>()._damage = Mathf.Floor(dmg);
            float maxHealth = Mathf.Ceil(100 + (level * (level * _modifider)));
            References.Instance._currentPlayer.GetComponent<Player>()._maxHealth = maxHealth + level;
            Game.Instance._gameCurrency -= 100;
            SaveManager.Save();
            Debug.Log("Upgraded player");
        }
        else
        {
            Debug.Log("Not enough currency");
        }
    }
}
