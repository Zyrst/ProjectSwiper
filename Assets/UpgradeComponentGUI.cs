using UnityEngine;
using System.Collections;

public class UpgradeComponentGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void upgradeHealth()
    {
        UpgradePlayer.UpgradeHealth();
    }

    public void upgradeDamage()
    {
        UpgradePlayer.UpgradeDamage();
    }

    public void upgradeCrit()
    {
        UpgradePlayer.UpgradeCrit();
    }
}
