using UnityEngine;
using System.Collections;

public class Player : Character {
    public float _damage = 1;

	// Use this for initialization
	void Start () {
        Game.Instance._currentPlayer = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Character charHit = GetComponent<ClickAttack>().getNewHit();
	    if (charHit != null)
        {
            charHit.Damage(_damage);
        }
	}

    public override void Die()
    {
        base.Die();

        Debug.Log("Spelaren avled ganska glatt");
        // TODO Något när spelaren dör
    }
}
