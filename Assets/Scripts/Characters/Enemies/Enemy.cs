﻿using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public float _baseHealth = 75;
    public float _healthConst = 0.8f;
    public float _baseDamage = 3f;
    public float _modifierDamage = 50;


    private GameObject _textParticle;
	// Use this for initialization
	void Start () {
        InitializeGUI();

        int level = Game.Instance._arenaLevel;
        

        float dmg = _baseDamage + level * (level / _modifierDamage);
        this.GetComponent<EnemyAttack>()._attackDamage = Mathf.Ceil(dmg);
        

        _textParticle = References.Instance._textParticle;
    }
	
    void OnAwake()
    {
        int level = Game.Instance._arenaLevel;
        float newHealth = Mathf.Ceil(_baseHealth + (level * (level * _healthConst)));
        this._maxHealth = newHealth;
        this._health = _maxHealth;
    }
	// Update is called once per frame
	void Update () {
        
    }

  
    void InitializeGUI()
    {
        GameObject healthBar = Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Healthbar")) as GameObject;
        healthBar.transform.SetParent(transform);
        healthBar.GetComponent<RectTransform>().localPosition = new Vector3(0, 1, 0);

        GameObject cooldownBar = Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Cooldownbar")) as GameObject;
        cooldownBar.transform.SetParent(transform);
        cooldownBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -1, 0);
    }

    public override void Damage(float damage_)
    {
        float oldPercent = _health / _maxHealth;

        base.Damage(damage_);

        float newPercent = _health / _maxHealth;

        if (newPercent <= 0.35f && oldPercent >= 0.35f)
        {
            Sounds.OneShot(Sounds.Instance.combat.enemies.robotDamage.Medium, transform.position);
        }
        else if (newPercent <= 0.8f && oldPercent >= 0.8f)
        {
            Sounds.OneShot(Sounds.Instance.combat.enemies.robotDamage.Small, transform.position);
        }

        GetComponent<Animator>().SetTrigger("TakeDamage");

        GameObject damageText = GameObject.Instantiate(_textParticle);

        damageText.GetComponent<TextParticleScript>().SetText(damage_.ToString());
        damageText.transform.position = transform.position;
    }

    public override void Die()
    {
        Sounds.OneShot(Sounds.Instance.combat.enemies.robotDamage.Heavy, transform.position);
        base.Die();

        SpawnCurrency();
    }

    void SpawnCurrency()
    {
        Vector3 dir = (Vector3.up * 15f) + -(transform.position - Camera.main.transform.position);
        CurrencyObject.Spawn(dir * 5, transform.position + new Vector3(-1.5f, 1f, -1.5f));
    }
}
