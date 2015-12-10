using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefeatedGUI : MonoBehaviour {

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
    }

    public void Menu()
    {
        Sounds.OneShot(Sounds.Instance.ui.buttonClick);
        Time.timeScale = 1f;
        References.Instance._currentCombat.BackToMenu();
        Destroy(this.gameObject);
    }
}
