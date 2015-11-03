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

        if (_enemy != null)
        {
            if (_enemy._isDead)
            {
                _enemyIsAlive = false;
                Destroy(_enemy.gameObject);
            }
        }
        else
        {

        }
	}

    public void Spawn(Enemy enemy_)
    {
        Debug.Log(_enemy == null);
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
