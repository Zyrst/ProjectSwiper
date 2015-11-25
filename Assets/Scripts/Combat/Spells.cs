using UnityEngine;
using System.Collections;

public class Spells : MonoBehaviour {

    private float _damage;
    private float _heal;
    public bool _cooldown = false;
    public float _cooldownTime;
    public float _timer = 0f;
    public float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    public float Heal
    {
        get
        {
            return _heal;
        }
        set
        {
            _heal = value;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public virtual void DoDamage()
    { }

    public virtual void DoHeal()
    { }
}
