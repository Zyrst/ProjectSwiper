using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public float _maxHealth = 0;
    public float _health = 0;

    public float _damage = 1;

    public bool _isDead = false;

	// Use this for initialization
    void Start()
    {
        // -------------------------
        // HACK ( ͡° ͜ʖ ͡°)
        // Mattias balla kod
        // TODO: stay cool, brah
        // HACK ( ͡° ͜ʖ ͡°)
        // HACK Tiden = Guld = Pengar
        // --------------------------
    }

	void Awake() {
        _maxHealth = 10;
        _health = _maxHealth;
	}
	
	// Update is called once per frame
	void Update() {
	    
	}

    public void Damage(float damage_)
    {
        _health -= Mathf.Abs(damage_);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Heal(float health_)
    {
        _health += Mathf.Abs(health_);

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void IncreaseMaxHealth(float amount_)
    {
        _maxHealth += amount_;
    }

    public virtual void Die()
    {
        _isDead = true;
    }
}
