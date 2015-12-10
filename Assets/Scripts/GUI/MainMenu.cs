using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class MainMenu : MonoBehaviour {
    public Text _currency;
    public Text _damage;
    public Text _health;
    public Text _crit;

    public string _damageTxt = "Damage: ";
    public string _currencyTxt = "Currency: ";
    public string _healthTxt = "Health: ";
    public string _critTxt = "Crit: ";

    public Button _healthUpgradeButton;
    public Button _damageUpgradeButton;
    public Button _critUpgradeButton;


	// Use this for initialization
	void Start () {
        SaveManager.Load();
        checkButtonEnableStatus();
    }
	
	// Update is called once per frame
	void Update () {
        checkButtonEnableStatus();
        _currency.text = _currencyTxt + Game.Instance._gameCurrency;
        _damage.text = _damageTxt + References.Instance._currentPlayer._damage;
        _health.text = _healthTxt + References.Instance._currentPlayer._maxHealth;
        _crit.text = _critTxt +  References.Instance._currentPlayer._critLevel + "%";
	}

    public void Play()
    {
        Sounds.OneShot(Sounds.Instance.ui.clickFight);

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
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        SaveManager.Save();
        Application.Quit();
    }

    private void checkButtonEnableStatus()
    {
        bool enabled = Game.Instance._gameCurrency > 100;
        _healthUpgradeButton.interactable = enabled;
        _damageUpgradeButton.interactable = enabled;
        _critUpgradeButton.interactable = enabled && (References.Instance._currentPlayer._critLevel < 60);
    }
}
