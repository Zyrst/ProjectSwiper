using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public float _attackCooldown = 1;
    float _attackCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAttackCooldown();
	}

    public override void Die()
    {
        base.Die();

        Debug.Log(gameObject.GetInstanceID() + " avled tragiskt");

        Destroy(gameObject);
    }

    void UpdateAttackCooldown()
    {
        _attackCounter += 1;

        if (_attackCounter >= _attackCooldown)
        {
            _attackCounter = 0;
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        Debug.Log(gameObject.GetInstanceID() + " attakerade spelaren");
    }
}
