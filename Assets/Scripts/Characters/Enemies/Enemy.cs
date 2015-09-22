using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public float _attackCooldown = 1;
    public float _attackCounter = 0;
    public float _attackDamage = 1;

	// Use this for initialization
	void Start () {
	    GameObject healthBar = Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Healthbar")) as GameObject;
        healthBar.transform.SetParent(transform);
        healthBar.GetComponent<RectTransform>().localPosition = new Vector3(0, 1, 0);

        GameObject cooldownBar = Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Cooldownbar")) as GameObject;
        cooldownBar.transform.SetParent(transform);
        cooldownBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateAttackCooldown();
    }

    public override void Die()
    {
        base.Die();

        Debug.Log(gameObject.GetInstanceID() + " avled tragiskt");
        CurrencyObject.Spawn(new Vector3(0, 1, -20), transform.position);
        Destroy(gameObject);
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
        Debug.Log(gameObject.GetInstanceID() + " attakerade spelaren för " + _attackDamage + " skada");

        Resources.Instance._player.GetComponent<Player>().Damage(_attackDamage);
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
