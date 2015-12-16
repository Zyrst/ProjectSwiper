using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StunSpell : Spells {
    private GameCamera _camera;
	// Use this for initialization
	new void Start () {
        base.Start();
        _cooldownTime = 5f;
        _camera = GameObject.Find("Main Camera").GetComponent<GameCamera>();
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

    public void Stun()
    {
        Sounds.OneShot(Sounds.Instance.abilities.Stun);

        _cooldown = true;
        Button b = GetComponent<Button>();
        b.interactable = false;
        //b.targetGraphic.color *= 0.5f;
        foreach(EnemySpawner es in References.Instance._currentCombat._enemySpawners)
        {
            if (es._enemy != null)
            {
                es._enemy.GetComponent<EnemyAttack>().Stun();
            }
        }

        _camera._shakeDist = 0.2f;
        _camera.Shake();
    }
}
