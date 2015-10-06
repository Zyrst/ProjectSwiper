using UnityEngine;
using System.Collections;

public class UpgradePlayer : MonoBehaviour {

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
            Game.Instance._currentPlayer.GetComponent<Player>()._damage += 1;
            Game.Instance._currentPlayer.GetComponent<Player>().IncreaseMaxHealth(10);
            Game.Instance._gameCurrency -= 100;
            Game.Instance._level += 1;
            SaveManager.Save();
            Debug.Log("Upgraded player");
        }
        else
        {
            Debug.Log("Not enough currency");
        }
    }
}
