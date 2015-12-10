using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveGUI : Text {

    public string _string = "Wave: ";

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        this.text = _string + References.Instance._currentCombat.GetComponent<Combat>()._waveCounter + " / 10";
    }
}
