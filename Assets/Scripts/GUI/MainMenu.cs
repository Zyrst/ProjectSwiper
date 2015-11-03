using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
        References.Instance._combat = GameObject.Instantiate(References.Instance._combat);
        References.Instance._combat.GetComponent<Combat>().AddEnemy(References.Instance._enemies[0]);
        References.Instance._combat.GetComponent<Combat>().StartArena(References.Instance._combatArenas[0]);

        Instantiate(References.Instance._HUD);

        GameObject.Destroy(this.gameObject);
    }
}
