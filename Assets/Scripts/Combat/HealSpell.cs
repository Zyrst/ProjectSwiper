﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealSpell : Spells {

	// Use this for initialization
	new void Start () {
        base.Start();
        _cooldownTime = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (_cooldown)
        {
            _timer += Time.deltaTime;
            if (_timer >= _cooldownTime)
            {
                _cooldown = false;
                Button b = GetComponent<Button>();
                b.interactable = true;
                //b.targetGraphic.color = new Color(255f, 255f, 255f);
                _timer = 0f;

                Sounds.OneShot(Sounds.Instance.ui.abilityReady);
            }
        }
        base.updateMaterial();
    }

    public override void DoHeal()
    {
        Sounds.OneShot(Sounds.Instance.abilities.Heal);

        _cooldown = true;
        Button b = GetComponent<Button>();
        b.interactable = false;
        //b.targetGraphic.color *= 0.5f;
        References.Instance._currentPlayer.RestoreMaxHealth();
    }
}
