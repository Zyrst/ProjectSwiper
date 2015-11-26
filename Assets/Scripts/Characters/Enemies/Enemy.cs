using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public float _baseHealth = 75;
    public float _healthConst = 0.8f;
    public float _baseDamage = 3f;
    public float _modifierDamage = 50;


    bool _nextHitIsCrit = false;

    private GameObject _textParticle;

    private Object _explosionPrefab;

	// Use this for initialization
	void Start () {
        InitializeGUI();

        int level = Game.Instance._arenaLevel;
        if(level > 1)
        {
            float newHealth = Mathf.Ceil(_baseHealth + (level * (level * _healthConst)));
            this._maxHealth = newHealth;
            this._health = _maxHealth;
            float dmg = _baseDamage + level * (level / _modifierDamage);
            this.GetComponent<EnemyAttack>()._attackDamage = Mathf.Ceil(dmg);
        }
        else
        {
            this._maxHealth = this._health = _baseHealth;
            this.GetComponent<EnemyAttack>()._attackDamage = _baseDamage;
        }
        
        

        _textParticle = References.Instance._textParticle;

        _explosionPrefab = Resources.Load("Prefabs/Effects/ExplosionPrefab");
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

    public void MakeNextHitCrit()
    {
        _nextHitIsCrit = true;
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
        
        if (_nextHitIsCrit)
        {
            damageText.GetComponent<TextParticleScript>().SetColor(Color.red);
            _nextHitIsCrit = false;
        }

        damageText.transform.position = transform.position;
    }

    public override void Die()
    {
        Sounds.OneShot(Sounds.Instance.combat.enemies.robotDamage.Heavy, transform.position);
        base.Die();

        SpawnCurrency();

        // Spawn explosion
        ((GameObject)Instantiate(_explosionPrefab)).GetComponent<ExplosionScript>().setPosition(transform.position);
    }

    public override void Despawn()
    {
        base.Despawn();
    }

    void SpawnCurrency()
    {
        Vector3 dir = (Vector3.up * 5f) + -(transform.position - Camera.main.transform.position);
        CurrencyObject.Spawn(dir , transform.position + new Vector3(-1.5f, 1f, -1.5f));
    }
}
