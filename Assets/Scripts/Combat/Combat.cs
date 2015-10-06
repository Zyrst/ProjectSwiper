using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combat : MonoBehaviour {

    public GameObject _arena;
    public List<EnemySpawner> _enemySpawners;
    public List<Enemy> _currentEnemies = new List<Enemy>();
    public int _waveCounter;

    Combat()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
            SpawnNewWave();
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
        _enemySpawners.Clear();
        foreach (var item in _arena.GetComponentsInChildren<EnemySpawner>())
        {
            _enemySpawners.Add(item);
        }
        _waveCounter = 0;
        SpawnNewWave();
    }

    public void SpawnNewWave()
    {
        Debug.Log("spawning new enemies");
        foreach (var item in _enemySpawners)
        {
            item.Spawn(_currentEnemies[Random.Range(0, _currentEnemies.Count)]);
        }
        _waveCounter++;
        Debug.Log(_waveCounter);
    }
}
