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

    public GameObject[] _combatArenas;
    public GameObject[] _enemies;

    public bool _FMODMasterMute = false;
    public float _FMODMasterSlider = 1f;


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
