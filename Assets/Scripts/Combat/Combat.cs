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

            if (Input.GetKeyDown(KeyCode.Alpha1) && _waveCounter >= _minWaves)
            {
                ChangeArena();
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
        a.setTexture(Random.Range(0, a.textures.Length));

        _enemySpawners.Clear();
        foreach (var item in _arena.GetComponentsInChildren<EnemySpawner>())
        {
            _enemySpawners.Add(item);
        }
        ResetCounter();
        SpawnNewWave();
        _minWaves = Random.Range(6, 13);
    }

    public void SpawnNewWave()
    {
        Debug.Log("skapar en ny vågjävel");

        Sounds.OneShot(Sounds.Instance.ui.newWave);
        Debug.Log("spawning new enemies");
        foreach (var item in _enemySpawners)
        {
            item.Spawn(_currentEnemies[Random.Range(0, _currentEnemies.Count)]);
        }
        _waveCounter++;
        Debug.Log("Wave: " + _waveCounter);
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
