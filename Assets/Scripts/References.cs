using UnityEngine;
using System.Collections;

public class References : MonoBehaviour {

    /* Use this for resources
   * Textures, sprites etc. Keep it out of Game.cs
   */

    public GameObject _gameCurrency;
    public GameObject _player;
    public Combat _combat;
    public GameObject _currentPlayer;
    public GameObject _HUD;

    public GameObject[] _combatArenas;
    public GameObject[] _enemies;


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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
