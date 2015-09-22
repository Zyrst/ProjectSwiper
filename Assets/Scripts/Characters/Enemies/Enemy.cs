using UnityEngine;
using System.Collections;

public class Enemy : Character {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Die()
    {
        base.Die();

        Debug.Log(gameObject.GetInstanceID() + " avled tragiskt");

        Destroy(gameObject);
    }
}
