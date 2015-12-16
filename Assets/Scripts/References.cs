using UnityEngine;
using System.Collections;

public class References : MonoBehaviour {

    /* Use this for resources
   * Textures, sprites etc. Keep it out of Game.cs
   */

    public GameObject _gameCurrency;
    public GameObject _player;
    public Combat _combat;
    public Combat _currentCombat;
    public Player _currentPlayer;
    public GameObject _HUD;
    public HUDScript _currentHUD;
    public GameObject _defeatedHUD;
    public GameObject _nextPlanet;
    public GameObject _mainMenu;
    public GameObject _textParticle;
    public GameObject _credits;

    public GameObject[] _combatArenas;
    public GameObject[] _enemies;

    public bool _FMODMusicMute = false;
    public float _FMODMusicSlider = 1f;

    public bool _FMODSoundMute = false;
    public float _FMODSoundSlider = 1f;

    [System.Serializable]
    public class Stats
    {
        public float moneyCollected = 0;
        public float moneySpent = 0;
        public float damageRecived = 0;
        public float damageDelt = 0;
        public float enemiesKilled = 0;
        public float timesEnemiesKilled = 0;
        public float timeSpentPlaying = 0;
    }
    public Stats _stats;


    /*
     * resätt den har biten på riktigt sen
     * */
    [System.Serializable]
    public class Planet{

        public int _id = 1059847;
    }
    public Planet _planet = new Planet();

    private static References _instance = null;

    public static References Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("RESOURCES").GetComponent<References>();
            return _instance;
        }
    }
}
