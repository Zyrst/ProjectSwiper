using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyGUI : Text {

    public string _string = "Currency: ";

    protected override void Start()
    {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        this.text = _string + Game.Instance._gameCurrency;
    }
}
