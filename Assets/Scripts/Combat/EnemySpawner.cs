using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public bool _enemyIsAlive = false;
    public Enemy _enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (_enemy == null || _enemy._isDead)
        {
            _enemy = null;
            _enemyIsAlive = false;
        }
	
	}

    public void Spawn(Enemy enemy_)
    {
        if (_enemy != null)
        {
            Destroy(_enemy);
        }
        _enemy = GameObject.Instantiate(enemy_);
        // spawnar på rätt jävla positionsjävel
        _enemy.transform.position = transform.position + (Vector3.up * _enemy.transform.localScale.y/2) - 
            (Vector3.up * (transform.position.y - (transform.localScale.y/2)));
        
        // alla tittar på skärmen
        Quaternion rotY = _enemy.transform.rotation;
        rotY.y = Camera.main.transform.rotation.y;
        _enemy.transform.rotation = rotY;
       
        _enemy.transform.parent = transform;

        _enemyIsAlive = true;
    }
}
