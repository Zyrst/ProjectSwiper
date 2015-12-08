using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class MainMenu : MonoBehaviour {
    public Text _currency;
    public Text _damage;
    public Text _health;

    public string _damageTxt = "Damage: ";
    public string _currencyTxt = "Currency: ";
    public string _healthTxt = "Health: ";

	// Use this for initialization
	void Start () {
        SaveManager.Load();
       
	}
	
	// Update is called once per frame
	void Update () {
        _currency.text = _currencyTxt + Game.Instance._gameCurrency;
        _damage.text = _damageTxt + References.Instance._currentPlayer._damage;
        _health.text = _healthTxt + References.Instance._currentPlayer._maxHealth;
	}

    public void Play()
    {
        References.Instance._currentCombat = GameObject.Instantiate(References.Instance._combat);

        foreach (var item in References.Instance._enemies)
        {
            References.Instance._currentCombat.AddEnemy(item);
        }

        References.Instance._currentHUD = Instantiate(References.Instance._HUD).GetComponent<HUDScript>();
        References.Instance._currentCombat.StartArena(References.Instance._combatArenas[0]);
        References.Instance._currentPlayer.GetComponent<ClickAttack>().enabled = true;
        Debug.Log("Current level: " + Game.Instance._arenaLevel);
        GameObject.Destroy(this.gameObject);
    }

    public void Exit()
    {
        SaveManager.Save();
        Application.Quit();
    }
}
