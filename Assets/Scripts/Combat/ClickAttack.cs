using UnityEngine;
using System.Collections;
using System.Linq;

public class ClickAttack : MonoBehaviour {

    public Collider _lastHit = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (MouseController.Instance.buttonDown)
        {
            if (MouseCuboid.hit)
            {
                Collider tempCol = MouseCuboid.colliders.FirstOrDefault(x => x.gameObject.tag == "Enemy");
                if (tempCol != null)
                {
                    if (_lastHit != tempCol)
                    {
                        _lastHit = tempCol;
                        Debug.Log("<color=blue>HITTADE EN FIENDE</color>");

                        _lastHit.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    }
                }
                else
                {   // hit something other than an enemy
                    _lastHit = null;
                }
            }
        }
        else
        {   // didn't hold down the click button
            _lastHit = null;
        }
	}
}
