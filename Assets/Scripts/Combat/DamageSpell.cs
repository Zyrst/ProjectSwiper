﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageSpell : Spells {

	// Use this for initialization
	void Start () {
        _cooldownTime = 10f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(_cooldown)
        {
            _timer += Time.deltaTime;
            if(_timer >= _cooldownTime)
            {
                _cooldown = false;
                Button b = GetComponent<Button>();
                b.interactable = true;
                b.targetGraphic.color = new Color(255f, 255f, 255f);
                _timer = 0f;
            }
        }
	}

    public override void DoDamage()
    {
        _cooldown = true;
        Button b = GetComponent<Button>();
        b.interactable = false;
        b.targetGraphic.color *= 0.5f;
        foreach (EnemySpawner es in References.Instance._currentCombat._enemySpawners)
        {
            es._enemy.Damage(es._enemy._maxHealth * 0.75f);
        }
    }
}