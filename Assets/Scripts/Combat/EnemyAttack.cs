using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public float _attackCooldown = 0;
    public float _attackDamage = 0;

    [HideInInspector]
    public float _attackCounter = 0;

    public float _attackAnimationDelay = 0;
    private bool _hasAttacked = false;

    public bool _stunned = false;
    public float _stunTime = 3f;
    public float _stunTimer = 0f;

	// Use this for initialization
	void Start () {
        _attackCounter = Random.Range(_attackAnimationDelay, _attackCooldown);
        _stunned = false;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAttackCooldown();
	}

    void UpdateAttackCooldown()
    {
        if (!_stunned)
        {


            _attackCounter -= Time.deltaTime;

            if (_attackCounter <= _attackAnimationDelay)
            {
                if (!_hasAttacked)
                {
                    _hasAttacked = true;
                    AttackPlayer();
                }

                if (_attackCounter <= 0)
                {
                    _hasAttacked = false;
                    ResetCooldown();
                }
            }
        }
        else if (_stunned)
        {
            _stunTimer += Time.deltaTime;
            if (_stunTimer >= _stunTime)
            {
                _stunned = false;
                _stunTimer = 0f;
            }
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
