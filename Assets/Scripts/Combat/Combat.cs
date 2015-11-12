using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combat : MonoBehaviour {

    public GameObject _arena;
    public List<EnemySpawner> _enemySpawners;
    public List<Enemy> _currentEnemies = new List<Enemy>();
    public int _waveCounter;
    public int _minWaves;
    public float _newWaveTime = 0.8f;

    private bool _triggerNewWave = false;
    private float _triggerNewWaveCounter = 0f;

    Combat()
    {
    }

	// Use this for initialization
	void Start () {
        _waveCounter = 0;
        _triggerNewWaveCounter = 0;

        References.Instance._currentPlayer.RestoreMaxHealth();
	}

    public void StartCombat()
    {
        ResetCounter();
        Random.seed = References.Instance._planet._id;
        TriggerNewWave();
    }

    public void TriggerNewWave()
    {
        _triggerNewWave = true;
        _triggerNewWaveCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (!_triggerNewWave)
        {
            bool alive = false;

            foreach (var item in _enemySpawners)
            {
                if (item._enemyIsAlive)
                {
                    alive = true;
                    break;
                }
            }
            if (!alive)
            {
                Game.Instance.HandleCombatEvent(Game.CombatEvent.ClearWave);
            }
        }
        else
        {
            _triggerNewWaveCounter += Time.deltaTime;
            if (_triggerNewWaveCounter >= _newWaveTime)
            {
                _triggerNewWave = false;
                SpawnNewWave();
            }
        }
	}

    public void AddEnemy(GameObject enemy_)
    {
        _currentEnemies.Add(enemy_.GetComponent<Enemy>());
    }

    public void StartArena(GameObject arena_)
    {
        _arena = GameObject.Instantiate(arena_);
        _arena.transform.position = Vector3.zero;
        Arena a = _arena.GetComponent<Arena>();
        a.setTexture(0);

        _enemySpawners.Clear();
        foreach (var item in _arena.GetComponentsInChildren<EnemySpawner>())
        {
            _enemySpawners.Add(item);
        }
        ResetCounter();
        SpawnNewWave();
        _minWaves = 10;


        if (Game.Instance._arenaLevel > 1)
            Game.Instance.HandleCombatEvent(Game.CombatEvent.UnlockPrevPlanetButton);
        if (Game.Instance._arenaLevel < Game.Instance._maxArenaLevel)
            Game.Instance.HandleCombatEvent(Game.CombatEvent.UnlockNextPlanetButton);

    }

    public void SpawnNewWave()
    {
        Sounds.OneShot(Sounds.Instance.ui.newWave);
        foreach (var item in _enemySpawners)
        {
            item.Spawn(_currentEnemies[Random.Range(0, _currentEnemies.Count)]);
        }
        _waveCounter++;

        if (_waveCounter == _minWaves)
        {
            if (Game.Instance._arenaLevel == Game.Instance._maxArenaLevel)
            {
                Game.Instance._maxArenaLevel++;
            }
            Game.Instance.HandleCombatEvent(Game.CombatEvent.UnlockNextPlanetButton);
        }
    }

    public void ChangePlanet()
    {
     // slumpa fram en ny textur
        Arena a = _arena.GetComponent<Arena>();
        int ind = a._textureIndex;
        while (ind == a._textureIndex)
            a.setTexture(Random.Range(0, a.textures.Length));

        _waveCounter = 0;

        Game.Instance.KillAllEnemies();

        References.Instance._currentPlayer.RestoreMaxHealth();

        if (Game.Instance._arenaLevel > 1)
            Game.Instance.HandleCombatEvent(Game.CombatEvent.UnlockPrevPlanetButton);
        if (Game.Instance._arenaLevel < Game.Instance._maxArenaLevel)
            Game.Instance.HandleCombatEvent(Game.CombatEvent.UnlockNextPlanetButton);
    }

    public void ChangeArena()
    {
        Destroy(_arena);
        StartArena(References.Instance._combatArenas[1]);
    }

    public void ResetCounter()
    {
        _waveCounter = 0;
    }

    public void PlayerDied()
    {

    }
}
