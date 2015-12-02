using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class PlanetSelectGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int level = Game.Instance._arenaLevel;
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "CurrentLevel").text = level.ToString();
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "NextLevel").text = (level + 1).ToString();
        if (level != 1)
        {
            GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "PastLevel").text = (level - 1).ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToNextPlanet()
    {
        Game.Instance.HandleCombatEvent(Game.CombatEvent.LockNextPlanetButton);
        Game.Instance.HandleCombatEvent(Game.CombatEvent.goToNextPlanet);
        int level = Game.Instance._arenaLevel;
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "CurrentLevel").text = level.ToString();
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "NextLevel").text = (level + 1).ToString();
        if (level != 1)
        {
            GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "PastLevel").text = (level - 1).ToString();
        }
    }

    public void goToPrevPlanet()
    {
        Game.Instance.HandleCombatEvent(Game.CombatEvent.LockPrevPlanetButton);
        Game.Instance.HandleCombatEvent(Game.CombatEvent.goToPrevPlanet);
        int level = Game.Instance._arenaLevel;
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "CurrentLevel").text = level.ToString();
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "NextLevel").text = level.ToString();
        if(level != 1)
        {
            GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "PastLevel").text = (level - 1).ToString();
        }
    }
}
