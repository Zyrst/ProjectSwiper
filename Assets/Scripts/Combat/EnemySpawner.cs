using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public bool _enemyIsAlive = false;
    public Enemy _enemy;

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        CheckAndandleDead();

	}

    public void CheckAndandleDead()
    {
        if (_enemy != null)
        {
            if (_enemy._isDead)
            {
                _enemyIsAlive = false;
                Destroy(_enemy.gameObject);
            }
        }
    }

    public void KillEnemy()
    {
        if (_enemy != null)
        {
            _enemy.Damage(_enemy._maxHealth);

            CheckAndandleDead();
        }
    }

    public void Spawn(Enemy enemy_)
    {
        if (_enemy != null)
        {
            Destroy(_enemy.gameObject);
        }
        _enemy = GameObject.Instantiate(enemy_);

        _enemy.transform.position = transform.position;
       
        _enemy.transform.parent = transform;

        _enemyIsAlive = true;
    }
}
