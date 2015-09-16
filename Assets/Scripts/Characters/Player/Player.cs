using UnityEngine;
using System.Collections;

public class Player : Character {
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (GetComponent<ClickAttack>().getNewHit())
        {

        }
	}

    public override void Die()
    {
        base.Die();
    }
}
