using UnityEngine;
using System.Collections;

public class Enemy : Character {
	// Use this for initialization
	void Start () {
        InitializeGUI();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void InitializeGUI()
    {
        GameObject healthBar = Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Healthbar")) as GameObject;
        healthBar.transform.SetParent(transform);
        healthBar.GetComponent<RectTransform>().localPosition = new Vector3(0, 1, 0);

        GameObject cooldownBar = Instantiate(UnityEngine.Resources.Load("Prefabs/Combat/Cooldownbar")) as GameObject;
        cooldownBar.transform.SetParent(transform);
        cooldownBar.GetComponent<RectTransform>().localPosition = new Vector3(0, -1, 0);
    }

    public override void Die()
    {
        base.Die();

        // Todo: Ta bort kommentaren här :)
        //Debug.Log(gameObject.GetInstanceID() + " avled tragiskt");

        SpawnCurrency();
        Destroy(gameObject);
    }

    void SpawnCurrency()
    {
        Vector3 dir = (Vector3.up * 15f) + -(transform.position - Camera.main.transform.position);
        CurrencyObject.Spawn(dir, transform.position + new Vector3(0, 1, 0));
    }
}
