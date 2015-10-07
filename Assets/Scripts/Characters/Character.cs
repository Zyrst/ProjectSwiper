using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public float _maxHealth = 1;
    public float _health = 1;

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

	}
	
	// Update is called once per frame
	void Update() {
	    
	}

    public virtual void Damage(float damage_)
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

    public void RestoreMaxHealth()
    {
        _health = _maxHealth;
    }

    public virtual void Die()
    {
        _isDead = true;
    }
}
