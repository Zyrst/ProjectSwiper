using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spells : MonoBehaviour {

    protected Material _material;

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
	protected void Start () {
        _material = Instantiate(transform.GetComponent<Image>().material);
        _material.SetFloat("timer", 1f);
        transform.GetComponent<Image>().material = _material;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public virtual void DoDamage()
    { }

    public virtual void DoHeal()
    { }

    protected void updateMaterial()
    {
        if (_cooldown)
            _material.SetFloat("timer", _timer / _cooldownTime);
        else
            _material.SetFloat("timer", 1);
    }
}
