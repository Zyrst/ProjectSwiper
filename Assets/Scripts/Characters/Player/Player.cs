using UnityEngine;
using System.Collections;

public class Player : Character {
    public float _damage = 1;

	// Use this for initialization
	void Start () {
        References.Instance._currentPlayer = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Character charHit = GetComponent<ClickAttack>().getNewHit();
	    if (charHit != null)
        {
            Sounds.OneShot(Sounds.Instance.combat.player.attack.swipe, charHit.transform.position);
            charHit.Damage(_damage);
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
