using UnityEngine;
using System.Collections;

public class PlanetSelectGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToNextPlanet()
    {
        Game.Instance.HandleCombatEvent(Game.CombatEvent.goToNextPlanet);
        Game.Instance.HandleCombatEvent(Game.CombatEvent.LockNextPlanetButton);
    }

    public void goToPrevPlanet()
    {
        Game.Instance.HandleCombatEvent(Game.CombatEvent.goToPrevPlanet);
    }
}
