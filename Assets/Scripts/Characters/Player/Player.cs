using UnityEngine;
using System.Collections;

public class Player : Character {
    public float _damage = 5;
    public float _critMultiplier = 1.5f;
    public int _critDenominator = 2;


	// Use this for initialization
	void Start () {
        References.Instance._currentPlayer = gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        Enemy charHit = (Enemy)GetComponent<ClickAttack>().getNewHit();
	    if (charHit != null)
        {
            Sounds.OneShot(Sounds.Instance.combat.player.attack.swipe, charHit.transform.position);

            int chance = Random.Range(0, _critDenominator);
            float damage = _damage;
            if (chance == 0)
            {
                damage *= _critMultiplier;
                charHit.MakeNextHitCrit();
            }

            charHit.Damage(damage);
        }
	}

    public override void Damage(float damage_)
    {
        Sounds.OneShot(Sounds.Instance.combat.player.damage, transform.position);
        base.Damage(damage_);
    }

    public override void Die()
    {
        base.Die();

        Sounds.OneShot(Sounds.Instance.combat.player.dies, transform.position);

        Game.Instance.HandleCombatEvent(Game.CombatEvent.PlayerDied);

        //Debug.Log("Spelaren avled tragiskt");

    }
}
