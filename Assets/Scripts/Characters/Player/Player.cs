using UnityEngine;
using System.Collections;

public class Player : Character {
    public float _damage = 5;
    public float _critMultiplier = 1.5f;
    public int _critDenominator = 2;
    public float _baseHealth = 100f;
    public float _baseDamage = 5f;

    public int _healthLevel = 1;
    public int _damageLevel = 1;
    public int _critLevel = 1;

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
	
	 public void ResetStats()
    {
        this._maxHealth = this._baseHealth;
        this._health = this._maxHealth;
        this._damage = this._baseDamage;
        this._healthLevel = 1;
        this._damageLevel = 1;
        this._critLevel = 1;
    }
}
