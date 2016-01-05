using UnityEngine;
using System.Collections;

public class UpgradePlayer : MonoBehaviour {
    public static float _modifider = 0.1f;
    public static float _modifierDmg = 8;
    public static long _cost = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void Upgrade()
    {
        if(Game.Instance._gameCurrency >= _cost)
        {
            Game.Instance._level += 1;
            int level = Game.Instance._level;
            float baseDamage = References.Instance._currentPlayer.GetComponent<Player>()._baseDamage;
            float dmg = baseDamage + level * (level / _modifierDmg);
            References.Instance._currentPlayer.GetComponent<Player>()._damage = Mathf.Ceil(dmg);
           
            Game.Instance._gameCurrency -= _cost;
            SaveManager.Save();
            Debug.Log("Upgraded player");
        }
        else
        {
            Debug.Log("Not enough currency");
        }
    }

    public static void UpgradeHealth()
    {
        if (Game.Instance._gameCurrency >= _cost)
        {
            References.Instance._currentPlayer._healthLevel += 1;
            int level = References.Instance._currentPlayer._healthLevel;
            float baseHP = References.Instance._currentPlayer.GetComponent<Player>()._baseHealth;
            float maxHealth = Mathf.Ceil(baseHP + (level * (level * _modifider)));
            References.Instance._currentPlayer._maxHealth = maxHealth + level;
            Game.Instance._gameCurrency -= _cost;
            References.Instance._stats.moneySpent += _cost;
            SaveManager.Save();
        }
    }

    public static void UpgradeDamage() 
    {
        if(Game.Instance._gameCurrency >= _cost)
        {
            References.Instance._currentPlayer._damageLevel += 1;
            int level = References.Instance._currentPlayer._damageLevel;
            float baseDamage = References.Instance._currentPlayer.GetComponent<Player>()._baseDamage;
            float dmg = baseDamage + level * (level / _modifierDmg);
            References.Instance._currentPlayer.GetComponent<Player>()._damage = Mathf.Ceil(dmg);
            Game.Instance._gameCurrency -= _cost;
            References.Instance._stats.moneySpent += _cost;
            SaveManager.Save();
        }
    }

    public static void UpgradeCrit()
    {
        if (Game.Instance._gameCurrency >= _cost && References.Instance._currentPlayer._critLevel < 60)
        {
            References.Instance._currentPlayer._critLevel += 1;
            References.Instance._currentPlayer._critDenominator -= 1;
            Game.Instance._gameCurrency -= _cost;
            References.Instance._stats.moneySpent += _cost;
            SaveManager.Save();
        }
        
    }
}
