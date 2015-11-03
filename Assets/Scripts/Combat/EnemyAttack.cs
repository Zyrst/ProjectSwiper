using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public float _attackCooldown = 1;
    public float _attackDamage = 1;

    [HideInInspector]
    public float _attackCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAttackCooldown();
	}

    void UpdateAttackCooldown()
    {
        _attackCounter -= Time.deltaTime;

        if (_attackCounter <= 0)
        {
            ResetCooldown();
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        //Debug.Log(gameObject.GetInstanceID() + " attakerade spelaren för " + _attackDamage + " skada");

        References.Instance._currentPlayer.GetComponent<Player>().Damage(_attackDamage);
        GetComponent<Animator>().SetTrigger("Attack");
    }

    void ResetCooldown()
    {
        _attackCounter = _attackCooldown;
    }

    void DelayAttack(float delay_)
    {
        _attackCounter += delay_;

        if (_attackCounter > _attackCooldown)
        {
            _attackCounter = _attackCooldown;
        }
    }

    void DelayAttackNoLimit(float delay_)
    {
        _attackCounter += delay_;
    }
}
