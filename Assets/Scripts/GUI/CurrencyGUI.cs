using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyGUI : MonoBehaviour {

    public string _string = "Currency: ";

    Text _text;

	// Use this for initialization
	void Start () {
        _text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        _text.text = _string + Game.Instance._gameCurrency;
    }
}
