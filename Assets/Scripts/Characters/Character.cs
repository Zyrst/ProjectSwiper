using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public float _health = 1;
    public float _maxHealth = 1;

    public float _damage = 1;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	    
	}

    public void TakeDamage(float damage_)
    {
        _health -= Mathf.Abs(damage_);

        if(_health <= 0)
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

    public virtual void Die()
    {

    }
}
