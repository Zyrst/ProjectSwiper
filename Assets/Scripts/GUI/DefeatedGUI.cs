using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefeatedGUI : MonoBehaviour {

    public Image _bg;

    private float _alpha = 0.1f;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	    if(Game.Instance._arenaLevel == 1)
        {
            GameObject.Find("LowerPlanet").GetComponent<Button>().interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Color c = _bg.color;
        c.a = _alpha;
        _bg.color = c;

        _alpha += Time.unscaledDeltaTime / 3;
        if (_alpha >= 0.9f)
            _alpha = 0.9f;
	}

    public void LowerLevel()
    {
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        if(Game.Instance._arenaLevel > 1)
        {
            Time.timeScale = 1f;
            GameObject.Find("PlanetSelect").GetComponent<PlanetSelectGUI>().goToPrevPlanet();
            Destroy(this.gameObject);
        }

        Sounds.Instance.music.background.Reset();
    }

    public void Restart()
    {
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        Time.timeScale = 1f;
        Player p = References.Instance._currentPlayer.GetComponent<Player>();
        p._health = p._maxHealth;
        p._isDead = false;
        Game.Instance.KillAllEnemies();
        References.Instance._currentCombat.StartCombat();
        Destroy(this.gameObject);

        Sounds.Instance.music.background.Reset();
    }

    public void Menu()
    {
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        Time.timeScale = 1f;
        References.Instance._currentCombat.BackToMenu();
        Destroy(this.gameObject);

        Sounds.Instance.music.background.Reset();
    }
}
