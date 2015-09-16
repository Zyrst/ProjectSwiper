using UnityEngine;
using System.Collections;

public class Player : Character {
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Character charHit = GetComponent<ClickAttack>().getNewHit();
	    if (charHit != null)
        {

        }
	}

    public override void Die()
    {
        base.Die();
    }
}
