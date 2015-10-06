using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelGUI : Text {

    string _string = "Level: ";

    protected override void Start()
    {
        base.Start();
        _string = text;
    }
	
	// Update is called once per frame
	void Update () {
        this.text = _string + Game.Instance._level;
    }
}
