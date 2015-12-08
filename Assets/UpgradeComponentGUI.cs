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
        Sounds.OneShot(Sounds.Instance.ui.upgradeBuy);
    }

    public void upgradeDamage()
    {
        UpgradePlayer.UpgradeDamage();
        Sounds.OneShot(Sounds.Instance.ui.upgradeBuy);
    }

    public void upgradeCrit()
    {
        UpgradePlayer.UpgradeCrit();
        Sounds.OneShot(Sounds.Instance.ui.upgradeBuy);
    }
}
